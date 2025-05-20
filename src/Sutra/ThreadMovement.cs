using SineVita.Muguet.Nelumbo.LSFE;

namespace SineVita.Muguet.Nelumbo
{
    public class ThreadMovement : ILSFEParsable<ThreadMovement>
    {
        public ThreadMovement(LotusThread thread) {
            Thread = thread;
            Interval = PitchInterval.CreateInterval(thread.Antecedent.Pitch, thread.Consequent.Pitch, true);
            GenericLocalMovement = GenericLocalMovement.NA;
            foreach (var movement in Enum.GetValues<GenericLocalMovement>()) {
                if (Context[movement](Interval)) {
                    GenericLocalMovement = movement;
                    break;
                }
            }
        }
        
        // * References
        public LotusThread Thread { init; get; }
        public Lotus Antecedent => Thread.Antecedent;
        public Lotus Consequent => Thread.Consequent;
        public SutraContext Context => Thread.Antecedent.Context;
        
        // * Properties
        public PitchInterval Interval { init; get; }
        public GenericLocalMovement GenericLocalMovement { init; get; }
        
        public bool IsGlm => IsGenericLocalMovement;
        public bool IsGenericLocalMovement => GenericLocalMovement != GenericLocalMovement.NA;
        
        // * LSFE
        public string ToLSFE() {
            return IsGenericLocalMovement
                ? GenericLocalMovement.ToString()
                : Interval.ToString() ?? ""; // TODO get rid of null ref safeguard
        }
    }
}