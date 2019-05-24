//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Filters;
//
//namespace LoginCodeFirst.Filter
//{
//    public class ActionFilter: IActionFilter
//    {
//        public void OnActionExecuting(ActionExecutingContext context)
//        {
//            var httpContext = context.HttpContext;
//            if (httpContext.Session.GetString("fullname") == null)
//            {
//                context.Result = new UnauthorizedResult();
//            }
//        }
//        
//        public void OnActionExecuted(ActionExecutedContext context)
//        {
//        }
//    }
//}