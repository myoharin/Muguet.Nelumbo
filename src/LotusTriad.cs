using SineVita.Muguet;

namespace SineVita.Nelumbo {
    public class LotusTriad {
        // * Lotus References
        public Lotus Root { init; get; }
        public Lotus Median { init; get; }
        public Lotus Terminal { init; get; }

        public Lotus Bottom { get {return Root;} }
        public Lotus Middle { get {return Median;} }
        public Lotus Top { get {return Terminal;} }

        // * Derived Gets
    
        public LotusTriad(Lotus root, Lotus median, Lotus terminal) {
            Root = root;
            Median = median;
            Terminal = terminal;
        }
    }
}