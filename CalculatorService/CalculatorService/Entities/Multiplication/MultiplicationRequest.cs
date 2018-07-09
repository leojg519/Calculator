namespace CalculatorService.Entities.Multiplication
{
    /// <summary>
    /// Entity class for Multiplication request
    /// </summary>
    public class MultiplicationRequest
    {
        /// <summary>
        /// Multiplication operators
        /// </summary>
        public int[] Factors { get; set; }
    }
}