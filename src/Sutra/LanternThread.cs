namespace SineVita.Muguet.Nelumbo {
    public class LanternThread {
        // * Lantern References
        public required Lantern Antecedent { init; get; }
        public required Lantern Consequent { init; get; }
        
        // * Properties
        public List<LotusThread> _threads;
        public IReadOnlyList<LotusThread> Threads => _threads.AsReadOnly();

        public LanternThread(Lantern antecedent, Lantern consequent) {
            Antecedent = antecedent;
            Consequent = consequent;
            _threads = new();
            GenerateThreads();
        }
        
        // * Accessors
        public List<LotusThread> this[int index] => _threads.GetRange(Consequent.Count * index, Consequent.Count);
        public LotusThread GetLotusThread(int antecedentIndex, int consequentIndex) => _threads[antecedentIndex * Consequent.Count + consequentIndex];
        public LotusThread GetThread(int antecedentIndex, int consequentIndex) => GetLotusThread(antecedentIndex, consequentIndex);

        public List<LotusThread> GetGenericLocalMovementThreads(GenericLocalMovement? specificMovement = null) {
            var returnList = new List<LotusThread>();
            if (specificMovement != null) {
              foreach (var thread in Threads) {
                  if (thread.Movement.GenericLocalMovement == specificMovement) returnList.Add(thread);
              }  
            }
            else {
                foreach (var thread in Threads) {
                    if (thread.Movement.IsGenericLocalMovement) returnList.Add(thread);
                }  
            }
            
            return returnList;
        }
        
        
        // * Generator
        public void GenerateThreads() {
            _threads.Clear();
            foreach (var antecedent in Antecedent.Lotuses) {
                foreach (var consequent in Consequent.Lotuses) {
                    _threads.Add(new LotusThread(antecedent, consequent));
                }
            }
        }
        
    }
}