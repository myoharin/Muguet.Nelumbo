using SineVita.Muguet.Nelumbo.Context;

namespace SineVita.Muguet.Nelumbo.Lily {
    public class Lantern : ISutraContextualizer {
        // * Object References
        public SutraContext Context { init; get; }

        // * Core Variable Management
        private Chord _chord;
        public IReadOnlyChord Chord => _chord.Clone();
        public List<Lotus> Lotuses { get; set; }
        
        // * Derived Gets
        public int Count => Lotuses.Count;

        // * Constructor
        public Lantern(ISutraContextualizer contextualizer, IReadOnlyChord chord) {
            Context = contextualizer.Context;
            Lotuses = new();
            _chord = new();
            SetChord(chord);
        }

        // * Chord
        public void SetChord(IReadOnlyChord readOnlyChord) {
            _chord = readOnlyChord.ToChord();
            foreach (var pitch in _chord.Notes) {
                Lotuses.Add(new Lotus(this, pitch));
            }
            AssignLotusRoles();
        }
        
        // * Call Analysis
        private bool AssignLotusRoles() => Context.AssignLotusRoles(Lotuses);
    }
}