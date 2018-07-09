using CalculatorService.Entities.History;
using CalculatorService.Entities.Query;
using CalculatorService.Helpers;
using CalculatorService.Interfaces.Repositories;
using System.Collections.Generic;

namespace CalculatorService.Repositories
{
    /// <summary>
    /// Repository for addition calculations
    /// </summary>
    public class QueryRepository : IQueryRepository
    {
        /// <summary>
        /// Get the List of all the operations performed
        /// </summary>
        /// <returns>List of all the operations performed</returns>
        public IList<HistoryItem> GetAllHistoryItems()
        {
            return HistoryHelper.GetInstance().GetAllHistoryItems();
        }

        /// <summary>
        /// Get the operations performed with a given id
        /// </summary>
        /// <param name="id">Id of the operation</param>
        /// <returns>Operations performed with the corresponding id</returns>
        public QueryResponse GetHistoryItemById(string id)
        {
            return HistoryHelper.GetInstance().GetHistoryItemById(id);
        }

    }
}