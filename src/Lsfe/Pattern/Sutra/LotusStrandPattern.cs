using SineVita.Muguet.Nelumbo.Lily;
using SineVita.Muguet.Nelumbo.Sutra;

namespace SineVita.Muguet.Nelumbo.Lsfe.Pattern.Sutra
{
    public class LotusStrandPattern : 
        ILsfePatternReplicator<LotusStrand>, 
        ILsfePattern<ThreadMovement>,
        ILsfePatternFitter<LotusThread>
    {
        private ILsfePattern<ThreadMovement> _movementPattern;
        private LotusRole _antecedantRole;
        private LotusRole _consequentRole;
        
        public ILsfePattern<ThreadMovement> MovementPattern => _movementPattern;
        public LotusRole AntecedantRole => _antecedantRole;
        public LotusRole ConsequentRole => _consequentRole;
        
        // * Constructor
        public LotusStrandPattern(ILsfePattern<ThreadMovement> movementPattern, LotusRole antecedantRole, LotusRole consequentRole) {
            _movementPattern = movementPattern;
            _antecedantRole = antecedantRole;
            _consequentRole = consequentRole;
        }
        
        // * ILsfePattern
        public object Clone() => new LotusStrandPattern((StrictMovementPattern)_movementPattern.Clone(), _antecedantRole, _consequentRole);
        
        public bool MatchesExact(ILsfeParsable<LotusStrand> strand) {
            var strandObj = strand.Get();
            return _movementPattern.MatchesExact(strandObj.Movement)
                   && _antecedantRole == strandObj.AntecedantRole
                   && _consequentRole == strandObj.ConsequentRole;
        }
        public bool MatchesExact(ILsfeParsable<LotusThread> thread) {
            var threadObj = thread.Get();
            return threadObj.Antecedant.Roles.Count == 1
                   && threadObj.Consequent.Roles.Count == 1
                    && MatchesIn(thread);
        }
        public bool MatchesExact(ILsfeParsable<ThreadMovement> movement) {
            return _movementPattern.MatchesExact(movement);
        }

        public bool MatchesIn(ILsfeParsable<LotusThread> thread) {
            return _movementPattern.MatchesExact(thread.Get().Movement) 
                   && thread.Get().HasStrand(_antecedantRole, _consequentRole);
        }

        public ILsfePatternReplicator<LotusStrand> Replicate(LotusStrand strand) {
            var movementPattern = new StrictMovementPattern(PitchInterval.Empty, 0).Replicate(strand.Movement);
            return new LotusStrandPattern(
                movementPattern,
                _antecedantRole,
                _consequentRole
            );
        }
    }
}