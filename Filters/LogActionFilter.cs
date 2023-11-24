using Microsoft.AspNetCore.Mvc.Filters;

namespace lr11.Filters
{
    public class LogActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string controller = context.RouteData.Values["controller"].ToString(),
                   action     = context.RouteData.Values["action"].ToString();

            string filePath = @"D:\Учёба\.Net\lr11\lr11\App_Data\ActionLog.txt";
            using (StreamWriter writer = File.AppendText(filePath))
            {
                writer.WriteLine($"{DateTime.Now} - Controller: {controller}, Action: {action}");
            }

            base.OnActionExecuting(context);
        }
    }
}
