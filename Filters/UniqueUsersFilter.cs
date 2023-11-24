using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Owin;
using NWebsec.AspNetCore.Core.Web;
using System.Net;
using System.Web;

namespace lr11.Filters
{
    public class UniqueUsersFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var userIp = context.HttpContext.Features.Get<IHttpConnectionFeature>()?.RemoteIpAddress;
            Console.WriteLine(userIp);
            string filePath = @"D:\Учёба\.Net\lr11\lr11\App_Data\UniqueUsers.txt";
            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, string.Empty);
            }

            string[] users = File.ReadAllLines(filePath);
            if (Array.IndexOf(users, userIp) == -1)
            {
                File.AppendAllText(filePath, $"{userIp}");
            }

            base.OnActionExecuting(context);
        }

        private string GetClientIpAddress(HttpRequestMessage request)
        {
            if (request.Properties.ContainsKey("MS_HttpContext"))
            {
                return IPAddress.Parse(((HttpContext)request.Properties["MS_HttpContext"]).Connection.RemoteIpAddress.ToString()).ToString();
            }
            if (request.Properties.ContainsKey("MS_OwinContext"))
            {
                return IPAddress.Parse(((OwinContext)request.Properties["MS_OwinContext"]).Request.RemoteIpAddress).ToString();
            }
            return String.Empty;
        }
    }
}
