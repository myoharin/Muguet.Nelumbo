using SineVita.Muguet.Nelumbo.Lsfe.Pattern.Sutra.MovementIdentity.DsiMovement.Internal;
using SineVita.Muguet.Nelumbo.Sutra;

namespace SineVita.Muguet.Nelumbo.Lsfe.Pattern.Sutra.MovementIdentity.DsiMovement
{
    public class DsiMovementIdentityMatcher :
        IMovementIdentityMatcher<LotusThread>,
        IMovementIdentityMatcher<LotusStrand>
    {
        public DsiMovementIdentityMatcher(DsiMovementIdentity value) {
            DsiMovementIdentity = value;
        }

        // * Properties
        public DsiMovementIdentity DsiMovementIdentity { init; get; }
        public Identity Identity => DsiMovementIdentity;
        
        // * Matches
        public bool Matches(ILsfeParsable<LotusStrand> strand) {
            if (!strand.Get().Movement.IsGlm) return false;
            DsiMovementIdentityEnum identity;
            DsiMovementInternalData.Evaluate(
                strand.Get().AntecedantRole,
                strand.Get().Movement.GenericLocalMovement,
                strand.Get().AntecedantRole,
                out identity
                );
            return identity == DsiMovementIdentity.EnumValue;
        }
        public bool Matches(ILsfeParsable<LotusThread> thread) {
            if (!thread.Get().Movement.IsGlm) return false;
            var movement = thread.Get().Movement.GenericLocalMovement;
            foreach (var consequentRole in thread.Get().Consequent.Roles) {
                foreach (var antecedantRole in thread.Get().Antecedant.Roles) {
                    DsiMovementIdentityEnum identity;
                    DsiMovementInternalData.Evaluate(
                        consequentRole,
                        movement,
                        antecedantRole,
                        out identity
                    );
                    if (identity == DsiMovementIdentity.EnumValue)
                        return true;
                }
            }

            return false;
        }
    }
}