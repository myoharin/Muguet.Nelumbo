using SineVita.Muguet.Nelumbo.Lsfe.Pattern.Sutra.MovementIdentity.CmMovement.Internal;
using SineVita.Muguet.Nelumbo.Sutra;

namespace SineVita.Muguet.Nelumbo.Lsfe.Pattern.Sutra.MovementIdentity.CmMovement
{
    public class CmMovementIdentityMatcher :
        IMovementIdentityMatcher<LotusThread>,
        IMovementIdentityMatcher<LotusStrand>
    {
        public CmMovementIdentityMatcher(CmMovementIdentity value) {
            CmMovementIdentity = value;
        }

        // * Properties
        public CmMovementIdentity CmMovementIdentity { init; get; }
        public Identity Identity => CmMovementIdentity;
        
        // * Matches
        public bool Matches(ILsfeParsable<LotusStrand> strand) {
            return CmMovementInternalData.Evaluations[CmMovementIdentity.EnumValue].MatchContains(strand);
        }
        public bool Matches(ILsfeParsable<LotusThread> thread) {
            return CmMovementInternalData.Evaluations[CmMovementIdentity.EnumValue].MatchesExact(thread);
        }
    }
}