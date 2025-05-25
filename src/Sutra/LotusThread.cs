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
        public List<LotusStrand> EnumerateStrands(double? weightThreshold = null) {
            var strands = new List<LotusStrand>();
            var threshold = weightThreshold ?? Context.StrandWeightThreshold;
            foreach (var antecedentRole in Antecedant.Roles) {
                foreach (var consequentRole in Consequent.Roles) {
                    var strand = new LotusStrand(this, antecedentRole, consequentRole);
                    if (strand.Weight >= threshold) strands.Add(strand);
                }
            }
            return strands;
        }
        
        // * Has Strand
        public bool HasStrand(LotusRole antecedentRole, ThreadMovement movement, LotusRole consequentRole, double? weightThreshold = null) => HasStrand(consequentRole, antecedentRole, movement, weightThreshold);
        public bool HasStrand(ThreadMovement movement, LotusRole antecedentRole, LotusRole consequentRole, double? weightThreshold = null) => HasStrand(consequentRole, antecedentRole, movement, weightThreshold);
        public bool HasStrand(LotusRole antecedentRole, LotusRole consequentRole, ThreadMovement movement, double? weightThreshold = null) {
            return this.Movement.Equals(movement) && HasStrand(antecedentRole, consequentRole, weightThreshold);
        }
        public bool HasStrand(LotusRole antecedentRole, LotusRole consequentRole, double? weightThreshold = null) {
            return Consequent.HasRole(consequentRole) &&
                   Antecedant.HasRole(antecedentRole) &&
                   (new LotusStrand(this, antecedentRole, consequentRole)).Weight >=
                   (weightThreshold ?? Context.StrandWeightThreshold);
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
                String.Join(" ", strands.Select(s => $"({LsfeHelper.ToShortString(s.AntecedantRole)}->{LsfeHelper.ToShortString(s.ConsequentRole)})"))
            );
        }
    }
}