namespace SineVita.Nelumbo {
    public class LanternThread {
        // * Lantern References
        public required Lantern Antecedent { init; get; }
        public required Lantern Consequent { init; get; }

        public LanternThread(Lantern antecedent, Lantern consequent) {
            Antecedent = antecedent;
            Consequent = consequent;
        }
    }
}