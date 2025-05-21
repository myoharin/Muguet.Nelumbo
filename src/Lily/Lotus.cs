using SineVita.Muguet;
using SineVita.Muguet.Nelumbo.Context;

namespace SineVita.Muguet.Nelumbo.Lily {
    public class Lotus : ISutraContextualizer {
        // * Object References
        public SutraContext Context { init; get; }
        public Pitch Pitch { init; get; }

        // * Variables
        private List<LotusRole> _roles;
        public IReadOnlyList<LotusRole> Roles => _roles.AsReadOnly();

        // * Constructor
        public Lotus(ISutraContextualizer contextualizer, IReadOnlyPitch pitch) {
            Pitch = pitch.ToPitch();
            Context = contextualizer.Context;
            _roles = new();
        }

        // * LotusRoles Managment
        public bool HasRole(LotusRole role) => _roles.Contains(role);
        public void AddRole(LotusRole role) {
            if (!HasRole(role)) _roles.Add(role);
        }
        public bool RemoveRole(LotusRole role) => _roles.Remove(role);
        public void ResetRoles() => _roles.Clear();
     



    }

}