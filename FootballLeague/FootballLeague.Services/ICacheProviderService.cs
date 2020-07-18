namespace FootballLeague.Services
{
    public interface ICacheProviderService
    {
        TItem GetCacheItem<TItem>(string key)
            where TItem : class;

        void SetCacheItem<TItem>(string key, TItem item)
            where TItem : class;
    }
}
