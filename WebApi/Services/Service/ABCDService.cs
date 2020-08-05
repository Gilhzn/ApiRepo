using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Services.IService;

namespace WebApi.Services.Service
{
    public class ABCDService : IABCDService
    {
        public string GetName()
        {
            return "ABCD_TEST";
        }
    }
}
