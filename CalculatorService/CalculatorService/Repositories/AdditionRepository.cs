using CalculatorService.Entities.Addition;
using CalculatorService.Enums;
using CalculatorService.Helpers;
using CalculatorService.Interfaces.Repositories;
using System;

namespace CalculatorService.Repositories
{
    /// <summary>
    /// Repository for addition calculations
    /// </summary>
    public class AdditionRepository : IAdditionRepository
    {
        /// <summary>
        /// Make the addition calculation for the array of operands
        /// </summary>
        /// <param name="operands">Array of operands to be added</param>
        /// <param name="trackingId">Tracking id of the operations</param>
        /// <returns>AdditionResponse for the addition of all the operands</returns>
        public AdditionResponse Add(int[] operands, string trackingId)
        {
            // Make sure the operands array is not empty
            if(operands == null)
            {
                string exceptionMessage = "Operands list can not be null.";

                HistoryHelper.GetInstance()
                    .AddFailureHistoryItem(OperationTypes.Addition, operands, exceptionMessage, trackingId);

                throw new Exception(exceptionMessage);
            }

            int total = 0;

            foreach (int operand in operands)
            {
                // Make sure the operands are positive integer values
                if(operand < 0)
                {
                    string exceptionMessage = "Operands must be positive integer values.";

                    HistoryHelper.GetInstance()
                        .AddFailureHistoryItem(OperationTypes.Addition, operands, exceptionMessage, trackingId);

                    throw new Exception(exceptionMessage);
                }

                total += operand;
            }

            HistoryHelper.GetInstance()
                .AddSuccessHistoryItem(OperationTypes.Addition, operands, total, trackingId);

            return new AdditionResponse
            {
                Sum = total
            };
        }
    }
}