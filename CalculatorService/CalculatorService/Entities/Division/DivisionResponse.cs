namespace CalculatorService.Entities.Division
{
    /// <summary>
    /// Entity class for Division response
    /// </summary>
    public class DivisionResponse
    {
        /// <summary>
        /// Division quotient
        /// </summary>
        public int Quotient { get; set; }

        /// <summary>
        /// Division remainder
        /// </summary>
        public int Remainder { get; set; }
    }
}