using SineVita.Muguet.Nelumbo.Context;
using SineVita.Muguet.Nelumbo.Lsfe;
using SineVita.Muguet.Nelumbo.Lily;

namespace SineVita.Muguet.Nelumbo.Sutra {
    public class LotusThread
        : ILsfeParsable<LotusThread>, ISutraContextualizer
    {
        // * References
        public Lotus Antecedent { init; get; }
        public Lotus Consequent { init; get; }
        public SutraContext Context => Antecedent.Context;
        
        // * Properties
        public ThreadMovement Movement { init; get; }
        
        // * Constructor
        public LotusThread(Lotus antecedent, Lotus consequent) {
            Antecedent = antecedent;
            Consequent = consequent;
            Movement = new(this);
        }
        
        // * Enumerate Strands
        public List<LotusStrand> EnumerateStrands() {
            var strands = new List<LotusStrand>();
            foreach (var antecedentRole in Antecedent.Roles) {
                foreach (var consequentRole in Consequent.Roles) {
                    strands.Add(new LotusStrand(this, antecedentRole, consequentRole));
                }
            }
            return strands;
        }
        
        // * Has Strand
        public bool HasStrand(LotusRole conseuqentRole, ThreadMovement movement, LotusRole antecedantRole) => HasStrand(conseuqentRole, antecedantRole, movement);
        public bool HasStrand(LotusRole conseuqentRole, LotusRole antecedantRole, ThreadMovement movement) {
            return this.Movement.Equals(movement) &&
                   Consequent.HasRole(conseuqentRole) &&
                   Antecedent.HasRole(antecedantRole);
        }
        
        // * Lsfe
        public string ToLsfe() => ToLsfeTupletForm();
        public string ToLsfeCnfForm() {
            // [LotusStrand] (&& [LotusStrand])*
            var strands = EnumerateStrands();
            return string.Join(" && ", strands.Select(strand => strand.ToLsfe()));
        }
        public string ToLsfeTupletForm() {
            // [Movement] (\([Antecedent LotusRole] -> [Consequent LotusRole]\))+
            var strands = EnumerateStrands();
            var movementStr = $"{Movement.ToLsfe()} ";
            return string.Concat(
                movementStr,
                String.Join(" ", strands.Select(s => $"({s.AntecedentRole}->{s.ConsequentRole})"))
            );
        }
    }
}