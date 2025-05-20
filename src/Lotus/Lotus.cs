using SineVita.Muguet;

namespace SineVita.Muguet.Nelumbo {
    public class Lotus {
        // * Object References
        public Lantern Lantern { init; get; }
        public SutraContext Context => Lantern.Context;
        public Pitch Pitch { init; get; }

        // * Variables
        private List<LotusRole> _roles;
        public IReadOnlyList<LotusRole> Roles => _roles.AsReadOnly();

        // * Constructor
        public Lotus(Pitch pitch, Lantern originLantern) {
            Pitch = pitch;
            Lantern = originLantern;
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