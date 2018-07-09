using CalculatorService.Entities.Substraction;
using CalculatorService.Interfaces.Repositories;
using CalculatorService.Repositories;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Linq;
using CalculatorService.DTO;

namespace CalculatorService.Api
{
    /// <summary>
    /// Api controller for Substraction operation
    /// </summary>
    public class SubController : ApiController
    {
        /// <summary>
        /// Substraction repository
        /// </summary>
        private readonly ISubstractionRepository repository;

        /// <summary>
        /// Constructor for test propuses
        /// </summary>
        /// <param name="substractionRepository"></param>
        public SubController(ISubstractionRepository substractionRepository)
        {
            repository = substractionRepository;
        }

        /// <summary>
        /// Empty constructor
        /// </summary>
        public SubController()
        {
            repository = new SubstractionRepository();
        }

        /// <summary>
        /// Substraction operation
        /// </summary>
        /// <param name="Minuend">Minuend to perform the substraction</param>
        /// <param name="Subtrahend">Subtrahend to perform the substraction</param>
        /// <param name="trackingId">Tracking id of the operations</param>
        [Route("Calculator/Sub")]
        public HttpResponseMessage Post([FromBody]SubstractionRequest request)
        {
            var jsonFormatter = new JsonMediaTypeFormatter();
            string trackingId = null;

            if (Request.Headers.Contains("X-Evi-Tracking-Id"))
            {
                trackingId = Request.Headers.GetValues("X-Evi-Tracking-Id").First();
            }

            try
            {
                var response = new HttpResponseDto<SubstractionResponse>
                {
                    Status = HttpStatusCode.OK.ToString(),
                    Code = (int)HttpStatusCode.OK,
                    Message = repository
                        .Substract(new int[] { request.Minuend, request.Subtrahend }, trackingId)
                };
                
                // In case of success, return a Json with the corresponding calculation total
                return Request.CreateResponse(HttpStatusCode.OK, response, jsonFormatter);
            }
            catch (Exception ex)
            {
                var response = new HttpResponseDto<string>
                {
                    Status = HttpStatusCode.BadRequest.ToString(),
                    Code = (int)HttpStatusCode.BadRequest,
                    Message = ex.Message
                };

                // In case of error, return a Json with the corresponding message to be shown
                return Request.CreateResponse(HttpStatusCode.BadRequest, response, jsonFormatter);
            }
        }
    }
}