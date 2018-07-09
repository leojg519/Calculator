namespace CalculatorService.Entities.Substraction
{
    /// <summary>
    /// Entity class for Substraction request
    /// </summary>
    public class SubstractionRequest
    {
        /// <summary>
        /// Minuend operator
        /// </summary>
        public int Minuend { get; set; }

        /// <summary>
        /// Subtrahend operator
        /// </summary>
        public int Subtrahend { get; set; }
    }
}