using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using RBS.API.Controllers;
using RBS.Domain.UserInfo;
using System.Globalization;
using System.Net;
using System.Security.Claims;

namespace RBS.API.Filters
{
    public class UserActionFilter : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            ApiControllerBase c = context.Controller as ApiControllerBase;
            if (c != null)
            {
                var userModel = new UserModel
                {
                    IpInfo = GetUserLocationByIp(c.HttpContext.Connection.RemoteIpAddress.ToString())
                };

                if (c.User != null)
                {
                    userModel.UserName = c.User?.FindFirstValue(ClaimTypes.Name);
                    int.TryParse(c.User?.FindFirstValue(ClaimTypes.NameIdentifier), out int userId);
                    userModel.UserId = userId;
                }
                c.UserModel = userModel;
            }
        }

        private IpInfo GetUserLocationByIp(string ip)
        {
            ip = "46.49.119.60";
            IpInfo ipInfo = new();

            try
            {
                string info = new WebClient().DownloadString("http://ipinfo.io/" + ip);
                ipInfo = JsonConvert.DeserializeObject<IpInfo>(info);
                RegionInfo myRI1 = new RegionInfo(ipInfo.Country);
                ipInfo.Country = myRI1.EnglishName;
                var coordinates = ipInfo.Loc.Split(",");
                ipInfo.IsLoaded = true;
                ipInfo.Latitude = coordinates[0];
                ipInfo.Longitude = coordinates[1];
            }
            catch (Exception)
            {
                ipInfo.IsLoaded = false;
            }

            return ipInfo;
        }
    }
}
