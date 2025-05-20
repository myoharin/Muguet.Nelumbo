namespace SineVita.Muguet.Nelumbo {
    public class LanternSutra {
        private NelumboAnalyser _analyser;
        private List<Lantern> _lanterns;
        public SutraContext Context => _analyser.Context;

        public LanternSutra(NelumboAnalyser analyser) {
            _lanterns = new();
            _analyser = analyser;
        }
    }
}