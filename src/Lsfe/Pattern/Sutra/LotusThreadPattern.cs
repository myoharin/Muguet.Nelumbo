using SineVita.Muguet.Nelumbo.Lily;
using SineVita.Muguet.Nelumbo.Sutra;

namespace SineVita.Muguet.Nelumbo.Lsfe.Pattern.Sutra
{
    public class LotusThreadPattern :
        ILsfePatternReplicator<LotusThread>,
        ILsfePatternContainer<LotusThread>,
        ILsfePatternFitter<LotusThread>,
        ILsfePatternFitter<LanternThread>,
        ILsfePatternContainer<LotusStrand>,
        ILsfePattern<ThreadMovement>
    {
        private List<LotusRole> _antecedantRoles;
        private List<LotusRole> _consequentRoles;
        private ILsfePattern<ThreadMovement> _movementPattern;
        
        public IReadOnlyList<LotusRole> AntecedantRoles => _antecedantRoles;
        public IReadOnlyList<LotusRole> ConsequentRoles => _consequentRoles;
        public ILsfePattern<ThreadMovement> MovementPattern => _movementPattern;
        
        // * Constructor
        public LotusThreadPattern(
            ILsfePattern<ThreadMovement> movementPattern,
            List<LotusRole> antecedantRoles,
            List<LotusRole> consequentRoles
        ) {
            _movementPattern = movementPattern;
            _antecedantRoles = antecedantRoles;
            _consequentRoles = consequentRoles;
            _antecedantRoles.Sort();
            _consequentRoles.Sort();
        }
        
        // * ILsfePattern
        
        public object Clone() => new LotusThreadPattern((ILsfePattern<ThreadMovement>)_movementPattern.Clone(),
            new List<LotusRole>(_antecedantRoles), new List<LotusRole>(_consequentRoles));
        public ILsfePatternReplicator<LotusThread> Replicate(LotusThread thread) {
            _antecedantRoles = new List<LotusRole>(thread.Antecedant.Roles);
            _consequentRoles = new List<LotusRole>(thread.Consequent.Roles);
            _movementPattern = new StrictMovementPattern(PitchInterval.Empty, 0).Replicate(thread.Movement);
            return this;
        }
        
        public bool MatchesExact(ILsfeParsable<LotusThread> thread) {
            var threadObj = thread.Get();
            return _movementPattern.MatchesExact(threadObj.Movement)
                && _antecedantRoles.OrderBy(x => x).SequenceEqual(threadObj.Antecedant.Roles.OrderBy(x => x))   
                && _consequentRoles.OrderBy(x => x).SequenceEqual(threadObj.Consequent.Roles.OrderBy(x => x));
        }
        public bool MatchesExact(ILsfeParsable<LanternThread> thread) {
            var threadObj = thread.Get();
            return threadObj.Antecedent.Count == 1
                   && threadObj.Consequent.Count == 1
                   && MatchesIn(thread);
        }
        public bool MatchesExact(ILsfeParsable<LotusStrand> strand) {
            return MatchContains(strand)
                   && _antecedantRoles.Count == 1
                   && _consequentRoles.Count == 1;
        }
        public bool MatchesExact(ILsfeParsable<ThreadMovement> movement) => _movementPattern.MatchesExact(movement);

        public bool MatchesIn(ILsfeParsable<LotusThread> thread) {
            var threadObj = thread.Get();
            return _movementPattern.MatchesExact(threadObj.Movement)
                && _antecedantRoles.All(threadObj.Antecedant.Roles.Contains)
                && _consequentRoles.All(threadObj.Consequent.Roles.Contains);
        }
        public bool MatchContains(ILsfeParsable<LotusThread> thread) {
            var threadObj = thread.Get();
            return _movementPattern.MatchesExact(threadObj.Movement)
                   && threadObj.Antecedant.Roles.All(_antecedantRoles.Contains)
                   && threadObj.Consequent.Roles.All(_consequentRoles.Contains);
        }
        public bool MatchContains(ILsfeParsable<LotusStrand> strand) {
            var strandObj = strand.Get();
            return _movementPattern.MatchesExact(strandObj.Movement)
                   && AntecedantRoles.Contains(strandObj.AntecedantRole)
                   && ConsequentRoles.Contains(strandObj.ConsequentRole);
        }
        public bool MatchesIn(ILsfeParsable<LanternThread> thread) {
            var threadObj = thread.Get();
            var lotusThreads = threadObj.Threads;
            return lotusThreads.Any(MatchesExact);
        }
        
        
        
    }
}