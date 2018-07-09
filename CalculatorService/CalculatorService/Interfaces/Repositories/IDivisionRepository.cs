using CalculatorService.Entities.Division;

namespace CalculatorService.Interfaces.Repositories
{
    public interface IDivisionRepository
    {
        /// <summary>
        /// Make the division calculation for the array of operands
        /// </summary>
        /// <param name="operands">Array of operands to be divided</param>
        /// <param name="trackingId">Tracking id of the operations</param>
        /// <returns>DivisionResponse for the division of all the operands</returns>
        DivisionResponse Divide(int[] operands, string trackingId);
    }
}
