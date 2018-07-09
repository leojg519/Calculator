using CalculatorService.Entities.Addition;

namespace CalculatorService.Interfaces.Repositories
{
    public interface IAdditionRepository
    {
        /// <summary>
        /// Make the addition calculation for the array of operands
        /// </summary>
        /// <param name="operands">Array of operands to be added</param>
        /// <param name="trackingId">Tracking id of the operations</param>
        /// <returns>AdditionResponse for the addition of all the operands</returns>
        AdditionResponse Add(int[] operands, string trackingId);
    }
}
