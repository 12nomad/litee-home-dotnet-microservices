using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Common.Exception.Extensions;

public static class ExceptionHandlerExtension {
  public static void ConfigureExceptionHandler(this IApplicationBuilder application) {
    application.Run(async context => {
      var logger = context.RequestServices.GetRequiredService<ILoggerFactory>().CreateLogger("DotNet Custom Exception Handler");
      var env = context.RequestServices.GetRequiredService<IHostEnvironment>();
      var exception = context.Features.Get<IExceptionHandlerFeature>();
      var error = exception?.Error;

      if (error is null) return;

      logger.LogError("Something went wrong. Error: {Error}", error.Message);
      var problemDetails = new ProblemDetails {
        Title = error.Message,
        Status = error is ValidationException ? StatusCodes.Status400BadRequest : StatusCodes.Status500InternalServerError,
        Extensions = {
          {"path", context.Request.Path},
          {"method", context.Request.Method},
          {"traceId", context.TraceIdentifier},
        }
      };

      if (env.IsDevelopment()) problemDetails.Detail = error?.ToString();

      await Results.Problem(problemDetails).ExecuteAsync(context);
    });
  }
}
