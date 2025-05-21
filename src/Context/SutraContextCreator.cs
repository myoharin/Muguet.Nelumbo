using SineVita.Muguet.Nelumbo.IntervalClass;

namespace SineVita.Muguet.Nelumbo.Context
{
    public partial class SutraContext
    {
        // * Default values
        private static Dictionary<FormalIntervalClassification, Func<IReadOnlyPitchInterval, bool>> DefaultInternalEvaluation { get {
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