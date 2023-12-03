using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Authorization
{
    //[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class,AllowMultiple = true,Inherited = true)]
    //public class LogActionFilterAttribute:ActionFilterAttribute
    //{
    //    public override void OnActionExecuting(ActionExecutingContext context)
    //    {
    //        string controllerName = context.Controller.GetType().Name;
    //        string actionName = context.ActionDescriptor.DisplayName;

    //        Console.WriteLine($"Controller:{controllerName},Action:{actionName}");

    //        base.OnActionExecuting(context);
    //    }
    //}

    //[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    //public class AuthorizeApi : Attribute, IAsyncAuthorizationFilter
    //{
    //    public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
    //    {
    //        Console.WriteLine("Check api");
    //        string token = context?.HttpContext?.Request?.Headers["Access-Token"];
    //        if (string.IsNullOrEmpty(token))
    //        {
    //            await Task.Run(() => Console.WriteLine("Check api at is null"));
    //            context.HttpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
    //            context.Result = new JsonResult("Unauthorized");
    //            return;
    //        }
    //        else
    //        {
    //            //context.HttpContext.Session.Get<AccessToken>(token);
    //            if (user != null)
    //            {
    //                if (user.ExpData >= DateTime.Now)
    //                {
    //                    context.HttpContext.Session.Set(SessionKey.UserId, user.UserID);
    //                    context.HttpContext.Session.Set(SessionKey.AccessToken, token);
    //                    return;
    //                }
    //                else
    //                {
    //                    context.HttpContext.Session.Remove(token);
    //                }\
    //            }
    //            context.HttpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
    //            context.Result = new JsonResult("Unauthorized");
    //            return;
    //        }
    //    }
    //}
}
