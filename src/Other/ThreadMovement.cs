namespace SineVita.Muguet.Nelumbo
{
    public class ThreadMovement
    {
        public ThreadMovement(PitchInterval interval) {
            Interval = interval;
        }
        
        public PitchInterval Interval { init; get; }
        public bool IsGenericLocalMovement => true;
        public bool IsGlm => IsGenericLocalMovement;
        
        
    }
}