using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.ServiceModel;

namespace Pentegy.Utils.Common
{
    public static class WCFHelper
    {
        static readonly ConcurrentDictionary<Type, ChannelFactory> ChannelFactories = new ConcurrentDictionary<Type, ChannelFactory>();

        public static T GetService<T>()
        {
            var factory = (ChannelFactory<T>)ChannelFactories.GetOrAdd(typeof(T), t => new ChannelFactory<T>(typeof(T).Name));
            T service = factory.CreateChannel();
            return service;
        }

        public static void Call<T>(Action<T> callDelegate)
        {
            if (callDelegate == null)
                throw new ArgumentNullException();

            Call<T, bool>(service => { callDelegate(service); return true; });
        }

        public static TR Call<T, TR>(Func<T, TR> callDelegate)
        {
            var service = GetService<T>();
            try
            {
                return Call(service, callDelegate);
            }
            finally
            {
                ((ICommunicationObject)service).Dispose();
            }
        }

        public static void Call<T>(T service, Action<T> callDelegate)
        {
            Call(service, x => { callDelegate(x); return true; });
        }

        public static TR Call<T, TR>(T service, Func<T, TR> callDelegate)
        {
            // ReSharper disable once CompareNonConstrainedGenericWithNull
            if (service == null)
                throw new ArgumentNullException("service");
            if (callDelegate == null)
                throw new ArgumentNullException("callDelegate");

            using (new OperationContextScope((IContextChannel)service))
            {
                return callDelegate(service);
            }
        }

        /// <summary>
        /// Performs safe disposal of <see cref="ICommunicationObject"/> instances.
        /// WCF has invalid <see cref="IDisposable"/> implementation for client proxies.
        /// See <a href="http://geekswithblogs.net/DavidBarrett/archive/2007/11/22/117058.aspx">http://geekswithblogs.net/DavidBarrett/archive/2007/11/22/117058.aspx</a>
        /// for more information.
        /// </summary>
        /// <param name="commObj"><see cref="ICommunicationObject"/> instance to dispose.</param>
        /// <returns>Any <see cref="Exception"/> that might occured during disposing. Can be used for logging purposes.</returns>
        public static Exception Dispose(this ICommunicationObject commObj)
        {
            Exception result = null;
            if (commObj != null)
            {
                try
                {
                    if (commObj.State == CommunicationState.Opened)
                        try
                        {
                            commObj.Close();
                        }
                        catch (Exception ex)
                        {
                            Trace.TraceError("Cannot close {0}: {1}", commObj.GetType().Name, ex);
                            commObj.Abort();
                        }
                    else
                        commObj.Abort();
                    ((IDisposable)commObj).Dispose();
                }
                catch (Exception ex)
                {
                    Trace.TraceError("Cannot dispose {0}: {1}", commObj.GetType().Name, ex);
                    result = ex;
                }
            }
            return result;
        }
    }
}
