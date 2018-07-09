using CalculatorService.Entities.Multiplication;

namespace CalculatorService.Interfaces.Repositories
{
    public interface IMultiplicationRepository
    {
        /// <summary>
        /// Make the multiplication calculation for the array of operands
        /// </summary>
        /// <param name="operands">Array of operands to be multiplied</param>
        /// <param name="trackingId">Tracking id of the operations</param>
        /// <returns>MultiplicationResponse for the multiplication of all the operands</returns>
        MultiplicationResponse Multiply(int[] operands, string trackingId);
    }
}
