using CalculatorService.Entities.Substraction;
using CalculatorService.Enums;
using CalculatorService.Helpers;
using CalculatorService.Interfaces.Repositories;
using System;

namespace CalculatorService.Repositories
{
    /// <summary>
    /// Repository for substraction calculations
    /// </summary>
    public class SubstractionRepository : ISubstractionRepository
    {
        /// <summary>
        /// Make the substraction calculation for the array of operands
        /// </summary>
        /// <param name="operands">Array of operands to be substracted</param>
        /// <param name="trackingId">Tracking id of the operations</param>
        /// <returns>SubstractionResponse for the substraction of all the operands</returns>
        public SubstractionResponse Substract(int[] operands, string trackingId)
        {
            // Make sure the operands array is not empty.
            if (operands == null)
            {
                string exceptionMessage = "Operands list can not be null.";

                HistoryHelper.GetInstance()
                    .AddFailureHistoryItem(OperationTypes.Substraction, operands, exceptionMessage, trackingId);

                throw new Exception(exceptionMessage);
            }

            int total = 0;
            bool isFirst = true;

            foreach (int operand in operands)
            {
                // Make sure the operands are positive integer values
                if (operand < 0)
                {
                    string exceptionMessage = "Operands must be positive integer values.";

                    HistoryHelper.GetInstance()
                        .AddFailureHistoryItem(OperationTypes.Substraction, operands, exceptionMessage, trackingId);

                    throw new Exception(exceptionMessage);
                }

                //Take the first operand to start the substraction
                if (isFirst)
                {
                    total = operand;
                    isFirst = false;
                }
                else
                {
                    total -= operand;
                }
            }

            HistoryHelper.GetInstance()
                .AddSuccessHistoryItem(OperationTypes.Substraction, operands, total, trackingId);

            return new SubstractionResponse
            {
                Difference = total
            };
        }
    }
}