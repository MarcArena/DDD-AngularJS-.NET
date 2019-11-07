using devTest.CrossCutting.Ioc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devTest.CrossCutting
{
    public static class ApplicationContext
    {
        static ApplicationContext()
        {
            Container = new UnityIocContainer();
        }
        
        public static IIocContainer Container { get; set; }


    }
}
