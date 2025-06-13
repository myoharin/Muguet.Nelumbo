using Caprifolium;
using SineVita.Muguet.Nelumbo.IntervalClass;
using SineVita.Muguet.Nelumbo.Lily;

namespace SineVita.Muguet.Nelumbo.Context
{
    public partial class SutraContext
    {
        // * Default values
        private static Dictionary<FormalIntervalClassification, Func<IReadOnlyPitchInterval, bool>> DefaultIntervalClassEvaluation { get {
            var tolerance = 6; // cents
            var classPitchPairs = new List<(FormalIntervalClassification IntervalClass, PitchInterval interval)>() {
                (FormalIntervalClassification.Shimmer, new FloatPitchInterval(1, 30)),
                (FormalIntervalClassification.Limma, new MidiPitchInterval(1)),
                (FormalIntervalClassification.Unison, PitchInterval.Unison),
                (FormalIntervalClassification.Minor2nd, new MidiPitchInterval(1)),
                (FormalIntervalClassification.Major2nd, new MidiPitchInterval(2)),
                (FormalIntervalClassification.Minor3rd, new MidiPitchInterval(3)),
                (FormalIntervalClassification.Major3rd, new MidiPitchInterval(4)),
                (FormalIntervalClassification.Perfect4th, new MidiPitchInterval(5)),
                (FormalIntervalClassification.Tritone, new MidiPitchInterval(6)),
                (FormalIntervalClassification.Perfect5th, new MidiPitchInterval(7)),
                (FormalIntervalClassification.Minor6th, new MidiPitchInterval(8)),
                (FormalIntervalClassification.Major6th, new MidiPitchInterval(9)),
                (FormalIntervalClassification.Minor7th, new MidiPitchInterval(10)),
                (FormalIntervalClassification.Major7th, new MidiPitchInterval(11)),
                (FormalIntervalClassification.Octave, PitchInterval.Octave)
            };
            
            var eval = new Dictionary<FormalIntervalClassification, Func<IReadOnlyPitchInterval, bool>>();
            var toleranceInterval = (new FloatPitchInterval(1, tolerance));
            foreach (var pair in classPitchPairs) {
                eval[pair.IntervalClass] = (x) => {
                    var value = PitchInterval.Abs(x.ToPitchInterval() - pair.interval) < toleranceInterval;
                    // value = x.ToPitchInterval().Equals(pair.interval);
                    // Console.Out.WriteLine($"{value}: {PitchInterval.Abs(x.ToPitchInterval() - pair.interval).ToMidiValue} < {toleranceInterval.ToMidiValue}");
                    // Console.Out.WriteLine($"{value}: {x.ToMidiValue} == {pair.interval.ToMidiValue}");
                    return value;
                };
            }
            
            return eval;
        } }
        private static bool DefaultAssignLotusRoles(List<Lotus> lotuses, ISutraContextualizer contextualizer) {
            var context = contextualizer.Context;
            Lonicera<Lotus, LotusDyad> dyads = new((r, t) => new LotusDyad(r, t));
            // * Initialize Lonicera
            dyads.AddRange(lotuses, true);

            // * 1st Pass - structural 5ths and stress.
            foreach (var dyad in dyads.Links) {
                var reducedInterval = dyad.ReducedInterval;
                var octaveWeight = Math.Pow(1.0d / Math.Ceiling(Math.Log(dyad.Interval.FrequencyRatio, 2)), 0.3d);
                    // based on strict octave
                
                // Structural
                if (context.Evaluate(reducedInterval, FormalIntervalClassification.P5)) {
                    dyad.Root.AddRole(LotusRole.StructuralTonic, octaveWeight);
                    dyad.Terminal.AddRole(LotusRole.StructuralDominant, octaveWeight);
                }

                if (context.Evaluate(reducedInterval, FormalIntervalClassification.P4)) {
                    dyad.Root.AddRole(LotusRole.StructuralDominant, octaveWeight);
                    dyad.Terminal.AddRole(LotusRole.StructuralTonic, octaveWeight);
                }

                // Direct Stress
                if (context.Evaluate(reducedInterval, FormalIntervalClassification.Minor3rd) ||
                    context.Evaluate(reducedInterval, FormalIntervalClassification.Tritone) ||
                    context.Evaluate(reducedInterval, FormalIntervalClassification.Major6th)
                   ) {
                    dyad.Root.AddRole(LotusRole.StressDiminished, octaveWeight);
                    dyad.Terminal.AddRole(LotusRole.StressDiminished, octaveWeight);
                }

                if (context.Evaluate(reducedInterval, FormalIntervalClassification.Major3rd) ||
                    context.Evaluate(reducedInterval, FormalIntervalClassification.Minor6th)
                   ) {
                    dyad.Root.AddRole(LotusRole.StressAugmented, octaveWeight);
                    dyad.Terminal.AddRole(LotusRole.StressAugmented, octaveWeight);
                }
            }

            // * 2nd Pass - Monad
            foreach (var lotus in lotuses)
                // Suspended Mediants
                if (lotus.HasRole(LotusRole.SD) && lotus.HasRole(LotusRole.ST))
                    lotus.AddRole(LotusRole.SuspendedMediant, (lotus[LotusRole.SD] + lotus[LotusRole.ST]) / 2d);
                // average of both strengths

            // * 3rd Pass - Dyad
            foreach (var dyad in dyads.Links) {
                var reducedInterval = dyad.ReducedInterval;
                var root = dyad.Root;
                var terminal = dyad.Terminal;
                var distanceWeight = Math.Pow(1.0 / dyad.Interval.FrequencyRatio, 0.3);
                var octaveWeight = Math.Pow(1.0d / Math.Ceiling(Math.Log(dyad.Interval.FrequencyRatio, 2)), 0.3d);
                    // based on strict octaves
                    
                // interval is
                var isMajor3 = context.Evaluate(reducedInterval, FormalIntervalClassification.Major3rd);
                var isMinor3 = context.Evaluate(reducedInterval, FormalIntervalClassification.Minor3rd);
                var isMajor6 = context.Evaluate(reducedInterval, FormalIntervalClassification.Major6th);
                var isMinor6 = context.Evaluate(reducedInterval, FormalIntervalClassification.Minor6th);

                var rootIsTonic = root.HasRole(LotusRole.StructuralTonic);
                var rootIsDominant = root.HasRole(LotusRole.StructuralDominant);
                var terminalIsTonic = terminal.HasRole(LotusRole.StructuralTonic);
                var terminalIsDominant = terminal.HasRole(LotusRole.StructuralDominant);
                
                var terminalTonicWeight = terminal[LotusRole.StructuralTonic];
                
                // Structural Mediants - look at both SD & ST and add em up
                if (rootIsTonic) {
                    if (isMajor3) terminal.AddRole(LotusRole.SM3, (distanceWeight * root[LotusRole.ST])/2);
                    if (isMinor3) terminal.AddRole(LotusRole.Sm3, (distanceWeight * root[LotusRole.ST])/2);
                }

                if (terminalIsTonic) {
                    if (isMinor6) root.AddRole(LotusRole.SM3, (distanceWeight * terminal[LotusRole.ST])/2);
                    if (isMajor6) root.AddRole(LotusRole.Sm3, (distanceWeight * terminal[LotusRole.ST])/2);
                }
                
                if (rootIsDominant) {
                    if (isMinor6) terminal.AddRole(LotusRole.Sm3, (distanceWeight * root[LotusRole.SD])/2);
                    if (isMajor6) terminal.AddRole(LotusRole.SM3, (distanceWeight * root[LotusRole.SD])/2);
                }

                if (terminalIsDominant) {
                    if (isMinor3) root.AddRole(LotusRole.SM3, (distanceWeight * terminal[LotusRole.SD])/2);
                    if (isMajor3) root.AddRole(LotusRole.Sm3, (distanceWeight * terminal[LotusRole.SD])/2);
                }

                // * Limmatically Suspended Mediants
                if (context.Evaluate(PitchInterval.Abs(reducedInterval.Decremented(PitchInterval.Octave)),
                        FormalIntervalClassification.Limma)) {             // check if interval is inverted Limma
                    if (rootIsDominant) terminal.AddRole(LotusRole.Lsus4, octaveWeight); // G F# + C
                    if (terminalIsTonic) root.AddRole(LotusRole.Lsus2, octaveWeight);    // C# C + G
                }

                if (context.Evaluate(reducedInterval, FormalIntervalClassification.Limma)) {
                    if (rootIsTonic) terminal.AddRole(LotusRole.Lsus2, octaveWeight);            // C C# + G
                    if (terminalIsDominant) root.AddRole(LotusRole.Lsus4, octaveWeight); // F# G + C
                }
            }

            // * 4th pass - tail end implications
            foreach (var dyad in dyads.Links) {
                var reducedInterval = dyad.ReducedInterval;
                var root = dyad.Root;
                var terminal = dyad.Terminal;
                
                var distanceWeight = Math.Pow(1.0 / dyad.Interval.FrequencyRatio, 0.3);
                
                var rootTonicWeight = root[LotusRole.StructuralTonic];
                var rootDominantWeight = root[LotusRole.StructuralDominant];
                
                var terminalTonicWeight = terminal[LotusRole.StructuralTonic];
                var terminalDominantWeight = terminal[LotusRole.StructuralDominant];

                var implicationMultiplier = 0.7;

                // interval is
                var isMajor3 = context.Evaluate(reducedInterval, FormalIntervalClassification.Major3rd);
                var isMinor3 = context.Evaluate(reducedInterval, FormalIntervalClassification.Minor3rd);
                var isMajor6 = context.Evaluate(reducedInterval, FormalIntervalClassification.Major6th);
                var isMinor6 = context.Evaluate(reducedInterval, FormalIntervalClassification.Minor6th);

                var rootIsTonic = root.HasRole(LotusRole.StructuralTonic);
                var rootIsDominant = root.HasRole(LotusRole.StructuralDominant);
                var terminalIsTonic = terminal.HasRole(LotusRole.StructuralTonic);
                var terminalIsDominant = terminal.HasRole(LotusRole.StructuralDominant);
                
                // fromcTonic and dominant - 8 exhaustive checks.
                var rootRelatedDyads = dyads.GetNodeRelatedLinks(root); 
                var terminalRelatedDyads = dyads.GetNodeRelatedLinks(terminal);
                
                bool IntervalUpFromRootExist(FormalIntervalClassification interval) => 
                    rootRelatedDyads.Any(
                        x => ReferenceEquals(x.Root, root) 
                             && context.Evaluate(x.ReducedInterval, interval)
                             );
                bool IntervalDownFromTerminalExist(FormalIntervalClassification interval) => 
                    terminalRelatedDyads.Any(
                        x => ReferenceEquals(x.Terminal, terminal) 
                             && context.Evaluate(x.ReducedInterval, interval)
                    );

                // * Dual Structural Implication
                if (rootIsDominant) { // C [G B|Bb] - check if B | Bb already exist - upper.
                    if (isMajor3 && !IntervalUpFromRootExist(FormalIntervalClassification.Major3rd)) {
                        root.AddRole(LotusRole.Sm3, distanceWeight * implicationMultiplier);
                        terminal.AddRole(LotusRole.SD, rootDominantWeight * implicationMultiplier);
                    } // C [G B]

                    if (isMinor3 && !IntervalUpFromRootExist(FormalIntervalClassification.Minor3rd)) {
                        root.AddRole(LotusRole.SM3, distanceWeight * implicationMultiplier);
                        terminal.AddRole(LotusRole.SD, rootDominantWeight * implicationMultiplier);
                    } // C [G Bb]
                }

                if (rootIsTonic) { // C] G [Ab|A - check if Ab | A already exist - upper. 
                    if (isMajor6 && !IntervalUpFromRootExist(FormalIntervalClassification.Major6th)) {
                        root.AddRole(LotusRole.Sm3, distanceWeight * implicationMultiplier);
                        terminal.AddRole(LotusRole.ST, rootTonicWeight * implicationMultiplier);
                    }

                    if (isMinor6 && !IntervalUpFromRootExist(FormalIntervalClassification.Minor6th)) {
                        root.AddRole(LotusRole.SM3, distanceWeight * implicationMultiplier);
                        terminal.AddRole(LotusRole.ST, rootTonicWeight * implicationMultiplier);
                    }
                }

                if (terminalIsDominant) { // Bb|B] C [G - check if Bb | B already exist - Lower. 
                    if (isMajor6 && !IntervalDownFromTerminalExist(FormalIntervalClassification.Major6th)) {
                        root.AddRole(LotusRole.SD, terminalDominantWeight * implicationMultiplier);
                        terminal.AddRole(LotusRole.SM3, distanceWeight * implicationMultiplier);
                    }

                    if (isMinor6 && !IntervalDownFromTerminalExist(FormalIntervalClassification.Minor6th)) {
                        root.AddRole(LotusRole.SD, terminalDominantWeight * implicationMultiplier);
                        terminal.AddRole(LotusRole.Sm3, distanceWeight * implicationMultiplier);
                    }
                }

                if (terminalIsTonic) { // [Ab|A C] G - check if Ab | A already exist - lower. 
                    if (isMajor3 && !IntervalDownFromTerminalExist(FormalIntervalClassification.Major3rd)) {
                        root.AddRole(LotusRole.ST, terminalTonicWeight * implicationMultiplier);
                        terminal.AddRole(LotusRole.SM3, distanceWeight * implicationMultiplier);
                    } // [Ab C] G

                    if (isMinor3 && !IntervalDownFromTerminalExist(FormalIntervalClassification.Minor3rd)) {
                        root.AddRole(LotusRole.ST, terminalTonicWeight * implicationMultiplier);
                        terminal.AddRole(LotusRole.Sm3, distanceWeight * implicationMultiplier);
                    } // [A C] G
                }
            }

            return true;
        }
        private static double DefaultCalculateStrandWeight(double antecedentWeight, double consequentWeight) {
            // multiplicative average
            return Math.Sqrt(antecedentWeight * consequentWeight);
        }


