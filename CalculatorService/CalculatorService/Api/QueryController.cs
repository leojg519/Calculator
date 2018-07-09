using CalculatorService.DTO;
using CalculatorService.Entities.Query;
using CalculatorService.Interfaces.Repositories;
using CalculatorService.Repositories;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace CalculatorService.Api
{
    /// <summary>
    /// Api controller for History Query operation
    /// </summary>
    public class QueryController : ApiController
    {
        /// <summary>
        /// History repository
        /// </summary>
        private readonly IQueryRepository repository;

        /// <summary>
        /// Constructor for test propuses
        /// </summary>
        /// <param name="queryRepository"></param>
        public QueryController(IQueryRepository queryRepository)
        {
            repository = queryRepository;
        }

        /// <summary>
        /// Empty constructor
        /// </summary>
        public QueryController()
        {
            repository = new QueryRepository();
        }

        /// <summary>
        /// Query operation
        /// </summary>
        /// <param name="Id">Tracking id of the operation</param>
        [Route("Journal/Query")]
        public HttpResponseMessage Post([FromBody]QueryRequest request)
        {
            var jsonFormatter = new JsonMediaTypeFormatter();

            try
            {
                var response = new HttpResponseDto<QueryResponse>
                {
                    Status = HttpStatusCode.OK.ToString(),
                    Code = (int)HttpStatusCode.OK,
                    Message = repository.GetHistoryItemById(request.Id)
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