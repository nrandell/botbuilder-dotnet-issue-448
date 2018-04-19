using Microsoft.Extensions.Logging;
using Microsoft.Rest;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace BotIssue448Demo
{
    public class LoggerTracingInterceptor : IServiceClientTracingInterceptor
    {
        public ILogger _logger;

        public LoggerTracingInterceptor(ILogger logger)
        {
            _logger = logger;
        }

        public void Configuration(string source, string name, string value) =>
            _logger.LogTrace("Configuration {Source} {Name} {Value}", source, name, value);

        public void EnterMethod(string invocationId, object instance, string method, IDictionary<string, object> parameters) =>
            _logger.LogTrace("EnterMethod {InvocationId} {Instance} {Method} ({Parameters})", invocationId, instance, method, parameters.AsFormattedString());

        public void ExitMethod(string invocationId, object returnValue) =>
            _logger.LogTrace("ExitMethod {InvocationId} {ReturnValue}", invocationId, returnValue);

        public void Information(string message) => _logger.LogInformation("{Messge}", message);

        public void ReceiveResponse(string invocationId, HttpResponseMessage response) =>
            _logger.LogTrace("ReceiveResponse {InvocationId} {Response}", invocationId, response.AsFormattedString());

        public void SendRequest(string invocationId, HttpRequestMessage request) =>
            _logger.LogTrace("SendRequest {InvocationId} {Request}", invocationId, request.AsFormattedString());

        public void TraceError(string invocationId, Exception exception) =>
            _logger.LogError(exception, "Error {InvocationId} {Exception}", invocationId, exception.Message);
    }
}
