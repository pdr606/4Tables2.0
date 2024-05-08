using _4Tables2._0.Domain.Base.Common;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace _4Tables.Base
{
    [ApiController]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class BaseController : Controller
    {
        protected ActionResult ResponseBase(
            HttpStatusCode statusCode,
            BasicResult basicResult,
            string responseMessage,
            HttpStatusCode statusCodeError = HttpStatusCode.NotFound)
        {
            if (basicResult.IsFailure)
            {
                basicResult.Error.StatusCode = (int)statusCodeError;
                return StatusCode(basicResult.Error.StatusCode, new BaseResponse<Error>(basicResult.Error));
            }

            return StatusCode((int)statusCode, responseMessage);
        }

        protected ActionResult ResponseBase<T>(
            HttpStatusCode statusCode,
            BasicResult<T> basicResult,
            HttpStatusCode statusCodeError = HttpStatusCode.NotFound)
        {
            if (basicResult.IsFailure)
            {
                basicResult.Error.StatusCode = (int)statusCodeError;
                return StatusCode(basicResult.Error.StatusCode, basicResult.Error);
            }

            return StatusCode((int)statusCode, new BaseResponse<T>(basicResult.Value));
        }
    }
}
