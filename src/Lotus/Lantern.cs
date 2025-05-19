using Caprifolium;
using System.Collections.Generic;

namespace SineVita.Muguet.Nelumbo {
    internal class Lantern {
        // * Object References
        public LanternSutra Sutra { init; get; }

 
        // * Core Variable Management
        public Chord _chord;
        public Chord Chord { get {return this._chord;} }

        // * Analysis DS
        public List<Lotus> Lotuses { get; set; }   
            // contains references to the chord's pitch
            // containsn references to their associated dyad and triad
        public Lonicera<Lotus, LotusDyad> LotusDyads { get; set; }
        public Knautia<Lotus, LotusTriad> LotusTriads { get; set; }

        // * privates
        // private static Func<Lotus, Lotus, LotusDyad>
        // private static Func<Lotus, Lotus, Lotus, LotusTriad>

        // * Constructor
        public Lantern(LanternSutra sutra) {
            Sutra = sutra;
            _chord = new();
            Lotuses = new();
            LotusDyads = new(growth: (r, t) => new LotusDyad(r, t));
            LotusTriads = new(3, growth: (lotuses) => new LotusTriad(lotuses[0], lotuses[1], lotuses[2]));
        }

        // * Add Pitches
        public void Add(Pitch p) { // ! NOT DONE
            _chord.Add(p);

            
        }
        public void Add(List<Pitch> c) {
            foreach(Pitch p in c) {
                Add(p);
            }
        }
        public void Add(Chord c) {
            Add(c.Notes);
        }
    }
}