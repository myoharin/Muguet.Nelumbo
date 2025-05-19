using SineVita.Muguet;

namespace SineVita.Muguet.Nelumbo {
    internal class LotusTriad {
        // * Lotus References
        public Lotus Root { init; get; }
        public Lotus Median { init; get; }
        public Lotus Terminal { init; get; }

        public Lotus Bottom { get {return this.Root;} }
        public Lotus Middle { get {return this.Median;} }
        public Lotus Top { get {return this.Terminal;} }

        public PitchInterval intervalTM { get {
            return PitchInterval.CreateInterval(this.Median.Pitch, this.Terminal.Pitch, true);
        } }
        public PitchInterval intervalTR { get {
            return PitchInterval.CreateInterval(this.Root.Pitch, this.Terminal.Pitch, true);
        } }
        public PitchInterval intervalMR { get {
            return PitchInterval.CreateInterval(this.Root.Pitch, this.Median.Pitch, true);
        } }

        // * Derived Gets
    
        public LotusTriad(Lotus root, Lotus median, Lotus terminal) {
            Root = root;
            Median = median;
            Terminal = terminal;
        }
        public void AssignRoles() {

        }
        
    }
}