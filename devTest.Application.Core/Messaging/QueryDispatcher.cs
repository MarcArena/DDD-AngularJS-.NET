
using devTest.Application.Dto.Base;
using System;
using System.Diagnostics;
using devTest.CrossCutting.Ioc;

namespace devTest.Application.Messaging
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IIocContainer _container;

        public QueryDispatcher(IIocContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }
            _container = container;
        }

        public TResult Dispatch<TParameter, TResult>(TParameter query)
            where TParameter : IQuery
            where TResult : IQueryResult
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            IQueryHandler<TParameter, TResult> handler = null;

            try
            {
                handler = _container.Resolve<IQueryHandler<TParameter, TResult>>();
                var results = handler.Retrieve(query);

                stopwatch.Stop();

                return results;
            }
            catch (Exception ex)
            {
                stopwatch.Stop();
                throw;
            }
            finally
            {
                handler.Dispose();
            }
        }
        
    }
}
