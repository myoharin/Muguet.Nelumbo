namespace SineVita.Muguet.Nelumbo {
    public class LotusStrand {
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
        public override string ToString() => $"{AntecedentRole} {Movement} {ConsequentRole}";
    }
}