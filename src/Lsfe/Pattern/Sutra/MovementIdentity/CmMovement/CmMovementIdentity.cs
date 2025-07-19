using SineVita.Muguet.Nelumbo.Lsfe.Pattern.Sutra.MovementIdentity.CmMovement.Internal;

namespace SineVita.Muguet.Nelumbo.Lsfe.Pattern.Sutra.MovementIdentity.CmMovement
{
    public class CmMovementIdentity : Identity
    {
        // internal values
        internal CmMovementIdentity(CmMovementIdentityEnum value) => EnumValue = value;
        internal CmMovementIdentityEnum EnumValue { init; get; }
        
        public override string ToString() {
            return EnumValue.ToString();
        }
        
        // PseudoEnum
        public static CmMovementIdentity mDm3m => new(CmMovementIdentityEnum.mDm3m);
        public static CmMovementIdentity mDM3m => new(CmMovementIdentityEnum.mDM3m); 
        public static CmMovementIdentity mUm3m => new(CmMovementIdentityEnum.mUm3m); 
        public static CmMovementIdentity mUM3m => new(CmMovementIdentityEnum.mUM3m); 
        public static CmMovementIdentity mDm3M => new(CmMovementIdentityEnum.mDm3M); 
        public static CmMovementIdentity mDM3M => new(CmMovementIdentityEnum.mDM3M); 
        public static CmMovementIdentity mUm3M => new(CmMovementIdentityEnum.mUm3M); 
        public static CmMovementIdentity mUM3M => new(CmMovementIdentityEnum.mUM3M); 
        public static CmMovementIdentity MDm3m => new(CmMovementIdentityEnum.MDm3m); 
        public static CmMovementIdentity MDM3m => new(CmMovementIdentityEnum.MDM3m); 
        public static CmMovementIdentity MUm3m => new(CmMovementIdentityEnum.MUm3m); 
        public static CmMovementIdentity MUM3m => new(CmMovementIdentityEnum.MUM3m); 
        public static CmMovementIdentity MDm3M => new(CmMovementIdentityEnum.MDm3M); 
        public static CmMovementIdentity MDM3M => new(CmMovementIdentityEnum.MDM3M); 
        public static CmMovementIdentity MUm3M => new(CmMovementIdentityEnum.MUm3M); 
        public static CmMovementIdentity MUM3M => new(CmMovementIdentityEnum.MUM3M);
    }
}