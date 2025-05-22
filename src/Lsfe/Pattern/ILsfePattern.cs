namespace SineVita.Muguet.Nelumbo.Lsfe.Pattern
{
    public interface ILsfePattern<T> : ICloneable
    {
        public bool Matches(ILsfeParsable<T> t) => MatchesExact(t);
        public bool MatchesExact(ILsfeParsable<T> t);
    }
}