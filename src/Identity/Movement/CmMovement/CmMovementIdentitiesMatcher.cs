using SineVita.Muguet.Nelumbo.Identity.Movement.CmMovement.Internal;
using SineVita.Muguet.Nelumbo.Lily;
using SineVita.Muguet.Nelumbo.Lsfe;
using SineVita.Muguet.Nelumbo.Sutra;

namespace SineVita.Muguet.Nelumbo.Identity.Movement.CmMovement
{
    public class CmMovementIdentitiesMatcher :
        INelumboIdentitiesMatcher<CmMovementIdentity, LotusThread>,
        INelumboIdentitiesMatcher<CmMovementIdentity, LotusStrand>
    {
        public CmMovementIdentitiesMatcher() { }
        
        // * Matches
        public bool Matches(CmMovementIdentity identity, ILsfeParsable<LotusThread> thread) => CmMovementInternalData.Evaluations[identity.EnumValue].MatchesExact(thread);
        public bool Matches(CmMovementIdentity identity, ILsfeParsable<LotusStrand> strand) => CmMovementInternalData.Evaluations[identity.EnumValue].MatchContains(strand);

        public List<CmMovementIdentity> Matches(ILsfeParsable<LotusStrand> strand) {
            List<CmMovementIdentity> identities = new();
            foreach (var val in Enum.GetValues<CmMovementIdentityEnum>()) {
                if (CmMovementInternalData.Evaluations[val].MatchContains(strand)) {
                    identities.Add(new(val));
                }
            }
            return identities;
        }
        public List<CmMovementIdentity> Matches(ILsfeParsable<LotusThread> thread) {
            List<CmMovementIdentity> identities = new();
            foreach (var val in Enum.GetValues<CmMovementIdentityEnum>()) {
                if (CmMovementInternalData.Evaluations[val].MatchesExact(thread)) {
                    identities.Add(new(val));
                }
            }
            return identities;
        }
    }
}