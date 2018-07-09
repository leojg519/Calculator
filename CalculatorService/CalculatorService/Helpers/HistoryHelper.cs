using CalculatorService.Entities.History;
using CalculatorService.Entities.Query;
using CalculatorService.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CalculatorService.Helpers
{
    /// <summary>
    /// Static helper to keep track of the performed calculations
    /// </summary>
    public class HistoryHelper
    {
        /// <summary>
        /// History helper instance
        /// </summary>
        private static HistoryHelper Instance = null;

        /// <summary>
        /// History track of performed operations
        /// </summary>
        private IList<HistoryItem> historyItems = new List<HistoryItem>();

        /// <summary>
        /// Private constructor
        /// </summary>
        private HistoryHelper() { }

        /// <summary>
        /// Singleton pattern implementation for History helper
        /// </summary>
        /// <returns></returns>
        public static HistoryHelper GetInstance()
        {
            if (Instance == null)
            {
                Instance = new HistoryHelper();
            }

            return Instance;
        }

        /// <summary>
        /// Get the registries of all the performed operations
        /// </summary>
        public IList<HistoryItem> GetAllHistoryItems()
        {
            return historyItems;
        }

        /// <summary>
        /// Get the registry of a performed operation by Id
        /// </summary>
        /// <param name="id">Id of the performed operation</param>
        /// <returns>Data of the performed operation requested</returns>
        public QueryResponse GetHistoryItemById(string id)
        {
            return new QueryResponse
            {
                Operations = historyItems.First(item => item.TrackingId == id).Operations
            };
        }

        /// <summary>
        /// Add new history item on succes operation
        /// </summary>
        /// <param name="operationType">Type of calculation performed</param>
        /// <param name="operands">Array of operands used to permorm the calculation</param>
        /// <param name="message">Exception message</param>
        public void AddSuccessHistoryItem(
            OperationTypes operationType, int[] operands, double result, string trackingId)
        {
            if (trackingId != null)
            {
                string calculationText = GetCalculationText(
                    operationType, operands, Math.Round(result, 5).ToString());
                HistoryItem historyItem = GetOrCreateHistoryItem(trackingId);

                historyItem.Operations.Add(new QueryItemResponse()
                {
                    Operation = operationType.ToString(),
                    Calculation = calculationText,
                    Date = DateTime.Now.ToString()
                });
            }
        }

        /// <summary>
        /// Add new history item on failure operation
        /// </summary>
        /// <param name="operationType">Type of calculation performed</param>
        /// <param name="operands">Array of operands used to permorm the calculation</param>
        /// <param name="message">Exception message</param>
        public void AddFailureHistoryItem(
            OperationTypes operationType, int[] operands, string message, string trackingId)
        {
            if (trackingId != null)
            {
                HistoryItem historyItem = GetOrCreateHistoryItem(trackingId);

                historyItem.Operations.Add(new QueryItemResponse()
                {
                    Operation = operationType.ToString(),
                    Date = DateTime.Now.ToString(),
                    Calculation = message
                });
            }
        }

        /// <summary>
        /// Get calculation text for the operation
        /// </summary>
        /// <param name="operationType">Operation type</param>
        /// <param name="operands">Operands used to perform the operation</param>
        /// <returns>Calculation in text</returns>
        private string GetCalculationText(OperationTypes operationType, int[] operands, string result)
        {
            string calculationText = "";
            string operatorSymbol = GetOperatorSymbol(operationType);
            bool isFirst = true;

            foreach (int operand in operands)
            {
                if (isFirst && operationType != OperationTypes.SquareRoot)
                {
                    isFirst = false;
                }
                else
                {
                    calculationText += operatorSymbol;
                }

                calculationText += operand.ToString();
            }

            calculationText += " = " + result;

            return calculationText;
        }

        /// <summary>
        /// Get or create History Item for the corresponding Tracking Id
        /// </summary>
        /// <param name="trackingId">Tracking Id</param>
        /// <returns>The corresponding History Item </returns>
        private HistoryItem GetOrCreateHistoryItem(string trackingId)
        {
            HistoryItem historyItem = historyItems.FirstOrDefault(item => item.TrackingId == trackingId);

            if (historyItem == null)
            {
                historyItem = new HistoryItem
                {
                    TrackingId = trackingId,
                    Operations = new List<QueryItemResponse>()
                };

                historyItems.Add(historyItem);
            }

            return historyItem;
        }

        /// <summary>
        /// Get the symbol corresponding to the operation type
        /// </summary>
        /// <param name="operationType">Operation type</param>
        /// <returns>Symbol corresponding to the operation type</returns>
        private string GetOperatorSymbol(OperationTypes operationType)
        {
            switch (operationType)
            {
                case OperationTypes.Addition:
                    return " + ";

                case OperationTypes.Substraction:
                    return " - ";

                case OperationTypes.Multiplication:
                    return " x ";

                case OperationTypes.Division:
                    return " &#247; ";

                case OperationTypes.SquareRoot:
                    return " &#8730; ";
            }

            return "";
        }
    }
}