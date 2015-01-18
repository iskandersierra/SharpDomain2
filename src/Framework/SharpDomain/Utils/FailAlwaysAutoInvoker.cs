using System;
using SharpDomain.Properties;

namespace SharpDomain.Utils
{
    public class FailAlwaysAutoInvoker : IAutoInvoker
    {
        public FailAlwaysAutoInvoker(string methodName)
        {
            if (string.IsNullOrWhiteSpace(methodName)) throw new ArgumentNullException("methodName");
            MethodName = methodName;
        }

        public string MethodName { get; private set; }

        public object Invoke(object instance, object parameter)
        {
            if (instance == null) throw new ArgumentNullException("instance");
            if (parameter == null) throw new ArgumentNullException("parameter");

            throw new NotSupportedException(string.Format(Resources.InstanceCannotInvokeMethod, instance.GetType().FullName, MethodName, parameter.GetType().FullName));
        }
    }
}