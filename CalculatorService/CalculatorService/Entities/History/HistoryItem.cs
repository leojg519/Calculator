using CalculatorService.Entities.Query;
using System.Collections.Generic;

namespace CalculatorService.Entities.History
{
    /// <summary>
    /// Entity class for history items
    /// </summary>
    public class HistoryItem
    {
        /// <summary>
        /// Id of the item
        /// </summary>
        public string TrackingId { get; set; }

        /// <summary>
        /// List of operations
        /// </summary>
        public IList<QueryItemResponse> Operations { get; set; }
    }
}