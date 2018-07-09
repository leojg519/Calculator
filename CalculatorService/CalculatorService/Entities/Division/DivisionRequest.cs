namespace CalculatorService.Entities.Division
{
    /// <summary>
    /// Entity class for Division request
    /// </summary>
    public class DivisionRequest
    {
        /// <summary>
        /// Dividend operator
        /// </summary>
        public int Dividend{ get; set; }

        /// <summary>
        /// Divisor operator
        /// </summary>
        public int Divisor{ get; set; }
    }
}