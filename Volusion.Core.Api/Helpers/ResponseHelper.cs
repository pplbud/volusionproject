using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using log4net;
using Volusion.Core.Api.Responses;
using Volusion.Core.Models;

namespace Volusion.Core.Api.Helpers
{
    public static class ResponseHelper
    {
        private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static HttpResponseMessage HttpResponseMessage(HttpRequestMessage request, StandardResponse response, HttpStatusCode httpStatusCode, string userMessage, string logMessage)
        {
            response.Status.Code = Convert.ToInt32(httpStatusCode);
            response.Status.Description = httpStatusCode.ToString();
            response.Status.UserMessage = userMessage;
            response.Status.LogMessage = logMessage;

            Logger.Info(httpStatusCode.ToString());

            switch (httpStatusCode)
            {
                case HttpStatusCode.BadRequest:
                    Logger.Warn(response.Status.LogMessage);
                    break;

                case HttpStatusCode.InternalServerError:
                    Logger.Error(response.Status.LogMessage);
                    break;
            }

            return request.CreateResponse(httpStatusCode, response);
        }

        public static HttpResponseMessage HttpResponseMessage(ApiController controller, StandardResponse response, HttpStatusCode httpStatusCode, string userMessage, string logMessage)
        {
            response.Status.Code = Convert.ToInt32(httpStatusCode);
            response.Status.Description = httpStatusCode.ToString();
            response.Status.UserMessage = userMessage;
            response.Status.LogMessage = logMessage;

            Logger.Info(httpStatusCode.ToString());

            switch (httpStatusCode)
            {
                case HttpStatusCode.BadRequest:
                    Logger.Warn(response.Status.LogMessage);
                    break;

                case HttpStatusCode.InternalServerError:
                    Logger.Error(response.Status.LogMessage);
                    break;
            }

            return controller.Request.CreateResponse(httpStatusCode, response);
        }

        public static HttpResponseMessage HttpResponseMessage(ApiController controller, StandardResponse response, ModelState modelState)
        {
            response.Status.Code = Convert.ToInt32(modelState.HttpStatusCode);
            response.Status.Description = modelState.HttpStatusCode.ToString();
            response.Status.UserMessage = modelState.UserMessage;
            response.Status.LogMessage = modelState.LogMessage;

            return controller.Request.CreateResponse(modelState.HttpStatusCode, response);
        }

        public static HttpResponseMessage HttpResponseMessage(ApiController controller, StandardResponse response)
        {
            var httpStatusCode = (HttpStatusCode)response.Status.Code;
            return controller.Request.CreateResponse(httpStatusCode, response);
        }
    }
}