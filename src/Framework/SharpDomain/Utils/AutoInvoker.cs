using System;
using System.Collections.Concurrent;
using System.Linq.Expressions;
using System.Reflection;

namespace SharpDomain.Utils
{
    public class AutoInvoker :
        IAutoInvoker
    {
        static AutoInvoker()
        {
            InvokeFuncNotFound = (i, p) => null;
        }

        public AutoInvoker(string methodName, IAutoInvoker fallback = null)
        {
            if (string.IsNullOrWhiteSpace(methodName)) throw new ArgumentNullException("methodName");

            MethodName = methodName;
            Fallback = fallback ?? new FailAlwaysAutoInvoker(methodName);
        }

        public IAutoInvoker Fallback { get; private set; }

        public string MethodName { get; private set; }

        /// <summary>
        /// This value is returned for invoked methods with void return types
        /// </summary>
        public object DefaultInvokeResult { get; set; }

        public object Invoke(object instance, object parameter)
        {
            if (instance == null) throw new ArgumentNullException("instance");
            if (parameter == null) throw new ArgumentNullException("parameter");

            var instanceType = instance.GetType();
            var parameterType = parameter.GetType();
            var key = Tuple.Create(instanceType, parameterType);

            var func = _cache.GetOrAdd(key, CreateInvokeFunc);
            if (func == InvokeFuncNotFound)
                return Fallback.Invoke(instance, parameter);
            else
                return func(instance, parameter);
        }

        private Func<object, object, object> CreateInvokeFunc(Tuple<Type, Type> key)
        {
            var instanceType = key.Item1;
            var parameterType = key.Item2;

            var method = instanceType.GetMethod(
                MethodName,
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic,
                null,
                new[] { parameterType },
                null);
            if (method == null) return InvokeFuncNotFound;

            Func<object, object, object> func;

            var instanceParameter = Expression.Parameter(typeof(object), "instance");
            var parameterParameter = Expression.Parameter(typeof(object), "parameter");
            var bodyExpr = Expression.Call(
                Expression.Convert(instanceParameter, instanceType),
                method,
                new Expression[] {Expression.Convert(parameterParameter, parameterType)}
                );

            if (method.ReturnType != typeof(void))
            {
                // Create function: (instance, parameter) => instance.MethodName(parameter)

                //// using reflection:
                //func = (instance, parameter) => method.Invoke(instance, new[] { parameter });

                // using compiled expressions:
                var expr = Expression.Lambda<Func<object, object, object>>(bodyExpr, instanceParameter, parameterParameter);
                func = expr.Compile();
            }
            else
            {
                // Create function: (instance, parameter) => { instance.MethodName(parameter); return DefaultInvokeResult; }
                
                //// using reflection:
                //func = (instance, parameter) =>
                //{
                //    method.Invoke(instance, new[] { parameter });
                //    return DefaultInvokeResult;
                //};

                // using compiled expressions:
                var voidExpr = Expression.Lambda<Action<object, object>>(bodyExpr, instanceParameter, parameterParameter);
                var voidFunc = voidExpr.Compile();

                func = (instance, parameter) =>
                {
                    voidFunc(instance, parameter);
                    return DefaultInvokeResult;
                };
            }

            return func;
        }

        private static readonly Func<object, object, object> InvokeFuncNotFound;
        private ConcurrentDictionary<Tuple<Type, Type>, Func<object, object, object>> _cache = new ConcurrentDictionary<Tuple<Type, Type>, Func<object, object, object>>();
    }
}
