using SineVita.Muguet;

namespace SineVita.Muguet.Nelumbo {
    public class LotusThread
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
    }
}