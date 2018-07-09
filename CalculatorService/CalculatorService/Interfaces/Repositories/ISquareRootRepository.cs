using CalculatorService.Entities.SquareRoot;

namespace CalculatorService.Interfaces.Repositories
{
    public interface ISquareRootRepository
    {
        /// <summary>
        /// Make the square root calculation for the operand
        /// </summary>
        /// <param name="operand">Operands to be calculated the square root</param>
        /// <param name="trackingId">Tracking id of the operations</param>
        /// <returns>SquareRootResponse for the square root of the operand</returns>
        SquareRootResponse SquareRoot(int operand, string trackingId);
    }
}
