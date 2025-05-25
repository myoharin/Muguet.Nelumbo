namespace SineVita.Muguet.Nelumbo.Identity.Movement
{
    public enum DsiMovementIdentityEnum
    {
        DIM0,
        DIM1,
        DIM2,

        AUG0,
        AUG1,
        AUG2,
        AUG3
    }
    
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