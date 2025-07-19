namespace SineVita.Muguet.Nelumbo.Lsfe.Pattern
{
    public interface ILsfePatternReplicator<T> : ILsfePattern<T>
    {
        public ILsfePatternReplicator<T> Replicate(T target);
        // convention: copy over all properties and return input
        
        // prolly not needed / a hassle. gets rid a feel lines of code at which and causess more compelxity uncneccessarily.
    }
}