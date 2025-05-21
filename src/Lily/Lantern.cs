using Caprifolium;
using SineVita.Muguet.Nelumbo.Context;
using SineVita.Muguet.Nelumbo.IntervalClass;

namespace SineVita.Muguet.Nelumbo.Lily {
    public class Lantern : ISutraContextualizer {
        // * Object References
        public SutraContext Context { init; get; }

        // * Core Variable Management
        private Chord _chord;
        public IReadOnlyChord Chord => _chord.Clone();
        public List<Lotus> Lotuses { get; set; }
        
        // * Derived Gets
        public int Count => Lotuses.Count;

        // * Constructor
        public Lantern(ISutraContextualizer contextualizer, IReadOnlyChord chord) {
            Context = contextualizer.Context;
            Lotuses = new();
            _chord = new();
            SetChord(chord);
        }

        // * Chord
        public void SetChord(IReadOnlyChord readOnlyChord) {
            _chord = readOnlyChord.ToChord();
            foreach (var pitch in _chord.Notes) {
                Lotuses.Add(new Lotus(this, pitch));
            }
            AssignLotusRoles();
        }
        
        // * Call Analysis
        private void AssignLotusRoles() { // TODO make this centrally modifiable
            Lonicera<Lotus, LotusDyad> dyads = new(growth: (r, t) => new LotusDyad(r, t));
            
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
                if (Context.Evaluate(reducedInterval, FormalIntervalClassification.P4)) {
                    dyad.Root.AddRole(LotusRole.StructuralDominant);
                    dyad.Terminal.AddRole(LotusRole.StructuralTonic);
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
                
                // interval is
                var isMajor3 = Context.Evaluate(reducedInterval, FormalIntervalClassification.Major3rd);
                var isMinor3 = Context.Evaluate(reducedInterval, FormalIntervalClassification.Minor3rd);
                var isMajor6 = Context.Evaluate(reducedInterval, FormalIntervalClassification.Major6th);
                var isMinor6 = Context.Evaluate(reducedInterval, FormalIntervalClassification.Minor6th);

                var rootIsTonic = root.HasRole(LotusRole.StructuralTonic);
                var rootIsDominant = root.HasRole(LotusRole.StructuralDominant);
                var terminalIsTonic = terminal.HasRole(LotusRole.StructuralTonic);
                var terminalIsDominant = terminal.HasRole(LotusRole.StructuralDominant);
               
                // Structural Mediants - only look at tonic
                if (rootIsTonic) {
                    if (isMajor3) {
                        terminal.AddRole(LotusRole.SM3);
                    }
                    if (isMinor3) {
                        terminal.AddRole(LotusRole.Sm3);
                    }
                }
                if (terminalIsTonic) {
                    if (isMinor6) {
                        root.AddRole(LotusRole.SM3);
                    }
                    if (isMajor6) {
                        root.AddRole(LotusRole.Sm3);
                    }
                }
                
                // * Limmatically Suspended Mediants
                if (Context.Evaluate(PitchInterval.Abs(reducedInterval.Decremented(PitchInterval.Octave)),
                        FormalIntervalClassification.Limma)) { // check if interval is inverted Limma
                    if (rootIsDominant) terminal.AddRole(LotusRole.Lsus4); // G F# + C
                    if (terminalIsTonic) root.AddRole(LotusRole.Lsus2); // C# C + G
                }
                if (Context.Evaluate(reducedInterval, FormalIntervalClassification.Limma)) {
                    if (rootIsTonic) terminal.AddRole(LotusRole.Lsus2); // C C# + G
                    if (terminalIsDominant) root.AddRole(LotusRole.Lsus4); // F# G + C
                }
            }
            
            // * 4th pass - tail end implications
            foreach (var dyad in dyads.Links) {
                var reducedInterval = dyad.ReducedInterval;
                var root = dyad.Root;
                var terminal = dyad.Terminal;

                // interval is
                var isMajor3 = Context.Evaluate(reducedInterval, FormalIntervalClassification.Major3rd);
                var isMinor3 = Context.Evaluate(reducedInterval, FormalIntervalClassification.Minor3rd);
                var isMajor6 = Context.Evaluate(reducedInterval, FormalIntervalClassification.Major6th);
                var isMinor6 = Context.Evaluate(reducedInterval, FormalIntervalClassification.Minor6th);

                var rootIsTonic = root.HasRole(LotusRole.StructuralTonic);
                var rootIsDominant = root.HasRole(LotusRole.StructuralDominant);
                var terminalIsTonic = terminal.HasRole(LotusRole.StructuralTonic);
                var terminalIsDominant = terminal.HasRole(LotusRole.StructuralDominant);
                
                // * Dual Structural Implication
                if (rootIsDominant) { // C [G B|Bb]
                    if (isMajor3) {
                        root.AddRole(LotusRole.Sm3);
                        terminal.AddRole(LotusRole.SD);
                    } // C [G B]
                    if (isMinor3) {
                        root.AddRole(LotusRole.SM3);
                        terminal.AddRole(LotusRole.SD);
                    }  // C [G Bb]
                }
                if (rootIsTonic) { // C] G [Ab|A
                    if (isMajor6) {
                        root.AddRole(LotusRole.Sm3);
                        terminal.AddRole(LotusRole.ST);
                    }
                    if (isMinor6) {
                        root.AddRole(LotusRole.SM3);
                        terminal.AddRole(LotusRole.ST);
                    }
                }
                if (terminalIsDominant) { // Bb|B] C [G
                    if (isMajor6) {
                        root.AddRole(LotusRole.SD);
                        terminal.AddRole(LotusRole.SM3);
                    } // [Ab C] G
                    if (isMinor6) {
                        root.AddRole(LotusRole.SD);
                        terminal.AddRole(LotusRole.Sm3);
                    } // [A C] G
                }
                if (terminalIsTonic) { // [Ab|A C] G
                    if (isMajor3) {
                        root.AddRole(LotusRole.ST);
                        terminal.AddRole(LotusRole.SM3);
                    } // [Ab C] G
                    if (isMinor3) {
                        root.AddRole(LotusRole.ST);
                        terminal.AddRole(LotusRole.Sm3);
                    } // [A C] G
                }
            }

        }
        
        
        
    }
}