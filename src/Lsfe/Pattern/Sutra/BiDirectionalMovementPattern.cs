using SineVita.Muguet.Nelumbo.Lsfe;
using SineVita.Muguet.Nelumbo.Lsfe.Pattern;
using SineVita.Muguet.Nelumbo.Lsfe.Pattern.Sutra;
using SineVita.Muguet.Nelumbo.Sutra;

namespace SineVita.Muguet.Nelumbo.Lsfe.Pattern.Sutra
{
    public class BiDirectionalMovementPattern : ILsfePatternContainer<ThreadMovement>
    {
        public Tuple<StrictMovementPattern, StrictMovementPattern, StrictMovementPattern> ThreadPatterns;
        
        public object Clone() {
            return new BiDirectionalMovementPattern(ThreadPatterns.Item1.Movement);
        }
        
        public bool MatchesExact(ILsfeParsable<ThreadMovement> t) => false;
        public bool MatchContains(ILsfeParsable<ThreadMovement> t) {
            return ThreadPatterns.Item1.MatchesExact(t) ||
                   ThreadPatterns.Item2.MatchesExact(t) ||
                   ThreadPatterns.Item3.MatchesExact(t);
        }

        public BiDirectionalMovementPattern(GenericLocalMovement movement) {
            this.ThreadPatterns = movement switch {
                GenericLocalMovement.D8 => new(new(GenericLocalMovement.D8), new(GenericLocalMovement.U), new(GenericLocalMovement.U8)),
                GenericLocalMovement.D5 => new(new(GenericLocalMovement.D5), new(GenericLocalMovement.U4), new(GenericLocalMovement.U4)),
                GenericLocalMovement.D4 => new(new(GenericLocalMovement.D4), new(GenericLocalMovement.D4), new(GenericLocalMovement.U5)),
                GenericLocalMovement.U  => new(new(GenericLocalMovement.D8), new(GenericLocalMovement.U), new(GenericLocalMovement.U8)),
                GenericLocalMovement.U4 => new(new(GenericLocalMovement.D5), new(GenericLocalMovement.U4), new(GenericLocalMovement.U4)),
                GenericLocalMovement.U5 => new(new(GenericLocalMovement.D4), new(GenericLocalMovement.D4), new(GenericLocalMovement.U5)),
                GenericLocalMovement.U8 => new(new(GenericLocalMovement.D8), new(GenericLocalMovement.U), new(GenericLocalMovement.U8)),
                
                _                       => new(new(movement), new(movement), new(movement))
            };
        }
        
    }

}