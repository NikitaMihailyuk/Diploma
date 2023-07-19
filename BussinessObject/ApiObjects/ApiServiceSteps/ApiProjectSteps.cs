using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using BusinessObject.ApiObjects.Services;
using BusinessObject.ApiObjects.Model;
using NUnit.Framework;

namespace BusinessObject.ApiObjects.ApiServiceSteps
{
    internal class ApiProjectSteps : ProjectService
    {
        public new Project GetProjectByCode(string code)
        {
            var response = base.GetProjectByCode(code);
            Assert.IsTrue(response.StatusCode.Equals(HttpStatusCode.OK));
            Assert.IsNotNull(response.Content);

            return JsonConvert.DeserializeObject<CommonResultResponse<Project>>(response.Content).Result;
        }
    }
}
