using SineVita.Muguet;
using SineVita.Muguet.Nelumbo.Context;

namespace SineVita.Muguet.Nelumbo.Lily {
    public class Lotus : ISutraContextualizer {
        // * Object References
        public SutraContext Context { init; get; }
        public Pitch Pitch { init; get; }

        // * Variables
        private Dictionary<LotusRole, double> _roleWeights;
        
        public IReadOnlyList<LotusRole> Roles {
            get {
                var list = _roleWeights.Keys
                    .Where(x => this[x] >= Context.RoleWeightThreshold)
                    .ToList();
                list.Sort((x, y) => x.CompareTo(y));
                return list.AsReadOnly();
            }
        }

        public double this[LotusRole role] => _roleWeights.TryGetValue(role, out var weight) ? weight : 0;

        // * Constructor
        public Lotus(ISutraContextualizer contextualizer, IReadOnlyPitch pitch) {
            Pitch = pitch.ToPitch();
            Context = contextualizer.Context;
            _roleWeights = new();
        }

        // * LotusRoles Management
        public bool HasRole(LotusRole role) => _roleWeights.ContainsKey(role);
        public double RoleWeight(LotusRole role) => _roleWeights[role];
        public bool RemoveRole(LotusRole role) => _roleWeights.Remove(role);
        public void ResetRoles() => _roleWeights.Clear();
        
        public void AddRole(LotusRole role, double weight) {
            if (HasRole(role)) {
                _roleWeights[role] += weight;
            }
            else {
                _roleWeights.Add(role, weight);
            }
            
        }
    }

}