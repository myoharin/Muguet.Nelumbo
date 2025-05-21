using SineVita.Muguet.Nelumbo.Lily;
using SineVita.Muguet.Nelumbo.Lsfe;

namespace SineVita.Muguet.Nelumbo.Sutra {
    public class LotusStrand : ILsfeParsable<LotusStrand> {
        // * References
        public LotusThread Thread { init; get; }
        public Lotus Antecedent => Thread.Antecedent;
        public Lotus Consequent => Thread.Consequent;
        public ThreadMovement Movement => Thread.Movement;
        
        // * Core
        public LotusRole AntecedentRole { init; get; }
        public LotusRole ConsequentRole { init; get; }

        // * Constructor 
        public LotusStrand(LotusThread thread, LotusRole antecedantRole, LotusRole consequentRole) {
            Thread = thread;
            AntecedentRole = antecedantRole;
            ConsequentRole = consequentRole;
        }
        
        // * Methods
        public string ToLsfe() => $"{LsfeHelper.ToString(AntecedentRole)} {Movement} {LsfeHelper.ToString(ConsequentRole)}";
        public override string ToString() => ToLsfe();
    }
}