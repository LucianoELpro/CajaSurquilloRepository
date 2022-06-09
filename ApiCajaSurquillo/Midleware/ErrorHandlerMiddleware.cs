using Application.Wrappers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApiPrueba.Midleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);

            }
            catch (Exception error)
            {

                var httpResponse = context.Response;
                httpResponse.ContentType = "application/json";
                var responseModel = new Response<string>
                {
                    Message = error?.Message,
                    Accomplished = false,
                };

                switch (error)
                {
                            case Application.Exceptions.ApiException e:
                        httpResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                            case Application.Exceptions.ValidationException e:
                        httpResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                        responseModel.Errors = e.Errors;
                        break;
                            case KeyNotFoundException e:
                        httpResponse.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                            default:
                        httpResponse.StatusCode = (int)HttpStatusCode.InternalServerError; 
                        break;
                }
                var JsonResponse = JsonSerializer.Serialize(responseModel);
                await httpResponse.WriteAsync(JsonResponse);
            }
        }
    }
   
}
