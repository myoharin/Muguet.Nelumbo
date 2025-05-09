using System.Data;
using System.Dynamic;
using System.Numerics;
using Microsoft.VisualBasic;
using SineVita.Muguet;

namespace SineVita.Muguet.Nelumbo {
    internal class SutraContext {
        public SutraContext(Dictionary<IntervalClass, Func<PitchInterval, bool>>? evaluationOverrides = null) {
            _intervalEvaluation = _defaultInternalEvaluation;
            if (evaluationOverrides != null) {
                foreach (var key in evaluationOverrides.Keys) {
                    _intervalEvaluation[key] = evaluationOverrides[key];
                }
            }
        }
        // * Default values
        private static Dictionary<IntervalClass, Func<PitchInterval, bool>> _defaultInternalEvaluation { get {
            var intervalEvaluation = new Dictionary<IntervalClass, Func<PitchInterval, bool>>();
            intervalEvaluation[IntervalClass.Shimmer] = (x) => x == 30;
            intervalEvaluation[IntervalClass.Subminor2nd] = (x) => x == 50;
            intervalEvaluation[IntervalClass.Limma] = (x) => x == 100;
            intervalEvaluation[IntervalClass.Minor2nd] = (x) => x == 100;
            intervalEvaluation[IntervalClass.Neutral2nd] = (x) => x == 150;
            intervalEvaluation[IntervalClass.Major2nd] = (x) => x == 200;
            intervalEvaluation[IntervalClass.Subminor3rd] = (x) => x == 250;
            intervalEvaluation[IntervalClass.Minor3rd] = (x) => x == 300;
            intervalEvaluation[IntervalClass.Neutral3rd] = (x) => x == 350;
            intervalEvaluation[IntervalClass.Major3rd] = (x) => x == 400;
            intervalEvaluation[IntervalClass.Supermajor3rd] = (x) => x == 450;
            intervalEvaluation[IntervalClass.Perfect4th] = (x) => x == 500;
            intervalEvaluation[IntervalClass.Major4th] = (x) => x == 550;
            intervalEvaluation[IntervalClass.Tritone] = (x) => x == 600;
            intervalEvaluation[IntervalClass.Minor5th] = (x) => x == 650;
            intervalEvaluation[IntervalClass.Perfect5th] = (x) => x == 700;
            intervalEvaluation[IntervalClass.Subminor6th] = (x) => x == 750;
            intervalEvaluation[IntervalClass.Minor6th] = (x) => x == 800;
            intervalEvaluation[IntervalClass.Neutral6th] = (x) => x == 850;
            intervalEvaluation[IntervalClass.Major6th] = (x) => x == 900;
            intervalEvaluation[IntervalClass.Supermajor6th] = (x) => x == 950;
            intervalEvaluation[IntervalClass.Subminor7th] = (x) => x == 1000;
            intervalEvaluation[IntervalClass.Minor7th] = (x) => x == 1000;
            intervalEvaluation[IntervalClass.Neutral7th] = (x) => x == 1050;
            intervalEvaluation[IntervalClass.Major7th] = (x) => x == 1100;
            intervalEvaluation[IntervalClass.Supermajor7th] = (x) => x == 1150;
            intervalEvaluation[IntervalClass.Octave] = (x) => x == 1200;
            return intervalEvaluation;
        } }
        public static SutraContext Default { get { return new SutraContext(); } } 

        // * Interval Evaluations
        private Dictionary<IntervalClass, Func<PitchInterval, bool>> _intervalEvaluation { get; set; }
        public bool IntervalIsClass(PitchInterval interval, IntervalClass intervalClass) {
            if (_intervalEvaluation.ContainsKey(intervalClass)) {
                return _intervalEvaluation[intervalClass](interval);
            } else {
                return false;
            }
        }

        public void UpdateEvaluation(IntervalClass intervalClass, Func<PitchInterval, bool> func) {
            if (!_intervalEvaluation.TryAdd(intervalClass, func)) {
                _intervalEvaluation[intervalClass] = func;
            }
        }
        public bool RemoveEvaluation(IntervalClass intervalClass) {
            return _intervalEvaluation.Remove(intervalClass);
        }

        public Func<PitchInterval, bool> this[IntervalClass intervalClass] {
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