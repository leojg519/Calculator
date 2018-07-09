using CalculatorService.Entities.Division;
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
    /// Api controller for Division operation
    /// </summary>
    public class DivController : ApiController
    {
        /// <summary>
        /// Division repository
        /// </summary>
        private readonly IDivisionRepository repository;

        /// <summary>
        /// Constructor for test propuses
        /// </summary>
        /// <param name="divisionRepository"></param>
        public DivController(IDivisionRepository divisionRepository)
        {
            repository = divisionRepository;
        }

        /// <summary>
        /// Empty constructor
        /// </summary>
        public DivController()
        {
            repository = new DivisionRepository();
        }

        /// <summary>
        /// Division operation
        /// </summary>
        /// <param name="Dividend">Dividend to perform the division</param>
        /// <param name="Divisor">Divisor to perform the division</param>
        /// <param name="trackingId">Tracking id of the operations</param>
        [Route("Calculator/Div")]
        public HttpResponseMessage Post([FromBody]DivisionRequest request)
        {
            var jsonFormatter = new JsonMediaTypeFormatter();
            string trackingId = null;

            if (Request.Headers.Contains("X-Evi-Tracking-Id"))
            {
                trackingId = Request.Headers.GetValues("X-Evi-Tracking-Id").First();
            }
            
            try
            {
                var response = new HttpResponseDto<DivisionResponse>
                {
                    Status = HttpStatusCode.OK.ToString(),
                    Code = (int)HttpStatusCode.OK,
                    Message = repository
                    .Divide(new int[] { request.Dividend, request.Divisor }, trackingId)
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