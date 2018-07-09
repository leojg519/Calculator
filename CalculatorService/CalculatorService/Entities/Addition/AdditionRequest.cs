namespace CalculatorService.Entities.Addition
{
    /// <summary>
    /// Entity class for Addition request
    /// </summary>
    public class AdditionRequest
    {
        /// <summary>
        /// Addition operators
        /// </summary>
        public int[] Addends { get; set; }
    }
}