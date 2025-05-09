using SineVita.Muguet;

namespace SineVita.Muguet.Nelumbo {
    internal class LotusDyad {
        // * Lotus References
        public Lotus Root { init; get; }
        public Lotus Terminal { init; get; }

        // * Derived Gets
        public Lotus Bottom { get {return this.Root;} }
        public Lotus Top { get {return this.Terminal;} }
        public PitchInterval Interval { get {
            return PitchInterval.CreateInterval(this.Root.Pitch, this.Terminal.Pitch, true);
        } }

        public LotusDyad(Lotus root, Lotus terminal) {
            Root = root;
            Terminal = terminal;
        }

        public void AssignRoles() {
            
        }
    }
}