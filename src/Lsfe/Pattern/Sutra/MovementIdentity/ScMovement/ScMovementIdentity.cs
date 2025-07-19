namespace SineVita.Muguet.Nelumbo.Lsfe.Pattern.Sutra.MovementIdentity.ScMovement
{
    
    public class ScMovementIdentity : Identity
    {
        public ScMovementIdentityEnum EnumValue { init; get; }
        public ScMovementIdentity(ScMovementIdentityEnum value) {
            EnumValue = value;
        }
        
        public override string ToString() => EnumValue.ToString();
    }
}