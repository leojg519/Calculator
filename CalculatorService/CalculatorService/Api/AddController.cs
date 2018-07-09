using CalculatorService.Entities.Addition;
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
    /// Api controller for Addition operation
    /// </summary>
    public class AddController : ApiController
    {
        /// <summary>
        /// Addition repository
        /// </summary>
        private readonly IAdditionRepository repository;

        /// <summary>
        /// Constructor for test propuses
        /// </summary>
        /// <param name="additionRepository"></param>
        public AddController(IAdditionRepository additionRepository)
        {
            repository = additionRepository;
        }

        /// <summary>
        /// Empty constructor
        /// </summary>
        public AddController()
        {
            repository = new AdditionRepository();
        }

        /// <summary>
        /// Addition operation
        /// </summary>
        /// <param name="Addends">Operands to be added</param>
        [Route("Calculator/Add")]
        public HttpResponseMessage Post([FromBody]AdditionRequest request)
        {
            var jsonFormatter = new JsonMediaTypeFormatter();
            string trackingId = null;

            if (Request.Headers.Contains("X-Evi-Tracking-Id"))
            {
                trackingId = Request.Headers.GetValues("X-Evi-Tracking-Id").First();
            }

            try
            {
                var response = new HttpResponseDto<AdditionResponse>
                {
                    Status = HttpStatusCode.OK.ToString(),
                    Code = (int)HttpStatusCode.OK,
                    Message = repository.Add(request.Addends, trackingId)
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