using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Services.IService;

namespace WebApi.Services.Service
{
    public class TestService : ITestService
    {
        public string GetName()
        {
            return "Gil";
        }
    }
}