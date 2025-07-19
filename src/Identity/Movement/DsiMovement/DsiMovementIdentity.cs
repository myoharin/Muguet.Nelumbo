namespace SineVita.Muguet.Nelumbo.Identity.Movement.DsiMovement
{
    public class DsiMovementIdentity : Identity
    {
        private DsiMovementIdentityEnum _value;
        public DsiMovementIdentityEnum EnumValue => _value;
        public DsiMovementIdentity(DsiMovementIdentityEnum value) {
            _value = value;
        }
        
        public override string ToString() => _value.ToString();
    }
}