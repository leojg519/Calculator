using System.Collections.Generic;

namespace CalculatorService.Entities.Query
{
    /// <summary>
    /// Entity class for Query response
    /// </summary>
    public class QueryResponse
    {
        /// <summary>
        /// List of operations
        /// </summary>
        public IList<QueryItemResponse> Operations { get; set; }
    }
}