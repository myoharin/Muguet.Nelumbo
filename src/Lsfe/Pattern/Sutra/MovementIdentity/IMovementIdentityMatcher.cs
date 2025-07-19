using SineVita.Muguet.Nelumbo.Lsfe;

namespace SineVita.Muguet.Nelumbo.Lsfe.Pattern.Sutra.MovementIdentity
{
    public interface IMovementIdentityMatcher<T>
    {
        public Identity Identity { get; }
        public bool Matches(ILsfeParsable<T> t);
    }
}