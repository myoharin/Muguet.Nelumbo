using SineVita.Muguet.Nelumbo.Sutra;
using SineVita.Muguet.Nelumbo.Context;

namespace SineVita.Muguet.Nelumbo.Lsfe.Pattern.Sutra
{
    public class ThreadMovementPattern : 
        ILsfePatternReplicator<ThreadMovement>
    {
        // * Properties
        private PitchInterval _interval;
        private GenericLocalMovement _movement;

        public IReadOnlyPitchInterval Interval => _interval;
        public GenericLocalMovement Movement => _movement;
        public bool IsGlm => _movement != GenericLocalMovement.NA;
        
        // * Constructor
        private ThreadMovementPattern() {
            _interval = PitchInterval.Empty;
            _movement = new GenericLocalMovement();
        }
        public ThreadMovementPattern(PitchInterval interval, GenericLocalMovement movement)
            : this() {
            SetInterval(interval, movement);
        }
        public ThreadMovementPattern(PitchInterval interval, ISutraContextualizer contextualizer)
            : this() {
            SetInterval(interval, contextualizer);
        }
        public ThreadMovementPattern(GenericLocalMovement movement) {
            _interval = PitchInterval.Empty;
            SetInterval(movement);
        }
        
        public void SetInterval(PitchInterval interval, GenericLocalMovement movement) {
            _interval = interval;
            _movement = movement;
        }
        public void SetInterval(PitchInterval interval, ISutraContextualizer contextualizer) {
            _interval = interval;
            _movement = GenericLocalMovement.NA;
            var context = contextualizer.Context;
            foreach (var movement in Enum.GetValues<GenericLocalMovement>()) {
                if (context[movement](Interval)) {
                    _movement = movement;
                    break;
                }
            }
        }
        public void SetInterval(GenericLocalMovement movement) {
            _movement = movement;
            _interval = movement switch {
                GenericLocalMovement.NA => PitchInterval.Empty,
                GenericLocalMovement.D8 => PitchInterval.Octave.Inverted(),
                GenericLocalMovement.D5 => PitchInterval.Perfect5th.Inverted(),
                GenericLocalMovement.D4 => PitchInterval.Perfect4th.Inverted(),
                GenericLocalMovement.DL => new MidiPitchInterval(-1),
                GenericLocalMovement.U  => PitchInterval.Unison,
                GenericLocalMovement.UL => new MidiPitchInterval(1),
                GenericLocalMovement.U4 => PitchInterval.Perfect4th,
                GenericLocalMovement.U5 => PitchInterval.Perfect5th,
                GenericLocalMovement.U8 => PitchInterval.Octave,
                _                       => PitchInterval.Empty,
            };
        }
        
        // * ILsfePattern
        public object Clone() => new ThreadMovementPattern((PitchInterval)_interval.Clone(), _movement);
        public bool MatchesExact(ILsfeParsable<ThreadMovement> movement) {
            var threadMovement = movement.Get();
            return (_movement.Equals(threadMovement.GenericLocalMovement) 
                    && _movement != GenericLocalMovement.NA)
                   || _interval == threadMovement.Interval;
        }

        public ILsfePatternReplicator<ThreadMovement> Replicate(ThreadMovement movement) {
            _interval = movement.Interval;
            _movement = movement.GenericLocalMovement;
            return this;
        }
        
        
    }
}