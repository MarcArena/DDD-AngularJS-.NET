using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devTest.CrossCutting.Cache
{
    public interface ICache
    {
        T Get<T>(string key);
        void Set<T>(string key, T value, TimeSpan? timeSpan = null);
    }
}
