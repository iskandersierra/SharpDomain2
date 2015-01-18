using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpDomain.IoC
{
    public interface IRequire
    {
    }

    public interface IRequire<TDependency> : 
        IRequire
        where TDependency : class
    {
    }
}
