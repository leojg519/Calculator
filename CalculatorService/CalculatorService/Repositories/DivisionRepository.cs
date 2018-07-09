using CalculatorService.Entities.Division;
using CalculatorService.Enums;
using CalculatorService.Helpers;
using CalculatorService.Interfaces.Repositories;
using System;

namespace CalculatorService.Repositories
{
    /// <summary>
    /// Repository for division calculations
    /// </summary>
    public class DivisionRepository : IDivisionRepository
    {
        /// <summary>
        /// Make the division calculation for the array of operands
        /// </summary>
        /// <param name="operands">Array of operands to be divided</param>
        /// <param name="trackingId">Tracking id of the operations</param>
        /// <returns>DivisionResponse for the division of all the operands</returns>
        public DivisionResponse Divide(int[] operands, string trackingId)
        {
            // Make sure the operands array is not empty.
            if (operands == null)
            {
                string exceptionMessage = "Operands list can not be null.";

                HistoryHelper.GetInstance()
                    .AddFailureHistoryItem(OperationTypes.Division, operands, exceptionMessage, trackingId);

                throw new Exception(exceptionMessage);
            }

            int quotient = 0;
            int remainder = 0;
            bool isFirst = true;

            foreach (int operand in operands)
            {
                // Make sure the operands are positive integer values
                if (operand < 0)
                {
                    string exceptionMessage = "Operands must be positive integer values.";

                    HistoryHelper.GetInstance()
                        .AddFailureHistoryItem(OperationTypes.Division, operands, exceptionMessage, trackingId);

                    throw new Exception(exceptionMessage);
                }

                //Take the first operand to start the division
                if (isFirst)
                {
                    quotient = operand;
                    remainder = operand;
                    isFirst = false;
                }
                else
                {
                    // Avoid division by zero
                    if (operand == 0)
                    {
                        string exceptionMessage = "Division by zero can not be performed.";

                        HistoryHelper.GetInstance()
                            .AddFailureHistoryItem(OperationTypes.Division, operands, exceptionMessage, trackingId);

                        throw new Exception(exceptionMessage);
                    }

                    quotient /= operand;
                    remainder %= operand;
                }
            }

            HistoryHelper.GetInstance()
                .AddSuccessHistoryItem(OperationTypes.Division, operands, quotient, trackingId);

            return new DivisionResponse
            {
                Quotient = quotient,
                Remainder = remainder
            };
        }
    }
}