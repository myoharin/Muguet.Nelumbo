namespace SineVita.Muguet.Nelumbo.Identity.Movement.CmMovement
{
    public class CmMovementIdentity : Identity
    {
        private CmMovementIdentityEnum _value;
        public CmMovementIdentityEnum EnumValue => _value;
        public CmMovementIdentity(CmMovementIdentityEnum value) {
            _value = value;
        }
        
        public override string ToString() => _value.ToString();
    }
}