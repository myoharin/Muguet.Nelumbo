namespace SineVita.Muguet.Nelumbo.Lsfe.Pattern
{
    public interface ILsfePattern<T>
    {
        public bool MatchesExact(ILsfeParsable<T> t);
        public bool MatchIn(ILsfeParsable<T> t);
        public bool MatchContain(ILsfeParsable<T> t);
    }
}