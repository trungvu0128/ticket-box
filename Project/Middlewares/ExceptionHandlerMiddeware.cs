using Newtonsoft.Json.Linq;
using Project.Models.Constants;
using Shared.Tracking;
using System.Diagnostics;
using System.Net;

namespace Project.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        private readonly ITrackingLog _trackingLog;
        private static readonly List<string> IgnorePath = new();
        public ExceptionHandlerMiddleware(RequestDelegate requestDelegate, ITrackingLog trackingLog
            )
        {
            _requestDelegate = requestDelegate;
            _trackingLog = trackingLog;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            using MemoryStream memoryStream = new();
            Stream originalResponseBody = httpContext.Response.Body;
            httpContext.Response.Body = memoryStream;
            Stopwatch stopwatch = new();
            Exception? exception = null;
            JObject? responseData = null;
            try
            {
                stopwatch.Start();
                _trackingLog.LogInfo($"Api {httpContext.Request.Path} start process in {DateTime.Now}");
                httpContext.Response.OnStarting(() =>
                {
                    stopwatch.Stop();
                    _trackingLog.LogInfo($"Api {httpContext.Request.Path} end process in {DateTime.Now} with execution time {stopwatch.Elapsed}");
                    return Task.CompletedTask;
                });
                await _requestDelegate(httpContext);
                stopwatch.Stop();
            }
            catch (Exception ex)
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                stopwatch.Stop();
                _trackingLog.LogInfo($"Api {httpContext.Request.Path} in {DateTime.Now} with execution time {stopwatch.Elapsed} \n thow exeption: {ex.GetBaseException()}");
                exception = ex;
            }
            finally
            {
                if (!IgnorePath.Contains(httpContext.Request.Path))
                {
                    memoryStream.Position = 0;
                    httpContext.Response.Body = originalResponseBody;
                    httpContext.Response.ContentLength = null;
                    responseData = new()
                    {
                        [Core.Constants.BaseResponseMessage.EXECUTION_TIME] = stopwatch.Elapsed
                    };
                    if (exception != null)
                    {
                        responseData.Add(Core.Constants.BaseResponseMessage.STATUS_CODE, (int)HttpStatusCode.InternalServerError);
                        responseData.Add(Core.Constants.BaseResponseMessage.MESSAGE, Core.Constants.BaseResponseMessage.INTERNAL_SERVER_ERROR);
                        //responseData.Add("displayMessage", _stringLocalizer.GetString(ResponseMessage.InternalServerError).Value ?? ResponseMessage.InternalServerError);
                        responseData.Add(Core.Constants.BaseResponseMessage.EXCEPTION, exception.GetBaseException().ToString());
                    }
                    else
                    {
                        stopwatch.Stop();
                        responseData.Add(Core.Constants.BaseResponseMessage.STATUS_CODE, httpContext.Response.StatusCode);
                        string responseOriginData = await new StreamReader(memoryStream).ReadToEndAsync();
                        (bool resultParse, JToken? dataResponse) = IsValidJson(responseOriginData);
                        if (httpContext.Response.StatusCode == (int)HttpStatusCode.BadRequest)
                        {
                            responseData.Add(Core.Constants.BaseResponseMessage.MESSAGE, Core.Constants.BaseResponseMessage.BAD_REQUEST);
                            // Check error from fluent validation
                            if (dataResponse != null && dataResponse.Type == JTokenType.Object)
                            {
                                Dictionary<string, List<string>>? errors = dataResponse?[Core.Constants.BaseResponseMessage.ERRORS]?.ToObject<Dictionary<string, List<string>>>();
                                responseData.Add(Core.Constants.BaseResponseMessage.ERROR_MESSAGES, JToken.FromObject(errors?.SelectMany(s => s.Value) ?? Array.Empty<string>()));
                                //responseData.Add("displayMessage", _stringLocalizer.GetString(errors?.SelectMany(s => s.Value).FirstOrDefault() ?? string.Empty).Value);
                            }
                            // Else errors come from controller
                            else
                            {
                                responseData.Add(Core.Constants.BaseResponseMessage.ERROR_MESSAGES, dataResponse);
                                var data = dataResponse?.First?.Value<string>();
                                //responseData.Add("displayMessage", _stringLocalizer.GetString(dataResponse?.First?.Value<string>() ?? string.Empty).Value);
                            }
                        }
                        else if (httpContext.Response.StatusCode == (int)HttpStatusCode.OK)
                        {
                            responseData.Add(Core.Constants.BaseResponseMessage.MESSAGE, Core.Constants.BaseResponseMessage.SUCCESS);
                            //responseData.Add("displayMessage", _stringLocalizer.GetString(ResponseMessage.Success).Value ?? ResponseMessage.Success);
                            responseData.Add(Core.Constants.BaseResponseMessage.DATA, dataResponse);
                        }
                    }
                    httpContext.Response.ContentType = Core.Constants.BaseResponseMessage.JSON_CONTENT_TYPE;
                    await httpContext.Response.WriteAsync(responseData.ToString());
                }
                else
                {
                    memoryStream.Position = 0;
                    await memoryStream.CopyToAsync(originalResponseBody);
                    httpContext.Request.Body = originalResponseBody;
                }
            }
        }

        private (bool resultParse, JToken? dataParse) IsValidJson(string strInput)
        {
            try
            {
                JToken token = JToken.Parse(strInput);
                return (true, token);
            }
            catch (Exception)
            {
                return (false, null);
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ExceptionHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandlerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}
