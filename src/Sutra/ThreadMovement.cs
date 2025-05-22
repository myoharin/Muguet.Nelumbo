using SineVita.Muguet.Nelumbo.Context;
using SineVita.Muguet.Nelumbo.Lsfe;
using SineVita.Muguet.Nelumbo.Lily;

namespace SineVita.Muguet.Nelumbo.Sutra
{
    public class ThreadMovement : ILsfeParsable<ThreadMovement>
    {
        // * Constructor
        public ThreadMovement(LotusThread thread) {
            Thread = thread;
            Interval = PitchInterval.CreateInterval(thread.Antecedant.Pitch, thread.Consequent.Pitch, true);
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
        public Lotus Antecedent => Thread.Antecedant;
        public Lotus Consequent => Thread.Consequent;
        public SutraContext Context => Thread.Antecedant.Context;
        
        // * Properties
        public PitchInterval Interval { init; get; }
        public GenericLocalMovement GenericLocalMovement { init; get; }
        
        public bool IsGlm => IsGenericLocalMovement;
        public bool IsGenericLocalMovement => GenericLocalMovement != GenericLocalMovement.NA;
        
        // * Equatable
        public override bool Equals(object? obj) {
            if (obj == null) return this == null;
            if (obj is ThreadMovement movement) {
                return (GenericLocalMovement == movement.GenericLocalMovement
                        && GenericLocalMovement != GenericLocalMovement.NA)
                        || Interval == movement.Interval;
            }
            return false;
        }
        public override int GetHashCode() {
            return 103 * GenericLocalMovement.GetHashCode() + 71 * Interval.GetHashCode();
        }
        
        // * LSFE
        ThreadMovement ILsfeParsable<ThreadMovement>.Get() => this;
        public string ToLsfe() {
            return IsGenericLocalMovement
                ? GenericLocalMovement.ToString()
                : Interval.ToString() ?? ""; // TODO get rid of null ref safeguard
        }
        public override string ToString() => ToLsfe();
    }
}