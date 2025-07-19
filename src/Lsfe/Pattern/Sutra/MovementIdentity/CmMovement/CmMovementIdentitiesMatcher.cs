using SineVita.Muguet.Nelumbo.Lsfe.Pattern.Sutra.MovementIdentity.CmMovement.Internal;
using SineVita.Muguet.Nelumbo.Sutra;

namespace SineVita.Muguet.Nelumbo.Lsfe.Pattern.Sutra.MovementIdentity.CmMovement
{
    public class CmMovementIdentitiesMatcher :
        IMovementIdentitiesMatcher<CmMovementIdentity, LotusThread>,
        IMovementIdentitiesMatcher<CmMovementIdentity, LotusStrand>
    {
        public bool Matches(CmMovementIdentity identity, ILsfeParsable<LotusStrand> strand) {
            return CmMovementInternalData.Evaluations[identity.EnumValue].MatchContains(strand);
        }
        
        public bool Matches(CmMovementIdentity identity, ILsfeParsable<LotusThread> thread) {
            return CmMovementInternalData.Evaluations[identity.EnumValue].MatchesExact(thread);
        }
        
        public List<CmMovementIdentity> Matches(ILsfeParsable<LotusStrand> strand) {
            List<CmMovementIdentity> identities = new();
            foreach (var val in Enum.GetValues<CmMovementIdentityEnum>())
                if (CmMovementInternalData.Evaluations[val].MatchContains(strand))
                    identities.Add(new CmMovementIdentity(val));

            return identities;
        }

        public List<CmMovementIdentity> Matches(ILsfeParsable<LotusThread> thread) {
            List<CmMovementIdentity> identities = new();
            foreach (var val in Enum.GetValues<CmMovementIdentityEnum>())
                if (CmMovementInternalData.Evaluations[val].MatchesExact(thread))
                    identities.Add(new CmMovementIdentity(val));

            return identities;
        }
    }
}