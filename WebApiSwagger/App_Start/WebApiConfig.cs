using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebApiThrottle;

namespace WebApiSwagger
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

          // https://github.com/stefanprodan/WebApiThrottle#global-throttling-based-on-ip
          //The setup bellow will limit the number of requests originated from the same IP. 
          //If from the same IP, in same second, you'll make a call to api/values and api/values/1 
          //the last call will get blocked.

          config.MessageHandlers.Add(new ThrottlingHandler()
          {
            Policy = new ThrottlePolicy(perSecond: 1, perMinute: 20, perHour: 200, perDay: 1500, perWeek: 3000)
            {
              IpThrottling = true
            },
            Repository = new CacheRepository()
          });

            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );


        }
    }
}
