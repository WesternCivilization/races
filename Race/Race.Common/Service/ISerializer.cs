namespace Race.Common.Service
{
    public interface ISerializer
    {
        T Deserialize<T>(string content);
    }
}
