using CalculatorService.Entities.History;
using CalculatorService.Entities.Query;
using System.Collections.Generic;

namespace CalculatorService.Interfaces.Repositories
{
    /// <summary>
    /// Interface for operations tracking history
    /// </summary>
    public interface IQueryRepository
    {
        /// <summary>
        /// Get the List of all the operations performed
        /// </summary>
        /// <returns>List of all the operations performed</returns>
        IList<HistoryItem> GetAllHistoryItems();

        /// <summary>
        /// Get the operations performed with a given id
        /// </summary>
        /// <param name="id">Id of the operation</param>
        /// <returns>Operations performed with the corresponding id</returns>
        QueryResponse GetHistoryItemById(string id);
    }
}
