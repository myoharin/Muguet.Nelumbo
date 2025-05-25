using SineVita.Muguet.Nelumbo.Lily;
using SineVita.Muguet.Nelumbo.Lsfe;

namespace SineVita.Muguet.Nelumbo.Sutra {
    public class LotusStrand : ILsfeParsable<LotusStrand> {
        // * References
        public LotusThread Thread { init; get; }
        public Lotus Antecedent => Thread.Antecedant;
        public Lotus Consequent => Thread.Consequent;
        public ThreadMovement Movement => Thread.Movement;
        
        // * Core
        public LotusRole AntecedantRole { init; get; }
        public LotusRole ConsequentRole { init; get; }
        public double Weight { init; get; }

        // * Constructor 
        public LotusStrand(LotusThread thread, LotusRole antecedantRole, LotusRole consequentRole) {
            Thread = thread;
            AntecedantRole = antecedantRole;
            ConsequentRole = consequentRole;
            Weight = Thread.Context.CalculateStrandWeight(
                Antecedent.RoleWeight(AntecedantRole),
                Consequent.RoleWeight(ConsequentRole)
            );
        }
        
        // * Lsfe
        LotusStrand ILsfeParsable<LotusStrand>.Get() => this;
        public string ToLsfe() => $"{LsfeHelper.ToShortString(AntecedantRole)} {Movement} {LsfeHelper.ToShortString(ConsequentRole)}";
        public override string ToString() => ToLsfe();
    }
}