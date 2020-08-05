using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity;
using WebApi.Controllers;
using WebApi.Services.IService;
using WebApi.Services.Service;

namespace WebApi
{
    internal static class UnityConfig
    {

        public static UnityContainer Register()
        {
            var container = new UnityContainer();
            container.RegisterType<ITestService, TestService>();
            container.Resolve<ValuesController>();
            return container;
        }

    }
}