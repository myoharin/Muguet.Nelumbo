using SineVita.Muguet.Nelumbo.Internal;

namespace SineVita.Muguet.Nelumbo
{
    public class NelumboAnalyser
    {
        public SutraContext Context { init; get; }
        private LanternSutra _sutra;

        public NelumboAnalyser(SutraContext? context = null) {
            Context = context ?? new();
            _sutra = new(this);
        }
    }
}