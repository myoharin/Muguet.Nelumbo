using SineVita.Muguet;

namespace SineVita.Muguet.Nelumbo {
    public class LotusThread
    {
        // * References
        public required Lotus Antecedent { init; get; }
        public required Lotus Consequent { init; get; }
        public required ThreadMovement Movement { init; get; }
        
        // * Constructor
        public LotusThread(Lotus antecedent, Lotus consequent) {
            Antecedent = antecedent;
            Consequent = consequent;
            Movement = new(PitchInterval.CreateInterval(antecedent.Pitch, consequent.Pitch, false, false));
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