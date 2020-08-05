using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;
using WebApi.BL;
using WebApi.Models;
using WebApi.Services.IService;

namespace WebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ValuesController : ApiController
    {
        private readonly ITestService _testService;
        private readonly IABCDService _abcdService;


        public ValuesController(ITestService testService, IABCDService abcdService) {
            _testService = testService;
            _abcdService = abcdService;
        }
        // GET api/values
        public IEnumerable<string> Get()
        {
            var a = _testService.GetName();
            var b = _abcdService.GetName();
            return new string[] { a, b };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // GET api/values/5
        public List<FeedItem> Get(string linkUrl)
        {
            List<FeedItem> model = new List<FeedItem>();
            try
            {
                model = RssBL.ParseRssFile(linkUrl);
            }
            catch (Exception ex)
            {
                ////Log

            }

            return model;
        }


        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