        // * Experimental Values
        private static Dictionary<FormalIntervalClassification, Func<IReadOnlyPitchInterval, bool>> ExperimentalEvaluation { get {
            var tolerance = 6; // cents

            var classPitchPairs = new List<(FormalIntervalClassification IntervalClass, PitchInterval Interval)>
            {
                (FormalIntervalClassification.Shimmer, new FloatPitchInterval(1, 30)),
                (FormalIntervalClassification.Limma, new MidiPitchInterval(1)),
                (FormalIntervalClassification.Subminor2nd, new FloatPitchInterval(1, 50)),
                (FormalIntervalClassification.Minor2nd, new MidiPitchInterval(1)),
                (FormalIntervalClassification.Neutral2nd, new FloatPitchInterval(1, 150)),
                (FormalIntervalClassification.Major2nd, new MidiPitchInterval(2)),
                (FormalIntervalClassification.Supermajor2nd, new FloatPitchInterval(1, 250)),
                
                (FormalIntervalClassification.Subminor3rd, new FloatPitchInterval(1, 250)),
                (FormalIntervalClassification.Minor3rd, new MidiPitchInterval(3)),
                (FormalIntervalClassification.Neutral3rd, new FloatPitchInterval(1, 350)),
                (FormalIntervalClassification.Major3rd, new MidiPitchInterval(4)),
                (FormalIntervalClassification.Supermajor3rd, new FloatPitchInterval(1, 450)),
                
                (FormalIntervalClassification.Subminor4th, new FloatPitchInterval(1, 450)),
                (FormalIntervalClassification.Minor4th, new FloatPitchInterval(1, 475)),
                (FormalIntervalClassification.Perfect4th, new MidiPitchInterval(5)),
                (FormalIntervalClassification.Major4th, new FloatPitchInterval(1, 525)),
                (FormalIntervalClassification.Supermajor4th, new FloatPitchInterval(1, 550)),
                
                (FormalIntervalClassification.SubminorTritone, new FloatPitchInterval(1, 550)),
                (FormalIntervalClassification.MinorTritone, new FloatPitchInterval(1, 575)),
                (FormalIntervalClassification.Tritone, new MidiPitchInterval(6)),
                (FormalIntervalClassification.MajorTritone, new FloatPitchInterval(1, 625)),
                (FormalIntervalClassification.SupermajorTritone, new FloatPitchInterval(1, 650)),
                
                (FormalIntervalClassification.Subminor5th, new FloatPitchInterval(1, 650)),
                (FormalIntervalClassification.Minor5th, new FloatPitchInterval(1, 675)),
                (FormalIntervalClassification.Perfect5th, new MidiPitchInterval(7)),
                (FormalIntervalClassification.Major5th, new FloatPitchInterval(1, 725)),
                (FormalIntervalClassification.Supermajor5th, new FloatPitchInterval(1, 750)),
                
                (FormalIntervalClassification.Subminor6th, new FloatPitchInterval(1, 750)),
                (FormalIntervalClassification.Minor6th, new MidiPitchInterval(8)),
                (FormalIntervalClassification.Neutral6th, new FloatPitchInterval(1, 850)),
                (FormalIntervalClassification.Major6th, new MidiPitchInterval(9)),
                (FormalIntervalClassification.Supermajor6th, new FloatPitchInterval(1, 950)),
                
                (FormalIntervalClassification.Subminor7th, new FloatPitchInterval(1, 950)),
                (FormalIntervalClassification.Minor7th, new MidiPitchInterval(10)),
                (FormalIntervalClassification.Neutral7th, new FloatPitchInterval(1, 1050)),
                (FormalIntervalClassification.Major7th, new MidiPitchInterval(11)),
                (FormalIntervalClassification.Supermajor7th, new FloatPitchInterval(1, 1150)),
                
                (FormalIntervalClassification.Octave, PitchInterval.Octave)
            };

            var eval = new Dictionary<FormalIntervalClassification, Func<IReadOnlyPitchInterval, bool>>();

            foreach (var pair in classPitchPairs)
            {
                eval[pair.IntervalClass] = (x) => PitchInterval.Abs(x.ToPitchInterval() - pair.Interval) < new FloatPitchInterval(1, tolerance);
            }

            return eval;
        } }
        
        
        // * Presets
        public static SutraContext Default => new SutraContext();

    }
}