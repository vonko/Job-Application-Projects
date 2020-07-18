using System.Web;

namespace FootballLeague.Services.Implementation
{
    public class CacheProviderService : ICacheProviderService
    {
        public TItem GetCacheItem<TItem>(string key) 
            where TItem : class
        {
            object itemAsObject = HttpRuntime.Cache.Get(key);
            TItem cachedItem = itemAsObject as TItem;

            return cachedItem;
        }

        public void SetCacheItem<TItem>(string key, TItem item)
            where TItem : class
        {
            HttpRuntime.Cache.Insert(key, item);
        }
    }
}
