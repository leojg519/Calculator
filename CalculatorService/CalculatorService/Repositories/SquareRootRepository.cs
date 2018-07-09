using CalculatorService.Entities.SquareRoot;
using CalculatorService.Enums;
using CalculatorService.Helpers;
using CalculatorService.Interfaces.Repositories;
using System;

namespace CalculatorService.Repositories
{
    /// <summary>
    /// Repository for square root calculations
    /// </summary>
    public class SquareRootRepository : ISquareRootRepository
    {
        /// <summary>
        /// Make the square root calculation for the operand
        /// </summary>
        /// <param name="operand">Operand to be calculated the square root</param>
        /// <param name="trackingId">Tracking id of the operations</param>
        /// <returns>SquareRootResponse for the square root of the operand</returns>
        public SquareRootResponse SquareRoot(int operand, string trackingId)
        {
            double total = 0;

            // Make sure the operand is a positive integer value
            if(operand < 0)
            {
                string exceptionMessage = "Operand must be a positive integer value.";

                HistoryHelper.GetInstance()
                    .AddFailureHistoryItem(OperationTypes.SquareRoot, new int[] { operand }, exceptionMessage, trackingId);

                throw new Exception(exceptionMessage);
            }

            total = Math.Sqrt(operand);

            HistoryHelper.GetInstance()
                .AddSuccessHistoryItem(OperationTypes.SquareRoot, new int[] { operand }, total, trackingId);

            return new SquareRootResponse
            {
                Square = total
            };
        }
    }
}