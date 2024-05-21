using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace MicrosoftDependencyInjection.DI
{
    public class DIContainer
    {
        public IServiceProvider BuildServiceProvider()
        {
            ServiceCollection collection = new ServiceCollection();
        }

    }
}
