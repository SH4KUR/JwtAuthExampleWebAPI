using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_JWT_Auth_Example.Helpers
{
    public class AppSettings
    {
        public string Key { get; set; }
     
        public string Issuer { get; set; }

        public string Audience { get; set; }

        public int LifeTimeSec { get; set; }
    }
}
