using SineVita.Muguet.Nelumbo.Identity.Movement.CmMovement.Internal;
using SineVita.Muguet.Nelumbo.Lily;
using SineVita.Muguet.Nelumbo.Lsfe;
using SineVita.Muguet.Nelumbo.Lsfe.Pattern;
using SineVita.Muguet.Nelumbo.Lsfe.Pattern.Sutra;
using SineVita.Muguet.Nelumbo.Sutra;

namespace SineVita.Muguet.Nelumbo.Identity.Movement.CmMovement
{
    public class CmMovementIdentityMatcher :
        INelumboIdentityMatcher<LotusThread>,
        INelumboIdentityMatcher<LotusStrand>
    {
        // * Properties
        public CmMovementIdentity CmMovementIdentity { init; get; }
        public Identity Identity => CmMovementIdentity;

        public CmMovementIdentityMatcher(CmMovementIdentity value) {
            CmMovementIdentity = value;
        }
        
        // * Matches
        public bool Matches(ILsfeParsable<LotusThread> thread) => CmMovementInternalData.Evaluations[CmMovementIdentity.EnumValue].MatchesExact(thread);
        public bool Matches(ILsfeParsable<LotusStrand> strand) => CmMovementInternalData.Evaluations[CmMovementIdentity.EnumValue].MatchContains(strand);
        
    }
    }