using SineVita.Muguet.Nelumbo.Context;
using SineVita.Muguet.Nelumbo.Lily;
using SineVita.Muguet.Nelumbo.Sutra;
using Caprifolium;

namespace SineVita.Muguet.Nelumbo
{
    public class NelumboAnalyser : ISutraContextualizer
    {   
        // * Context
        public SutraContext Context { init; get; }
        
        // * Constructor
        public NelumboAnalyser(ISutraContextualizer? contextualizer = null) {
            Context = contextualizer != null ? contextualizer.Context : new SutraContext();
            _sutra = new(this);
        }
        
        // * Sutra
        private LanternSutra _sutra;
        public LanternSutra Sutra => _sutra;

        public void AppendLantern(IReadOnlyChord chord) {
            _sutra.AppendLantern(chord);
        }
        
        public IReadOnlyList<LanternThread> GetSutraConsecutiveThreads() => _sutra.GetConsecutiveThreads();
        public Lonicera<Lantern, LanternThread> GetAllSutraLonicera() => _sutra.GetLonicera();
        public IReadOnlyList<LanternThread> GetAllThreads(bool onlyConsecutive) => _sutra.GetAllThreads(onlyConsecutive);
    }
}