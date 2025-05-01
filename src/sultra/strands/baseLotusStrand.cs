using SineVita.Muguet;
using SineVita.Nelumbo;

namespace SineVita.Muguet {
    public abstract class LotusStrand {
        // * Lotus References
        public required Lotus Antecedent { init; get; }
        public required Lotus Consequent { init; get; }

        // * Constructor 
        protected LotusStrand(Lotus antecedent, Lotus consequent) {
            Antecedent = antecedent;
            Consequent = consequent;
        }
    }

}