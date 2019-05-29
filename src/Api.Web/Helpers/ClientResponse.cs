namespace Api.Web.Helpers
{
    using Microsoft.AspNetCore.Mvc;

    using Core.Application.Dtos;
    using Core.Types;

    public static class ClientResponse
    {
        public static CreatedAtActionResult CreatedAtAction(string actionName, string controllerName, object routeValues, Status status, string message, string paymentId)
        {
            return new CreatedAtActionResult(actionName, controllerName, routeValues, new ClientResponseDto(paymentId, status, message));
        }

        public static BadRequestObjectResult BadRequest(Status status, string message, string paymentId)
        {
            return new BadRequestObjectResult(new ClientResponseDto(paymentId, status, message));
        }

        public static NotFoundObjectResult NotFound(Status status, string message, string paymentId)
        {
            return new NotFoundObjectResult(new ClientResponseDto(paymentId, status, message));
        }

        public static BadRequestObjectResult BadRequest(string code, string message)
        {
            return new BadRequestObjectResult(new ErrorResponseDto(code, message));
        }
    }
}
