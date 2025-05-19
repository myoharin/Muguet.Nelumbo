using System.Data;
using System.Dynamic;
using System.Numerics;
using Microsoft.VisualBasic;
using SineVita.Muguet;

namespace SineVita.Muguet.Nelumbo {
    internal class SutraContext {
        public SutraContext(Dictionary<FormalIntervalClassification, Func<PitchInterval, bool>>? evaluationOverrides = null) {
            _intervalEvaluation = _defaultInternalEvaluation;
            if (evaluationOverrides != null) {
                foreach (var key in evaluationOverrides.Keys) {
                    _intervalEvaluation[key] = evaluationOverrides[key];
                }
            }
        }
        
        // * Default values
        private static Dictionary<FormalIntervalClassification, Func<PitchInterval, bool>> _defaultInternalEvaluation { get {
            var tolerance = 6; // cents
            
            var eval = new Dictionary<FormalIntervalClassification, Func<PitchInterval, bool>>();
            eval[FormalIntervalClassification.Shimmer]     = (x) => PitchInterval.Abs(x - new FloatPitchInterval(0, 30)) < new FloatPitchInterval(0, tolerance);
            eval[FormalIntervalClassification.Limma]       = (x) => PitchInterval.Abs(x - new MidiPitchInterval(1)) < new FloatPitchInterval(0, tolerance);
            
            eval[FormalIntervalClassification.Minor2nd]    = (x) => PitchInterval.Abs(x - new MidiPitchInterval(1)) < new FloatPitchInterval(0, tolerance);
            eval[FormalIntervalClassification.Major2nd]    = (x) => PitchInterval.Abs(x - new MidiPitchInterval(2)) < new FloatPitchInterval(0, tolerance);
            eval[FormalIntervalClassification.Minor3rd]    = (x) => PitchInterval.Abs(x - new MidiPitchInterval(3)) < new FloatPitchInterval(0, tolerance);
            eval[FormalIntervalClassification.Major3rd]    = (x) => PitchInterval.Abs(x - new MidiPitchInterval(4)) < new FloatPitchInterval(0, tolerance);
            eval[FormalIntervalClassification.Perfect4th]  = (x) => PitchInterval.Abs(x - new MidiPitchInterval(5)) < new FloatPitchInterval(0, tolerance);
            eval[FormalIntervalClassification.Tritone]     = (x) => PitchInterval.Abs(x - new MidiPitchInterval(6)) < new FloatPitchInterval(0, tolerance);
            eval[FormalIntervalClassification.Perfect5th]  = (x) => PitchInterval.Abs(x - new MidiPitchInterval(7)) < new FloatPitchInterval(0, tolerance);
            eval[FormalIntervalClassification.Minor6th]    = (x) => PitchInterval.Abs(x - new MidiPitchInterval(8)) < new FloatPitchInterval(0, tolerance);
            eval[FormalIntervalClassification.Major6th]    = (x) => PitchInterval.Abs(x - new MidiPitchInterval(9)) < new FloatPitchInterval(0, tolerance);
            eval[FormalIntervalClassification.Minor7th]    = (x) => PitchInterval.Abs(x - new MidiPitchInterval(10)) < new FloatPitchInterval(0, tolerance);
            eval[FormalIntervalClassification.Major7th]    = (x) => PitchInterval.Abs(x - new MidiPitchInterval(11)) < new FloatPitchInterval(0, tolerance);
            eval[FormalIntervalClassification.Octave] = (x) => x == PitchInterval.Octave;
            return eval;
        } }
        private static Dictionary<FormalIntervalClassification, Func<PitchInterval, bool>> _experimentalEvaluation { get {
            
            var tolerance = 6; // cents
            
            var eval = new Dictionary<FormalIntervalClassification, Func<PitchInterval, bool>>();
            eval[FormalIntervalClassification.Shimmer]            = (x) => PitchInterval.Abs(x - new FloatPitchInterval(0, 30)) < new FloatPitchInterval(0, tolerance);
            eval[FormalIntervalClassification.Limma]              = (x) => PitchInterval.Abs(x - new MidiPitchInterval(1)) < new FloatPitchInterval(0, tolerance);
            
            eval[FormalIntervalClassification.Subminor2nd]        = (x) => PitchInterval.Abs(x - new FloatPitchInterval(0, 50)) < new FloatPitchInterval(0, tolerance);
            eval[FormalIntervalClassification.Minor2nd]           = (x) => PitchInterval.Abs(x - new MidiPitchInterval(1)) < new FloatPitchInterval(0, tolerance);
            eval[FormalIntervalClassification.Neutral2nd]         = (x) => PitchInterval.Abs(x - new FloatPitchInterval(0, 150)) < new FloatPitchInterval(0, tolerance);
            eval[FormalIntervalClassification.Major2nd]           = (x) => PitchInterval.Abs(x - new MidiPitchInterval(2)) < new FloatPitchInterval(0, tolerance);
            eval[FormalIntervalClassification.Supermajor2nd]      = (x) => PitchInterval.Abs(x - new FloatPitchInterval(0, 250)) < new FloatPitchInterval(0, tolerance);

            eval[FormalIntervalClassification.Subminor3rd]        = (x) => PitchInterval.Abs(x - new FloatPitchInterval(0, 250)) < new FloatPitchInterval(0, tolerance);
            eval[FormalIntervalClassification.Minor3rd]           = (x) => PitchInterval.Abs(x - new MidiPitchInterval(3)) < new FloatPitchInterval(0, tolerance);
            eval[FormalIntervalClassification.Neutral3rd]         = (x) => PitchInterval.Abs(x - new FloatPitchInterval(0, 350)) < new FloatPitchInterval(0, tolerance);
            eval[FormalIntervalClassification.Major3rd]           = (x) => PitchInterval.Abs(x - new MidiPitchInterval(4)) < new FloatPitchInterval(0, tolerance);
            eval[FormalIntervalClassification.Supermajor3rd]      = (x) => PitchInterval.Abs(x - new FloatPitchInterval(0, 450)) < new FloatPitchInterval(0, tolerance);

            eval[FormalIntervalClassification.Subminor4th]        = (x) => PitchInterval.Abs(x - new FloatPitchInterval(0, 450)) < new FloatPitchInterval(0, tolerance);
            eval[FormalIntervalClassification.Minor4th]           = (x) => PitchInterval.Abs(x - new FloatPitchInterval(0, 475)) < new FloatPitchInterval(0, tolerance);
            eval[FormalIntervalClassification.Perfect4th]         = (x) => PitchInterval.Abs(x - new MidiPitchInterval(5)) < new FloatPitchInterval(0, tolerance);
            eval[FormalIntervalClassification.Major4th]           = (x) => PitchInterval.Abs(x - new FloatPitchInterval(0, 525)) < new FloatPitchInterval(0, tolerance);
            eval[FormalIntervalClassification.Supermajor4th]      = (x) => PitchInterval.Abs(x - new FloatPitchInterval(0, 550)) < new FloatPitchInterval(0, tolerance);

            eval[FormalIntervalClassification.SubminorTritone]    = (x) => PitchInterval.Abs(x - new FloatPitchInterval(0, 550)) < new FloatPitchInterval(0, tolerance);
            eval[FormalIntervalClassification.MinorTritone]       = (x) => PitchInterval.Abs(x - new FloatPitchInterval(0, 575)) < new FloatPitchInterval(0, tolerance);
            eval[FormalIntervalClassification.Tritone]            = (x) => PitchInterval.Abs(x - new MidiPitchInterval(6)) < new FloatPitchInterval(0, tolerance);
            eval[FormalIntervalClassification.MajorTritone]       = (x) => PitchInterval.Abs(x - new FloatPitchInterval(0, 625)) < new FloatPitchInterval(0, tolerance);
            eval[FormalIntervalClassification.SupermajorTritone]  = (x) => PitchInterval.Abs(x - new FloatPitchInterval(0, 650)) < new FloatPitchInterval(0, tolerance);

            eval[FormalIntervalClassification.Subminor5th]        = (x) => PitchInterval.Abs(x - new FloatPitchInterval(0, 650)) < new FloatPitchInterval(0, tolerance);
            eval[FormalIntervalClassification.Minor5th]           = (x) => PitchInterval.Abs(x - new FloatPitchInterval(0, 675)) < new FloatPitchInterval(0, tolerance);
            eval[FormalIntervalClassification.Perfect5th]         = (x) => PitchInterval.Abs(x - new MidiPitchInterval(7)) < new FloatPitchInterval(0, tolerance);
            eval[FormalIntervalClassification.Major5th]           = (x) => PitchInterval.Abs(x - new FloatPitchInterval(0, 725)) < new FloatPitchInterval(0, tolerance);
            eval[FormalIntervalClassification.Supermajor5th]      = (x) => PitchInterval.Abs(x - new FloatPitchInterval(0, 750)) < new FloatPitchInterval(0, tolerance);

            eval[FormalIntervalClassification.Subminor6th]        = (x) => PitchInterval.Abs(x - new FloatPitchInterval(0, 750)) < new FloatPitchInterval(0, tolerance);
            eval[FormalIntervalClassification.Minor6th]           = (x) => PitchInterval.Abs(x - new MidiPitchInterval(8)) < new FloatPitchInterval(0, tolerance);
            eval[FormalIntervalClassification.Neutral6th]         = (x) => PitchInterval.Abs(x - new FloatPitchInterval(0, 850)) < new FloatPitchInterval(0, tolerance);
            eval[FormalIntervalClassification.Major6th]           = (x) => PitchInterval.Abs(x - new MidiPitchInterval(9)) < new FloatPitchInterval(0, tolerance);
            eval[FormalIntervalClassification.Supermajor6th]      = (x) => PitchInterval.Abs(x - new FloatPitchInterval(0, 950)) < new FloatPitchInterval(0, tolerance);

            eval[FormalIntervalClassification.Subminor7th]        = (x) => PitchInterval.Abs(x - new FloatPitchInterval(0, 950)) < new FloatPitchInterval(0, tolerance);
            eval[FormalIntervalClassification.Minor7th]           = (x) => PitchInterval.Abs(x - new MidiPitchInterval(10)) < new FloatPitchInterval(0, tolerance);
            eval[FormalIntervalClassification.Neutral7th]         = (x) => PitchInterval.Abs(x - new FloatPitchInterval(0, 1050)) < new FloatPitchInterval(0, tolerance);
            eval[FormalIntervalClassification.Major7th]           = (x) => PitchInterval.Abs(x - new MidiPitchInterval(11)) < new FloatPitchInterval(0, tolerance);
            eval[FormalIntervalClassification.Supermajor7th]      = (x) => PitchInterval.Abs(x - new FloatPitchInterval(0, 1150)) < new FloatPitchInterval(0, tolerance);

            eval[FormalIntervalClassification.Octave] = (x) => x == PitchInterval.Octave;
            return eval;
        } }
        
        public static SutraContext Default => new SutraContext();

        // * Interval Evaluations
        private Dictionary<FormalIntervalClassification, Func<PitchInterval, bool>> _intervalEvaluation { get; set; }
        public bool Evaluate(PitchInterval interval, FormalIntervalClassification intervalClass) {
            if (_intervalEvaluation.ContainsKey(intervalClass)) {
                return _intervalEvaluation[intervalClass](PitchInterval.Abs(interval));
            } else {
                return false;
            }
        }

        public void UpdateEvaluation(FormalIntervalClassification intervalClass, Func<PitchInterval, bool> func) {
            if (!_intervalEvaluation.TryAdd(intervalClass, func)) {
                _intervalEvaluation[intervalClass] = func;
            }
        }
        public bool RemoveEvaluation(FormalIntervalClassification intervalClass) {
            return _intervalEvaluation.Remove(intervalClass);
        }

        public Func<PitchInterval, bool> this[FormalIntervalClassification intervalClass] {
            get {
                if (_intervalEvaluation.ContainsKey(intervalClass)) {
                    return _intervalEvaluation[intervalClass];
                }
                else {
                    return (_) => false;
                }
            }
            set {
                _intervalEvaluation[intervalClass] = value;
            }
        }
    }
}