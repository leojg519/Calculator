namespace CalculatorService.DTO
{
    /// <summary>
    /// DTO for HTTP responses
    /// </summary>
    public class HttpResponseDto<T>
    {
        /// <summary>
        /// HTTP Response code
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// HTTP Response status
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// HTTP respones message
        /// </summary>
        public T Message { get; set; }
    }
}