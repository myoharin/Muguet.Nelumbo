using SineVita.Muguet.Nelumbo.Lsfe.Pattern.Sutra.MovementIdentity.DsiMovement.Internal;

namespace SineVita.Muguet.Nelumbo.Lsfe.Pattern.Sutra.MovementIdentity.DsiMovement
{
    public class DsiMovementIdentity : Identity
    {
        // internals
        internal DsiMovementIdentityEnum EnumValue { init; get; }
        internal DsiMovementIdentity(DsiMovementIdentityEnum enumValue) => EnumValue = enumValue;
        
        public override string ToString() => EnumValue.ToString();
        
        // Pseudo Enum
        public static DsiMovementIdentity DIM0 => new(DsiMovementIdentityEnum.DIM0);
        public static DsiMovementIdentity DIM1 => new(DsiMovementIdentityEnum.DIM1);
        public static DsiMovementIdentity DIM2 => new(DsiMovementIdentityEnum.DIM2);

        public static DsiMovementIdentity AUG0 => new(DsiMovementIdentityEnum.AUG0);
        public static DsiMovementIdentity AUG1 => new(DsiMovementIdentityEnum.AUG1);
        public static DsiMovementIdentity AUG2 => new(DsiMovementIdentityEnum.AUG2);
        public static DsiMovementIdentity AUG3 => new(DsiMovementIdentityEnum.AUG3);
    }
}