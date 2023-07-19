using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace UnitTests.ApiTests
{
    internal class BaseApiTest
    {
    
        protected BaseApiClient apiClient;

        [OneTimeSetUp]
        public void InitApiClient()
        {
          // apiClient = new BaseApiClient("https://isthisnikita.testrail.io/index.php?/api/v2");
           apiClient.AddToken(Core.Configuration.Configuration.Api.Token);
        }

    }
}
