using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devTest.Data.Base
{
    public interface IWebApiService
    {
        T Get<T>(string url, double? timeout = null);
    }
}
