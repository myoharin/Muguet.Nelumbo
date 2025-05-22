namespace SineVita.Muguet.Nelumbo.Lsfe
{
    public interface ILsfeParsable<T>
    {
        public String ToLsfe();
        public T Get();
    }
}