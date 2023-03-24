using MQL4CSharp.Base.REST;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace MQL4CSharp.Util
{

    public class MethodInfoExtended
    {
        private static ConcurrentDictionary<string, List<MethodInfoExtended>> _methodsCacheByName = new ConcurrentDictionary<string, List<MethodInfoExtended>>();
        private static ConcurrentDictionary<MethodInfo, MethodInfoExtended> _methodsCache = new ConcurrentDictionary<MethodInfo, MethodInfoExtended>();

        public static MethodInfoExtended GetByMethod(MethodInfo method)
        {
            var res = _methodsCache.GetOrAdd(method, s => new MethodInfoExtended(s));
            return res;
        }
        public static List<MethodInfoExtended> GetByMethodName(Type type, string methodName)
        {
            var res = _methodsCacheByName.GetOrAdd($"{type.FullName}.{methodName}", s => type.GetMethods().Where(x => x.Name == methodName).Select(GetByMethod).ToList());
            return res;
        }

        public override string ToString()
        {
            return Method.ToString();
        }

        public MethodInfo Method { get; }
        public ParameterInfo[] Parameters { get; }
        public ParameterInfo[] ParametersForRestApi { get; }
        public MethodInfoExtended(MethodInfo method)
        {
            Method = method;
            Parameters = method.GetParameters();
            ParametersForRestApi = Parameters.Where(x => x.ParameterType != typeof(MQLRestContext)).ToArray();
            FillInvoker();
        }

        private ReturnValueDelegate _fastInvokerDelegate;
        public Func<object, object[], object> InvokeFastDelegate;
        private void FillInvoker()
        {
            /*Ho provato anche con Emit, ma le performance sono simili e la complessità del metodo è molto maggiore. */
            /*https://stackoverflow.com/questions/10313979/methodinfo-invoke-performance-issue*/
            /*https://www.codeproject.com/Articles/14593/A-General-Fast-Method-Invoker*/
            /*https://forums.asp.net/t/1036046.aspx?using+System+Reflection+to+invoke+method+in+different+assembly*/
            _fastInvokerDelegate = CreateInvokeDelegate(Method);
            InvokeFastDelegate = (o, objects) => _fastInvokerDelegate(o, objects);
        }

        public object InvokeFast(object target, List<object> args)
        {
            return _fastInvokerDelegate(target, args.ToArray());
        }
        public object InvokeFast(object target, params object[] args)
        {
            return _fastInvokerDelegate(target, args);
        }

        #region Creazione Invoke Delegate
        private delegate object ReturnValueDelegate(object instance, object[] arguments);
        private delegate void VoidDelegate(object instance, object[] arguments);
        private ReturnValueDelegate CreateInvokeDelegate(MethodInfo methodInfo)
        {
            var parameterInfos = methodInfo.GetParameters();
            var instanceExpression = Expression.Parameter(typeof(object), "instance");
            var argumentsExpressionAndArgs = GetGenericObjectArrayParameters(parameterInfos.Select(x => x.ParameterType).ToArray());
            var argumentsExpression = argumentsExpressionAndArgs.Item1;
            var argumentExpressions = argumentsExpressionAndArgs.Item2;

            ReturnValueDelegate Delegate;
            var callExpression = Expression.Call(!methodInfo.IsStatic ? Expression.Convert(instanceExpression, methodInfo.ReflectedType) : null, methodInfo, argumentExpressions);
            if (callExpression.Type == typeof(void))
            {
                var voidDelegate = Expression.Lambda<VoidDelegate>(callExpression, instanceExpression, argumentsExpression).Compile();
                Delegate = (instance, arguments) => { voidDelegate(instance, arguments); return null; };
            }
            else
                Delegate = Expression.Lambda<ReturnValueDelegate>(Expression.Convert(callExpression, typeof(object)), instanceExpression, argumentsExpression).Compile();

            return Delegate;
        }

        internal static Tuple<ParameterExpression, Expression[]> GetGenericObjectArrayParameters(Type[] parameters)
        {
            // define a object[] parameter
            var paramExpr = Expression.Parameter(typeof(object[]), "arguments");
            var arguments = new Expression[parameters.Length];
            // To feed the constructor with the right parameters, we need to generate an array 
            // of parameters that will be read from the initialize object array argument.
            for (var i = 0; i < parameters.Length; i++)
            {
                var paramType = parameters[i];
                // read a value from the object[index]
                var itemValue = Expression.ArrayAccess(paramExpr, Expression.Constant(i));
                // convert the object[index] to the right constructor parameter type.
                var itemValueCasted = (!paramType.IsValueType) ? Expression.TypeAs(itemValue, paramType) : Expression.Convert(itemValue, paramType);
                arguments[i] = itemValueCasted;
            }

            return Tuple.Create(paramExpr, arguments);
        }

        #endregion

    }

}
