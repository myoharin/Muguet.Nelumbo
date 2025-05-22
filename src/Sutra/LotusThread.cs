using SineVita.Muguet.Nelumbo.Context;
using SineVita.Muguet.Nelumbo.Lsfe;
using SineVita.Muguet.Nelumbo.Lily;

namespace SineVita.Muguet.Nelumbo.Sutra {
    public class LotusThread
        : ILsfeParsable<LotusThread>, ISutraContextualizer
    {
        // * References
        public Lotus Antecedant { init; get; }
        public Lotus Consequent { init; get; }
        public SutraContext Context => Antecedant.Context;
        
        // * Properties
        public ThreadMovement Movement { init; get; }
        
        // * Constructor
        public LotusThread(Lotus antecedant, Lotus consequent) {
            Antecedant = antecedant;
            Consequent = consequent;
            Movement = new(this);
        }
        
        // * Enumerate Strands
        public List<LotusStrand> EnumerateStrands() {
            var strands = new List<LotusStrand>();
            foreach (var antecedentRole in Antecedant.Roles) {
                foreach (var consequentRole in Consequent.Roles) {
                    strands.Add(new LotusStrand(this, antecedentRole, consequentRole));
                }
            }
            return strands;
        }
        
        // * Has Strand
        public bool HasStrand(LotusRole antecedantRole, ThreadMovement movement, LotusRole conseuqentRole) => HasStrand(conseuqentRole, antecedantRole, movement);
        public bool HasStrand(ThreadMovement movement, LotusRole antecedantRole, LotusRole conseuqentRole) => HasStrand(conseuqentRole, antecedantRole, movement);
        public bool HasStrand(LotusRole antecedantRole, LotusRole conseuqentRole, ThreadMovement movement) {
            return this.Movement.Equals(movement) && HasStrand(antecedantRole, conseuqentRole);
        }
        public bool HasStrand(LotusRole antecedantRole, LotusRole conseuqentRole) {
            return Consequent.HasRole(conseuqentRole) &&
                   Antecedant.HasRole(antecedantRole);
        }
        
        // * Lsfe
        LotusThread ILsfeParsable<LotusThread>.Get() => this;
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
                String.Join(" ", strands.Select(s => $"({LsfeHelper.ToString(s.AntecedantRole)}->{LsfeHelper.ToString(s.ConsequentRole)})"))
            );
        }
    }
}