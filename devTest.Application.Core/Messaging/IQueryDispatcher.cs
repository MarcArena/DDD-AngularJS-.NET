using devTest.Application.Dto.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devTest.Application.Messaging
{
    public interface IQueryDispatcher
    {
        /// <summary>
        /// Dispatches a query and retrieves a query result
        /// </summary>
        /// <typeparam name="TParameter">Query to execute type</typeparam>
        /// <typeparam name="TResult">Query Result to get back type</typeparam>
        /// <param name="query">Query to execute</param>
        /// <returns>Query Result to get back</returns>
        TResult Dispatch<TParameter, TResult>(TParameter query) where TParameter : IQuery where TResult : IQueryResult;
    }
}
