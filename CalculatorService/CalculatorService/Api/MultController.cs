using CalculatorService.Entities.Multiplication;
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
    /// Api controller for Multiplication operation
    /// </summary>
    public class MultController : ApiController
    {
        /// <summary>
        /// Multiplication repository
        /// </summary>
        private readonly IMultiplicationRepository repository;

        /// <summary>
        /// Constructor for test propuses
        /// </summary>
        /// <param name="multiplicationRepository"></param>
        public MultController(IMultiplicationRepository multiplicationRepository)
        {
            repository = multiplicationRepository;
        }

        /// <summary>
        /// Empty constructor
        /// </summary>
        public MultController()
        {
            repository = new MultiplicationRepository();
        }

        /// <summary>
        /// Multiplication operation
        /// </summary>
        /// <param name="Factors">Operands to be multiplied</param>
        /// <param name="trackingId">Tracking id of the operations</param>
        [Route("Calculator/Mult")]
        public HttpResponseMessage Post([FromBody]MultiplicationRequest request)
        {
            var jsonFormatter = new JsonMediaTypeFormatter();
            string trackingId = null;

            if (Request.Headers.Contains("X-Evi-Tracking-Id"))
            {
                trackingId = Request.Headers.GetValues("X-Evi-Tracking-Id").First();
            }

            try
            {
                var response = new HttpResponseDto<MultiplicationResponse>
                {
                    Status = HttpStatusCode.OK.ToString(),
                    Code = (int)HttpStatusCode.OK,
                    Message = repository.Multiply(request.Factors, trackingId)
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