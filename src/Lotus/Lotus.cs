using SineVita.Muguet;

namespace SineVita.Muguet.Nelumbo {

    internal class Lotus {
        // * Object References
        public Lantern Lantern { init; get; }
        public Pitch Pitch { init; get; }

        // * Variables
        public List<LotusRole> _roles;

        // * Derived Gets
        


        // * Constructor
        public Lotus(Pitch pitch, Lantern originLantern) {
            Pitch = pitch;
            Lantern = originLantern;
            _roles = new();
        }

        // * LotusRoles Managment
        public bool HasRole(LotusRole role) {
            return _roles.Contains(role);
        }
        public void AddRole(LotusRole role) {
            if (!HasRole(role)) {
                _roles.Add(role);
            }
        }
        public bool RemoveRole(LotusRole role) {
            return _roles.Remove(role);
        }
        public void ResetRoles() {
            _roles.Clear();
        }
     



    }

}