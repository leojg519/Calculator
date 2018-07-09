using CalculatorService.Entities.Substraction;

namespace CalculatorService.Interfaces.Repositories
{
    public interface ISubstractionRepository
    {
        /// <summary>
        /// Make the substraction calculation for the array of operands
        /// </summary>
        /// <param name="operands">Array of operands to be substracted</param>
        /// <param name="trackingId">Tracking id of the operations</param>
        /// <returns>SubstractionResponse for the substraction of all the operands</returns>
        SubstractionResponse Substract(int[] operands, string trackingId);
    }
}
