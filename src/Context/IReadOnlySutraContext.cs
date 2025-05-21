using SineVita.Muguet.Nelumbo.IntervalClass;
using SineVita.Muguet.Nelumbo.Sutra;

namespace SineVita.Muguet.Nelumbo.Context
{
    public interface IReadOnlySutraContext
    {
        public Func<IReadOnlyPitchInterval, bool> this[FormalIntervalClassification intervalClass] { get; }
        public Func<IReadOnlyPitchInterval, bool> this[GenericLocalMovement value] { get; }

        public bool Evaluate(IReadOnlyPitchInterval interval, GenericLocalMovement value) => this[value](interval);
        public bool Evaluate(IReadOnlyPitchInterval interval, FormalIntervalClassification intervalClass) => this[intervalClass](interval);

    }
}