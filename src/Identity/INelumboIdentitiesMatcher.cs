using SineVita.Muguet.Nelumbo.Lsfe;

namespace SineVita.Muguet.Nelumbo.Identity
{
    public interface INelumboIdentitiesMatcher<TIdentity, TMatchMedium> 
        where TIdentity : Identity
    {
        public Type IdentityType => typeof(TIdentity);
        public bool Matches(TIdentity identity, ILsfeParsable<TMatchMedium> t);
    }
}