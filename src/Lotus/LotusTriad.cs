namespace SineVita.Muguet.Nelumbo
{
    public class LotusTriad // may be a redundant class
    {
        // * Derived Gets

        public LotusTriad(Lotus root, Lotus median, Lotus terminal) {
            Root = root;
            Median = median;
            Terminal = terminal;
        }

        // * Lotus References
        public Lotus Root { init; get; }
        public Lotus Median { init; get; }
        public Lotus Terminal { init; get; }

        public Lotus Bottom => Root;
        public Lotus Middle => Median;
        public Lotus Top => Terminal;

        public PitchInterval intervalTM => PitchInterval.CreateInterval(Median.Pitch, Terminal.Pitch, true);
        public PitchInterval intervalTR => PitchInterval.CreateInterval(Root.Pitch, Terminal.Pitch, true);
        public PitchInterval intervalMR => PitchInterval.CreateInterval(Root.Pitch, Median.Pitch, true);

        public void AssignRoles() { }
    }
}