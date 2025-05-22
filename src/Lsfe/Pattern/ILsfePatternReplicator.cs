namespace SineVita.Muguet.Nelumbo.Lsfe.Pattern
{
    public interface ILsfePatternReplicator<T> : ILsfePattern<T>
    {
        public ILsfePatternReplicator<T> Replicate(T target);
        // convention: copy over all properties and return itself
    }
}