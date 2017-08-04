using System.Net;
using System.Net.Http;
using RestSharp;
using Volusion.Core.Api.Enums;
using Volusion.Core.Api.Responses;
using Volusion.Core.Models;

namespace Volusion.Core.Api.Helpers
{
    public static class ApiHelper
    {
        public static void SetModelStateWhenResourceNotFound(ModelState modelState, HttpResponseMessage result, string baseAddress, string requestUri)
        {
            modelState.HttpStatusCode = result.StatusCode;
            modelState.UserMessage = UserMessage.ResourceNotFound;
            modelState.LogMessage = string.Format("{0}: {1}{2}", UserMessage.ResourceNotFound, baseAddress, requestUri);
        }

        public static void SetModelStateWhenResourceNotFound(ModelState modelState, IRestResponse result, string baseUrl, string resource)
        {
            modelState.HttpStatusCode = result.StatusCode;
            modelState.UserMessage = UserMessage.ResourceNotFound;
            modelState.LogMessage = string.Format("{0}: {1}{2}", UserMessage.ResourceNotFound, baseUrl, resource);
        }

        public static void SetModelStateWhenStatusCodesInvalid(ModelState modelState, HttpResponseMessage result, StandardResponse response, string baseAddress, string requestUri)
        {
            modelState.HttpStatusCode = HttpStatusCode.InternalServerError;
            modelState.UserMessage = string.Format("HttpCode {0} != StatusCode {1}", (int)result.StatusCode, response.Status.Code);
            modelState.LogMessage = string.Format("{0}: {1}{2}", UserMessage.ResourceNotFound, baseAddress, requestUri);
        }

        public static void SetModelStateWhenStatusCodesInvalid(ModelState modelState, IRestResponse result, StandardResponse response, string baseUrl, string resource)
        {
            modelState.HttpStatusCode = HttpStatusCode.InternalServerError;
            modelState.UserMessage = string.Format("HttpCode {0} != StatusCode {1}", (int) result.StatusCode, response.Status.Code);
            modelState.LogMessage = string.Format("{0}: {1}{2}", UserMessage.ResourceNotFound, baseUrl, resource);
        }

    }
}