using CalculatorService.Entities.SquareRoot;
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
    /// Api controller for Square Root operation
    /// </summary>
    public class SqrtController : ApiController
    {
        /// <summary>
        /// Square Root repository
        /// </summary>
        private readonly ISquareRootRepository repository;

        /// <summary>
        /// Constructor for test propuses
        /// </summary>
        /// <param name="squareRootRepository"></param>
        public SqrtController(ISquareRootRepository squareRootRepository)
        {
            repository = squareRootRepository;
        }

        /// <summary>
        /// Empty constructor
        /// </summary>
        public SqrtController()
        {
            repository = new SquareRootRepository();
        }

        /// <summary>
        /// Square Root operation
        /// </summary>
        /// <param name="Number">Number to get the square root</param>
        /// <param name="trackingId">Tracking id of the operations</param>
        [Route("Calculator/Sqrt")]
        public HttpResponseMessage Post([FromBody]SquareRootRequest request)
        {
            var jsonFormatter = new JsonMediaTypeFormatter();
            string trackingId = null;

            if (Request.Headers.Contains("X-Evi-Tracking-Id"))
            {
                trackingId = Request.Headers.GetValues("X-Evi-Tracking-Id").First();
            }

            try
            {
                var response = new HttpResponseDto<SquareRootResponse>
                {
                    Status = HttpStatusCode.OK.ToString(),
                    Code = (int)HttpStatusCode.OK,
                    Message = repository.SquareRoot(request.Number, trackingId)
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