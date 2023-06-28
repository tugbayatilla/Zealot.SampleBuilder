using System.Linq.Expressions;
using System.Reflection;

namespace Zealot;

internal static class Instance
{
    /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="args">The arguments.</param>
        /// <returns></returns>
        private delegate T ObjectActivator<out T>(params object[] args);

        /// <summary>
        /// Creates the instance.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public static object? Create(Type type)
        {
            object? instance = null!;
            if (type.ContainsGenericParameters)
            {
                type = type.MakeGenericType(type.GenericTypeArguments);
            }

            var constructorArguments = new List<object>();
            var ctorInfo = type.GetConstructors().FirstOrDefault();
            if (ctorInfo != null)
            {
                var ctorParametersInfo = ctorInfo.GetParameters();
                constructorArguments.AddRange(
                    ctorParametersInfo.Select(info => info.ParameterType.IsClass
                        ? Create(info.ParameterType)
                        : info.ParameterType.GetDefault()));

                var createdActivator = GetActivator<object>(ctorInfo);
                instance = createdActivator(constructorArguments.ToArray());
            }

            var isStruct = type.IsValueType && !type.IsPrimitive && !type.IsEnum;
            if (isStruct)
            {
                instance = Activator.CreateInstance(type);
            }
            
            return instance;
        }

        /// <summary>
        /// Gets the activator.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ctor">The ctor.</param>
        /// <returns></returns>
        private static ObjectActivator<T> GetActivator<T>(ConstructorInfo ctor)
        {
            //taken from rogerjohansson.blog
            var paramsInfo = ctor.GetParameters();

            //create a single param of type object[]
            var param = Expression.Parameter(typeof(object[]), "args");

            var argsExp = new Expression[paramsInfo.Length];

            //pick each arg from the params array 
            //and create a typed expression of them
            for (var i = 0; i < paramsInfo.Length; i++)
            {
                Expression index = Expression.Constant(i);
                var paramType = paramsInfo[i].ParameterType;

                Expression paramAccessorExp = Expression.ArrayIndex(param, index);
                Expression paramCastExp = Expression.Convert(paramAccessorExp, paramType);

                argsExp[i] = paramCastExp;
            }

            //make a NewExpression that calls the
            //ctor with the args we just created
            var newExp = Expression.New(ctor, argsExp);

            //create a lambda with the New
            //Expression as body and our param object[] as arg
            var lambda = Expression.Lambda(typeof(ObjectActivator<T>), newExp, param);

            //compile it
            var compiled = (ObjectActivator<T>)lambda.Compile();
            return compiled;
        }
    }
