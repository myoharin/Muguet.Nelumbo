using SineVita.Muguet.Nelumbo.IntervalClass;
using SineVita.Muguet.Nelumbo.Sutra;

namespace SineVita.Muguet.Nelumbo.Context {
    public partial class SutraContext : 
            ISutraContextualizer, IReadOnlySutraContext
    {
        // * Constructor
        public SutraContext(Dictionary<FormalIntervalClassification, Func<IReadOnlyPitchInterval, bool>>? evaluationOverrides = null) {
            _intervalEvaluation = DefaultInternalEvaluation;
            if (evaluationOverrides != null) {
                foreach (var key in evaluationOverrides.Keys) {
                    _intervalEvaluation[key] = evaluationOverrides[key];
                }
            }
        }
        
        // * Interval Evaluations
        private Dictionary<FormalIntervalClassification, Func<IReadOnlyPitchInterval, bool>> _intervalEvaluation { get; set; }

        public void UpdateEvaluation(FormalIntervalClassification intervalClass, Func<IReadOnlyPitchInterval, bool> func) {
            if (!_intervalEvaluation.TryAdd(intervalClass, func)) {
                _intervalEvaluation[intervalClass] = func;
            }
        }
        public bool RemoveEvaluation(FormalIntervalClassification intervalClass) {
            return _intervalEvaluation.Remove(intervalClass);
        }

        public Func<IReadOnlyPitchInterval, bool> this[FormalIntervalClassification intervalClass] {
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
        public Func<IReadOnlyPitchInterval, bool> this[GenericLocalMovement value] {
            get {
                return value switch { // TODO should U4 U5 and U8 be octave equiv?
                    GenericLocalMovement.U => this[FormalIntervalClassification.Unison],

                    GenericLocalMovement.UL => this[FormalIntervalClassification.Limma],
                    GenericLocalMovement.U4 => this[FormalIntervalClassification.Perfect4th],
                    GenericLocalMovement.U5 => this[FormalIntervalClassification.Perfect5th],
                    GenericLocalMovement.UO => this[FormalIntervalClassification.Octave],

                    GenericLocalMovement.DL => (x) => this[FormalIntervalClassification.Limma](x.Inverted()),
                    GenericLocalMovement.D4 => (x) => this[FormalIntervalClassification.Perfect4th](x.Inverted()),
                    GenericLocalMovement.D5 => (x) => this[FormalIntervalClassification.Perfect5th](x.Inverted()),
                    GenericLocalMovement.DO => (x) => this[FormalIntervalClassification.Unison](x.Inverted()),
                    
                    _  => (x) => false,
                };
            }
        }
        
        public bool Evaluate(IReadOnlyPitchInterval interval, GenericLocalMovement value) => this[value](interval);
        public bool Evaluate(IReadOnlyPitchInterval interval, FormalIntervalClassification intervalClass) => this[intervalClass](interval);
        
        // * ISutraContextualizer
        public SutraContext Context => this;
    }
}