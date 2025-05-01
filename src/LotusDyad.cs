using SineVita.Muguet;

namespace SineVita.Nelumbo {
    public class LotusDyad {
        // * Lotus References
        public Lotus Root { init; get; }
        public Lotus Terminal { init; get; }

        public Lotus Bottom { get {return Root;} }
        public Lotus Top { get {return Terminal;} }

        // * Derived Gets
        public PitchInterval Interval { get {
            return PitchInterval.CreateInterval(Root.Pitch, Terminal.Pitch);
        } }

        public LotusDyad(Lotus root, Lotus terminal) {
            Root = root;
            Terminal = terminal;
        }
    }
}