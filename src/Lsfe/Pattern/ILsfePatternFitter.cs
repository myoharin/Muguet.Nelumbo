namespace SineVita.Muguet.Nelumbo.Lsfe.Pattern
{
    public interface ILsfePatternFitter<T> : ILsfePattern<T>
    {
        public bool MatchesIn(ILsfeParsable<T> t);
    }
}