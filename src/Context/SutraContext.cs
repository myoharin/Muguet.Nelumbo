using SineVita.Muguet.Nelumbo.IntervalClass;
using SineVita.Muguet.Nelumbo.Lily;
using SineVita.Muguet.Nelumbo.Sutra;

namespace SineVita.Muguet.Nelumbo.Context {
    public partial class SutraContext : 
            ISutraContextualizer, IReadOnlySutraContext
    {
        // * Constructor
        public SutraContext(Dictionary<FormalIntervalClassification, Func<IReadOnlyPitchInterval, bool>>? evaluationOverrides = null) {
            _intervalEvaluation = DefaultIntervalClassEvaluation;
            if (evaluationOverrides != null) {
                foreach (var key in evaluationOverrides.Keys) {
                    _intervalEvaluation[key] = evaluationOverrides[key];
                }
            }

            _assignLotusRoles = DefaultAssignLotusRoles; // default
            RoleWeightThreshold = 0.5; // default
            _calculateStrandWeight = DefaultCalculateStrandWeight;
            StrandWeightThreshold = 0.6; // default
        }
        
        // * Properties
        private Dictionary<FormalIntervalClassification, Func<IReadOnlyPitchInterval, bool>> _intervalEvaluation;
        private Func<List<Lotus>, ISutraContextualizer, bool> _assignLotusRoles;
        private Func<double, double, double> _calculateStrandWeight;
        
        public double RoleWeightThreshold { get; set; }
        public double StrandWeightThreshold { get; set; }

        // * Applying Functions
        public bool AssignLotusRoles(List<Lotus> lotuses) => _assignLotusRoles(lotuses, this);

        public double CalculateStrandWeight(double antecedantWeight, double consequentWeight) => _calculateStrandWeight(antecedantWeight, consequentWeight);
        // * Interval Evaluations
        

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
        public bool Evaluate(IReadOnlyPitchInterval interval, FormalIntervalClassification value) => this[value](interval);
        
        // * ISutraContextualizer
        public SutraContext Context => this;
    }
}