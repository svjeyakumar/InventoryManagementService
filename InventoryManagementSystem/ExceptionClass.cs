﻿using InventoryManagementSystem.Repository.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace InventoryManagementSystem
{
    public static class ExceptionClass
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILog log)
        {
            app.UseExceptionHandler(appError =>
            { appError.Run(async context =>
                 { context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                 context.Response.ContentType = "application/json";

                 var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                     if (contextFeature != null)
                     {
                         log.LogError($"Something went wrong : {contextFeature.Error}");

                         await context.Response.WriteAsync(new ErrorDetails()
                         {
                             Statuscode = context.Response.StatusCode,
                             Message = "Internal Server Error. Error generated by NLog"
                         }.ToString());
                     }
                 });
            });
        }
    }
           
}
