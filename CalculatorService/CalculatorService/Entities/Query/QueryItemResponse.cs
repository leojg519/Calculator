namespace CalculatorService.Entities.Query
{
    /// <summary>
    /// Entity class for Query Item response
    /// </summary>
    public class QueryItemResponse
    {
        /// <summary>
        /// Operation performed
        /// </summary>
        public string Operation { get; set; }

        /// <summary>
        /// Calculation
        /// </summary>
        public string Calculation { get; set; }

        /// <summary>
        /// Date when performed
        /// </summary>
        public string Date { get; set; }
    }
}