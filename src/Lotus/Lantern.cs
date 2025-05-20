using Caprifolium;
using System.Collections.Generic;
using SineVita.Muguet.Nelumbo.IntervalClass;

namespace SineVita.Muguet.Nelumbo {
    public class Lantern {
        // * Object References
        public LanternSutra Sutra { init; get; }
        public SutraContext Context => Sutra.Context;
 
        // * Core Variable Management
        private Chord _chord;
        public IReadOnlyChord Chord => _chord.Clone();
        public List<Lotus> Lotuses { get; set; }
        
        // * Derived Gets
        public int Count => Lotuses.Count;

        // * Constructor
        public Lantern(LanternSutra sutra, Chord chord) {
            this.Sutra = sutra;
            Lotuses = new();
            _chord = new();
            SetChord(chord);
        }

        // * Chord
        public void SetChord(Chord chord) {
            _chord = chord;
            foreach (var pitch in chord.Notes) {
                Lotuses.Add(new Lotus(pitch, this));
            }
            AssignLotusRoles();
        }
        
        // * Call Analysis
        private void AssignLotusRoles() { // TODO make this centrally modifiable
            Lonicera<Lotus, LotusDyad> dyads = new(growth: (r, t) => new LotusDyad(r, t));
            
            // Knautia<Lotus, LotusTriad> triads = new(3, growth: (lotuses) => new LotusTriad(lotuses[0], lotuses[1], lotuses[2]));
            // ^ Redundant
            
            // * Initialize Lonicera
            dyads.AddRange(Lotuses, true);
            
            // * First Pass
            foreach (var dyad in dyads.Links) {
                var reducedInterval = dyad.ReducedInterval;
                // Structural
                if (Context.Evaluate(reducedInterval, FormalIntervalClassification.P5)) {
                    dyad.Root.AddRole(LotusRole.StructuralTonic);
                    dyad.Terminal.AddRole(LotusRole.StructuralDominant);
                }   
                
                // Direct Stress
                if (Context.Evaluate(reducedInterval, FormalIntervalClassification.Minor3rd) ||
                    Context.Evaluate(reducedInterval, FormalIntervalClassification.Tritone) ||
                    Context.Evaluate(reducedInterval, FormalIntervalClassification.Major6th)
                    ) {
                    dyad.Root.AddRole(LotusRole.StressDiminished);
                    dyad.Terminal.AddRole(LotusRole.StressDiminished);
                }
                if (Context.Evaluate(reducedInterval, FormalIntervalClassification.Major3rd) ||
                    Context.Evaluate(reducedInterval, FormalIntervalClassification.Minor6th)
                   ) {
                    dyad.Root.AddRole(LotusRole.StressAugmented); 
                    dyad.Terminal.AddRole(LotusRole.StressAugmented);
                }
            }
            // * Second Pass - Lotus
            foreach (var lotus in Lotuses) {
                // Suspended Mediants
                if (lotus.HasRole(LotusRole.SD) && lotus.HasRole(LotusRole.ST)) {
                    lotus.AddRole(LotusRole.SuspendedMediant);
                }
            }
            
            // * Third Pass - Dyads
            foreach (var dyad in dyads.Links) {
                var reducedInterval = dyad.ReducedInterval;
                var root = dyad.Root;
                var terminal = dyad.Terminal;
               
                // Structural Mediants - only look at tonic
                if (root.HasRole(LotusRole.StructuralTonic)) {
                    if (Context.Evaluate(reducedInterval, FormalIntervalClassification.Major3rd)) {
                        terminal.AddRole(LotusRole.SM3);
                    }
                    if (Context.Evaluate(reducedInterval, FormalIntervalClassification.Minor3rd)) {
                        terminal.AddRole(LotusRole.Sm3);
                    }
                }
                if (terminal.HasRole(LotusRole.StructuralTonic)) {
                    if (Context.Evaluate(reducedInterval, FormalIntervalClassification.Minor6th)) {
                        root.AddRole(LotusRole.SM3);
                    }
                    if (Context.Evaluate(reducedInterval, FormalIntervalClassification.Major6th)) {
                        root.AddRole(LotusRole.Sm3);
                    }
                }
                
                // * Dual Structural Implication
                if (root.HasRole(LotusRole.StructuralDominant)) { // C [G B|Bb]
                    if (Context.Evaluate(reducedInterval, FormalIntervalClassification.Major3rd) ||
                        Context.Evaluate(reducedInterval, FormalIntervalClassification.Minor6th)
                        ) {
                        root.AddRole(LotusRole.Sm3);
                        terminal.AddRole(LotusRole.SD);
                    } // C [G B]
                    if (Context.Evaluate(reducedInterval, FormalIntervalClassification.Minor3rd) ||
                        Context.Evaluate(reducedInterval, FormalIntervalClassification.Major6th)
                        ) {
                        root.AddRole(LotusRole.SM3);
                        terminal.AddRole(LotusRole.SD);
                    }  // C [G Bb]
                }
                if (terminal.HasRole(LotusRole.StructuralTonic)) { // [Ab|A C] G
                    if (Context.Evaluate(reducedInterval, FormalIntervalClassification.Major3rd) ||
                        Context.Evaluate(reducedInterval, FormalIntervalClassification.Minor6th)
                        ) {
                        root.AddRole(LotusRole.ST);
                        terminal.AddRole(LotusRole.SM3);
                    } // [Ab C] G
                    if (Context.Evaluate(reducedInterval, FormalIntervalClassification.Minor3rd) ||
                        Context.Evaluate(reducedInterval, FormalIntervalClassification.Major6th)
                        ) {
                        root.AddRole(LotusRole.ST);
                        terminal.AddRole(LotusRole.Sm3);
                    } // [A C] G
                }
                
                // * Limmatic Suspended Mediants - only look at tonic
                    // Lsus2
                    // Root ST: C G C# / C C# G / G C C# - DONE
                    // Terminal ST: C# G C / C# C G / G C# C - Inverted Limma
                    
                    // Lsus4
                    // Root SD: C G F# / G C F# / G F# C - Inverted Limma
                    // Terminal SD F# C G / F# G C / C F# G - DONE
                if (Context.Evaluate(PitchInterval.Abs(reducedInterval.Decremented(PitchInterval.Octave)),
                        FormalIntervalClassification.Limma)) { // check if interval is inverted Limma
                    if (root.HasRole(LotusRole.SD)) terminal.AddRole(LotusRole.Lsus4);
                    if (terminal.HasRole(LotusRole.ST)) root.AddRole(LotusRole.Lsus2);
                }
                if (Context.Evaluate(reducedInterval, FormalIntervalClassification.Limma)) {
                    if (root.HasRole(LotusRole.ST)) terminal.AddRole(LotusRole.Lsus2);
                    if (terminal.HasRole(LotusRole.SD)) terminal.AddRole(LotusRole.Lsus4);
                }
            }
            
            
        }
        
        
        
    }
}