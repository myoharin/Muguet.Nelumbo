using SineVita.Muguet.Nelumbo.Lily;
using SineVita.Muguet.Nelumbo.Lsfe;

namespace SineVita.Muguet.Nelumbo.Sutra {
    public class LanternThread : ILsfeParsable<LanternThread> {
        // * Lantern References
        public Lantern Antecedent { init; get; }
        public Lantern Consequent { init; get; }
        
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
        public IReadOnlyList<LotusThread> this[int index] => _threads.GetRange(Consequent.Count * index, Consequent.Count);
        public LotusThread GetLotusThread(int antecedentIndex, int consequentIndex) => _threads[antecedentIndex * Consequent.Count + consequentIndex];
        public LotusThread GetThread(int antecedentIndex, int consequentIndex) => GetLotusThread(antecedentIndex, consequentIndex);

        public IReadOnlyList<LotusThread> GetGenericLocalMovementThreads(GenericLocalMovement? specificMovement = null) {
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

        public IReadOnlyList<LotusThread> GetLotusThreads(bool glmOnly) {
            var returnList = (new List<LotusThread>(_threads));
            if (glmOnly) returnList.RemoveAll(t => !t.Movement.IsGenericLocalMovement);
            return returnList;
        }
        
        // * Generator
        private void GenerateThreads() {
            _threads.Clear();
            foreach (var antecedent in Antecedent.Lotuses) {
                foreach (var consequent in Consequent.Lotuses) {
                    _threads.Add(new LotusThread(antecedent, consequent));
                }
            }
        }
        
        // * LSFE
        public string ToLsfe() => ToLsfe(true);
        public string ToLsfe(bool glmOnly) { // tuplet form
            var threads = GetLotusThreads(glmOnly);

            var returnStr = "";
            bool first = true;
            
            foreach (var thread in threads) {
                if (first) {
                    first = false;
                }
                else {
                    returnStr += "\n\n";
                }
                var threadString = $"{thread.Antecedent.Pitch.NoteName}" +
                                   $"->" +
                                   $"{thread.Consequent.Pitch.NoteName}";
                var lotusThreadTupletString = thread.ToLsfeTupletForm();//.Replace(" ", "\n");
                threadString += "\n" + lotusThreadTupletString;
                returnStr += threadString;
            }
            
            return returnStr;
        }
    }
}