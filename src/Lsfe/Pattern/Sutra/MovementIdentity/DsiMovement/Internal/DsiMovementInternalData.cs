
using SineVita.Muguet.Nelumbo.Lily;
using SineVita.Muguet.Nelumbo.Lsfe.Pattern.Sutra;
using SineVita.Muguet.Nelumbo.Sutra;

namespace SineVita.Muguet.Nelumbo.Lsfe.Pattern.Sutra.MovementIdentity.DsiMovement.Internal
{
    internal static class DsiMovementInternalData
    {
        
        static IReadOnlyList<DsiMovementIdentityEnum> _dsiMovementIdentityOrder = new List<DsiMovementIdentityEnum>() {
            DsiMovementIdentityEnum.AUG0,
            DsiMovementIdentityEnum.AUG0,
            DsiMovementIdentityEnum.AUG1,
            DsiMovementIdentityEnum.AUG1,
            DsiMovementIdentityEnum.AUG2,
            DsiMovementIdentityEnum.AUG2,
            DsiMovementIdentityEnum.AUG3,
            DsiMovementIdentityEnum.AUG3,
            DsiMovementIdentityEnum.AUG0,
            DsiMovementIdentityEnum.AUG0,
            DsiMovementIdentityEnum.AUG1,
            DsiMovementIdentityEnum.AUG1,
            DsiMovementIdentityEnum.AUG3,
            DsiMovementIdentityEnum.AUG3,
            DsiMovementIdentityEnum.AUG0,
            DsiMovementIdentityEnum.AUG0,
            DsiMovementIdentityEnum.AUG2,
            DsiMovementIdentityEnum.AUG2,
            DsiMovementIdentityEnum.AUG3,
            DsiMovementIdentityEnum.AUG3,
            DsiMovementIdentityEnum.DIM0,
            DsiMovementIdentityEnum.DIM2,
            DsiMovementIdentityEnum.DIM0,
            DsiMovementIdentityEnum.DIM2,
            DsiMovementIdentityEnum.DIM2,
            DsiMovementIdentityEnum.DIM1,
            DsiMovementIdentityEnum.DIM2,
            DsiMovementIdentityEnum.DIM1,
            DsiMovementIdentityEnum.DIM2,
            DsiMovementIdentityEnum.DIM1,
            DsiMovementIdentityEnum.DIM2,
            DsiMovementIdentityEnum.DIM1,
            DsiMovementIdentityEnum.DIM1,
            DsiMovementIdentityEnum.DIM0,
            DsiMovementIdentityEnum.DIM1,
            DsiMovementIdentityEnum.DIM0,
            DsiMovementIdentityEnum.DIM0,
            DsiMovementIdentityEnum.DIM2,
            DsiMovementIdentityEnum.DIM0,
            DsiMovementIdentityEnum.DIM2,
        };
        public static bool Evaluate(LotusRole antecedent, GenericLocalMovement movement,
            LotusRole consequent, out DsiMovementIdentityEnum identity) {
            // evaluation based on LINK: https://docs.google.com/spreadsheets/d/17E1ty6WEtYoX4hQ8Z9mAV7nzxbON1kXQ_RuXJNE99bE/edit?gid=1414051925#gid=1414051925
            
            // reduction
            movement = new BiDirectionalGlmPattern(movement).Lowest.Movement;
            identity = 0; // default value
            
            // calculation
            int sum = 0;

            switch (consequent) {
                case LotusRole.SD:  sum += 0; break;
                case LotusRole.Sm3: sum += 1; break;
                case LotusRole.SM3: sum += 2; break;
                case LotusRole.ST:  sum += 3; break;
                default: return false;
            }
            
            switch (movement) {
                case GenericLocalMovement.D4: sum += 0; break;
                case GenericLocalMovement.D5: sum += 4; break;
                case GenericLocalMovement.DL: sum += 8; break;
                case GenericLocalMovement.U:  sum += 12; break;
                case GenericLocalMovement.UL:  sum += 16; break;
                default:                      return false;
            }
            
            switch (antecedent) {
                case LotusRole.sA:  sum += 0; break;
                case LotusRole.sD: sum += 20; break;
                default:            return false;
            }

            identity = _dsiMovementIdentityOrder[sum];
            return true;
        }


    }
}