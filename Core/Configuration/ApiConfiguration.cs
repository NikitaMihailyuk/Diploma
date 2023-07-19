using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Configuration;

namespace Core.Configuration
{
    public class ApiConfiguration : IConfiguration
    {
        public string SectionName => "Api";
        public string BaseUrl { get; set; }

        public string Token { get; set; }
    }
}
