using SineVita.Muguet.Nelumbo.Lsfe;

namespace SineVita.Muguet.Nelumbo.Identity
{
    public interface INelumboIdentityMatcher<T>
    {
        public Identity Identity { get; }
        public bool Matches(ILsfeParsable<T> t);
    }
}