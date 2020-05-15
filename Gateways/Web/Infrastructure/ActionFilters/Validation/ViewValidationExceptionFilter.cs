﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Routing;

namespace Blog.Gateways.Web.Infrastructure.ActionFilters.Validation
{
    public class ViewValidationExceptionFilter : BaseViewExceptionFilter
    {
        public override void OnException(ExceptionContext context)
        {
            if (!context.ExceptionHandled && context.Exception is ValidationException)
            {
                ViewResult result;
                ViewDataDictionary viewData;
                var controllerName = context.RouteData.Values["controller"].ToString();
                var actionName = context.RouteData.Values["action"].ToString();
                var message = context.Exception.Message;
                //This is an antipattern. It makes discerning a class's dependencies harder.
                var tempDataFactory = context.HttpContext.RequestServices.GetService<ITempDataDictionaryFactory>();

                result = new ViewResult
                {
                    ViewName = actionName
                };

                viewData = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary());

                result.TempData = tempDataFactory.GetTempData(context.HttpContext);
                result.TempData.Add("error", message);
                result.ViewData = viewData;
                //context.Result = result;
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = controllerName, action = actionName }));
                context.ExceptionHandled = true;
            }

            base.OnException(context);
        }
    }
}
