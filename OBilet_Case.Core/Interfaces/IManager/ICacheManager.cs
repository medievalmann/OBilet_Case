using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBilet_Case.Core.Interfaces.IManager
{
    public interface ICacheManager
    {
        T Get<T>(string key);
        T GetOrSet<T>(string key, Func<T> acquire, TimeSpan? duration = null);
        bool IsSet(string key);
        void Remove(string key);
    }
}
