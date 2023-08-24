using Microsoft.Extensions.Caching.Memory;
using OBilet_Case.Core.Interfaces.IManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBilet_Case.Infrastructure.Caches
{
    public class InMemoryCacheManager : ICacheManager
    {
        private readonly IMemoryCache _memoryCache;

        public InMemoryCacheManager(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public T Get<T>(string key)
        {
            return _memoryCache.TryGetValue(key, out T cacheEntry) ? cacheEntry : default(T);
        }

        private void Set<T>(string key, T data, TimeSpan? duration = null)
        {
            if (duration.HasValue)
                _memoryCache.Set(key, data, duration.Value);
            else
                _memoryCache.Set(key, data);
        }

        public T GetOrSet<T>(string key, Func<T> acquire, TimeSpan? duration = null)
        {
            if (IsSet(key))
                return Get<T>(key);
            else
            {
                var result = acquire();
                Set<T>(key, result, duration);
                return result;
            }
        }

        public bool IsSet(string key)
        {
            return _memoryCache.TryGetValue(key, out _);
        }

        public void Remove(string key)
        {
            _memoryCache.Remove(key);
        }
    }
}

