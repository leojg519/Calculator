using CalculatorService.Entities.Multiplication;
using CalculatorService.Enums;
using CalculatorService.Helpers;
using CalculatorService.Interfaces.Repositories;
using System;

namespace CalculatorService.Repositories
{
    /// <summary>
    /// Repository for multiplication calculations
    /// </summary>
    public class MultiplicationRepository : IMultiplicationRepository
    {
        /// <summary>
        /// Make the multiplication calculation for the array of operands
        /// </summary>
        /// <param name="operands">Array of operands to be multiplied</param>
        /// <param name="trackingId">Tracking id of the operations</param>
        /// <returns>MultiplicationResponse for the multiplication of all the operands</returns>
        public MultiplicationResponse Multiply(int[] operands, string trackingId)
        {
            // Make sure the operands array is not empty
            if (operands == null)
            {
                string exceptionMessage = "Operands list can not be null.";

                HistoryHelper.GetInstance()
                    .AddFailureHistoryItem(OperationTypes.Multiplication, operands, exceptionMessage, trackingId);

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
                        .AddFailureHistoryItem(OperationTypes.Multiplication, operands, exceptionMessage, trackingId);

                    throw new Exception(exceptionMessage);
                }

                //Take the first operand to start the multiplication
                if (isFirst)
                {
                    total = operand;
                    isFirst = false;
                }
                else
                {
                    total *= operand;
                }
            }

            HistoryHelper.GetInstance()
                .AddSuccessHistoryItem(OperationTypes.Multiplication, operands, total, trackingId);

            return new MultiplicationResponse
            {
                Product = total
            };
        }
    }
}