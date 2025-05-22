namespace SineVita.Muguet.Nelumbo.Lsfe.Pattern
{
    public interface ILsfePatternContainer<T> : ILsfePattern<T>
    {
        public bool MatchContains(ILsfeParsable<T> t);
    }
}