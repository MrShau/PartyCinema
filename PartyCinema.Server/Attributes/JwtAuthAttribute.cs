using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PartyCinema.Server.Services;
using System.Net;

namespace PartyCinema.Server.Attributes
{
    public class JwtAuthAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var token = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (token == null)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                context.HttpContext.Response.Headers["WWW-Authenticate"] = "Bearer";
                context.Result = new JsonResult(new { message = "Unauthorized" });
            }
            else
            {
                var authService = context.HttpContext.RequestServices.GetRequiredService<JwtService>();
                var user = authService.Verify(token);
                if (user == null)
                {
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    context.HttpContext.Response.Headers["WWW-Authenticate"] = "Bearer";
                    context.Result = new JsonResult(new { message = "Unauthorized" });
                }
            }
            base.OnActionExecuting(context);
        }
    }
}
