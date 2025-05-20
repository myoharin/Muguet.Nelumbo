namespace SineVita.Muguet.Nelumbo.Internal
{
    internal class LotusDyad
    {
        public LotusDyad(Lotus root, Lotus terminal) {
            Root = root;
            Terminal = terminal;
            _interval = PitchInterval.CreateInterval(Root.Pitch, Terminal.Pitch, true);
        }

        // * Lotus References
        public Lotus Root { init; get; }
        public Lotus Terminal { init; get; }
        private PitchInterval _interval { init; get; }
        public IReadOnlyPitchInterval Interval => _interval;

        public IReadOnlyPitchInterval ReducedInterval {
            get {
                var interval = (PitchInterval)_interval.Clone();
                while (interval > PitchInterval.Octave) {
                    interval.Decrement(PitchInterval.Octave);
                }
                return interval;
            }
        }

        // * Derived Gets
        public Lotus Bottom => Root;
        public Lotus Top => Terminal;
    }
}