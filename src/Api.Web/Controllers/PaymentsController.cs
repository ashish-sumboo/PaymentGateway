namespace Api.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using Core;
    using Core.Types;
    using Core.Application.Dtos;
    using Core.Database;
    using Core.Entities;
    using Core.Database.Stores;
    using Core.Database.Stores.Interfaces;
    using Core.Services.Interfaces;
    using Api.Web.Validators;
    using Microsoft.AspNetCore.DataProtection;
    using System.Text;

    using Helpers;
    using Core.Helpers;
    using Microsoft.Extensions.Logging;

    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/payments")]
    [Produces("application/json")]
    public class PaymentsController : Controller
    {
        private readonly IPaymentOrderService service;
        private readonly ILoggerFactory loggerFactory;
        private readonly ILogger logger;

        public PaymentsController(IPaymentOrderService service, ILoggerFactory loggerFactory)
        {
            this.service = service;
            this.loggerFactory = loggerFactory;
            logger = loggerFactory.CreateLogger(GetType());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]PaymentRequest request)
        {
            var validator = new PaymentRequestValidator();
            var errorResults = validator.Validate(request);

            if (!errorResults.IsValid)
            {
                var error = errorResults.Errors.First();
                logger.LogInformation($"An error occurred. Error Code: {error.ErrorCode} Error Message {error.ErrorMessage}");
                return ClientResponse.BadRequest(error.ErrorCode, error.ErrorMessage);
            }

            var response = await service.CreatePaymentOrder(request);

            switch (response.StatusCode)
            {
                case Status.Completed:
                    return ClientResponse.CreatedAtAction("Post", "Payments", new { Id = request.Id }, Status.Completed, Constants.Success, request.Id);
                case Status.Failed:
                    return ClientResponse.BadRequest(Status.Completed, Constants.Failure, request.Id);
                default:
                    return ClientResponse.BadRequest(Status.Completed, Constants.Failure, request.Id);
            }
        }
    }
}
