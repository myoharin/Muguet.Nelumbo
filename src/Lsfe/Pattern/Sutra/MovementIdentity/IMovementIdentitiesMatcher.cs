using SineVita.Muguet.Nelumbo.Lsfe;

namespace SineVita.Muguet.Nelumbo.Lsfe.Pattern.Sutra.MovementIdentity
{
    public interface IMovementIdentitiesMatcher<TIdentity, TMatchMedium> 
        where TIdentity : Identity
    {
        public Type IdentityType => typeof(TIdentity);
        public bool Matches(TIdentity identity, ILsfeParsable<TMatchMedium> t);
        public List<TIdentity> Matches(ILsfeParsable<TMatchMedium> t);
    }
}