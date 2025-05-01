using SineVita.Muguet;
namespace altSineVita.Nelumbo {
    public class LanternThread { // Used to quantitate the transition between two chords
        // * Flames
        public List<List<LotusThread>> Flames { get; set; }

        // * Duet Properties

        // * Constructor
        public LanternThread(Lantern masterLantern, Lantern slaveLantern) {
            Flames = new List<List<LotusThread>>();
            for (int i = 0; i < slaveLantern.Lotuses.Count; i++) {
                Flames.Add(new List<LotusThread>());
                for (int j = 0; j < masterLantern.Lotuses.Count; j++) {
                    var masterLotus = masterLantern.Lotuses[j]; 
                    var slaveLotus = slaveLantern.Lotuses[i];
                    Flames[i].Add(new LotusThread(masterLotus, slaveLotus));
                }
            }
        }

    }
    public class LotusThread {  // ! NOT DONE

        // * Lotus References
        public readonly Lotus Antecedent;
        public readonly Lotus Consequent;
        public PitchInterval Interval { get; set; } // can be manipulated and transformed for analysis

        // * Derived Variables

        public bool IsNegative { get {return Interval.IsNegative;} }
        public bool IsPositive { get {return Interval.IsPositive;} }

        public bool IsDiesisStep { get {return Interval < new MidiPitchInterval(3); } }
        public bool IsThirdsStep { get {
            return new MidiPitchInterval(2) < Interval && Interval < new MidiPitchInterval(5); 
        } }
        public bool IsBalancedStep { get {
            return new MidiPitchInterval(4) < Interval && Interval < new MidiPitchInterval(8); 
        } }
        public bool IsWideStep { get {
            return new MidiPitchInterval(7) < Interval && Interval < new MidiPitchInterval(12); 
        } }
        public bool IsMassiveStep { get {
            return new MidiPitchInterval(11) < Interval;
        } }
    



        // * Constructors
        public LotusThread(Lotus Antecedent, Lotus Consequent) { // ! NOT DONE
            Interval = PitchInterval.CreateInterval(Antecedent.Pitch, Consequent.Pitch, false);
        }
    }
}