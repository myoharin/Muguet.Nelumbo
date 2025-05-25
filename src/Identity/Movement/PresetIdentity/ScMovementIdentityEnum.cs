namespace SineVita.Muguet.Nelumbo.Identity.Movement
{
    public enum ScMovementIdentityEnum {
        m4m,
        m5m,
        m4M,
        m5M,
        M4m,
        M5m,
        M4M,
        M5M
    }
    
    public class ScMovementIdentity : Identity
    {
        private ScMovementIdentityEnum _value;
        public ScMovementIdentityEnum EnumValue => _value;
        public ScMovementIdentity(ScMovementIdentityEnum value) {
            _value = value;
        }
        
        public override string ToString() => _value.ToString();
    }
}