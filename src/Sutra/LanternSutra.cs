using SineVita.Muguet.Nelumbo.Context;
using SineVita.Muguet.Nelumbo.Lily;
using Caprifolium;

namespace SineVita.Muguet.Nelumbo.Sutra {
    public class LanternSutra : ISutraContextualizer {
        // * Contextualizer
        public SutraContext Context { init; get; }

        public LanternSutra(ISutraContextualizer contextualizer) {
            _lanterns = new();
            Context = contextualizer.Context;
        }
        
        // * Sutra
        private List<Lantern> _lanterns;
        public LanternThread GetThread(int index1, int index2) {
            return new LanternThread(_lanterns[index1], _lanterns[index2]);
        }
        
        public void AppendLantern(IReadOnlyChord chord) {
            _lanterns.Add(new Lantern(Context, chord));
        }
        
        public IReadOnlyList<LanternThread> GetConsecutiveThreads() {
            var returnList = new List<LanternThread>();
            for (int i = 1; i < _lanterns.Count; ++i) {
                returnList.Add(new LanternThread(_lanterns[i - 1], _lanterns[i]));
            }
            return returnList;
        }
        public IReadOnlyList<LanternThread> GetAllThreads(bool onlyConsecutive) {
            return onlyConsecutive 
                ? GetConsecutiveThreads() 
                : GetLonicera().Links; 
        } 
        public Lonicera<Lantern, LanternThread> GetLonicera() {
            var lonicera = new Lonicera<Lantern, LanternThread>((ant, con) => new LanternThread(ant, con));
            lonicera.AddRange(_lanterns);
            lonicera.GrowAll();
            return lonicera;
        }
        
    }
}