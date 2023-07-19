using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using RestSharp;

namespace BusinessObject.ApiObjects.Services
{
    public class TestCaseService : BaseService
    {
        public string CaseEndpoint = "/case";
        public string GetCaseByCodeEndpoint = "/get_runs/{code}";
        public string GetCaseByCodeEndpointbulk = "/case/{code}/bulk";
        public string GetCaseByID = "/case/{code}/{id}";


        public TestCaseService() :base("https://isthisnikita.testrail.io/index.php?/api/v2")
        {
     //     apiClient.AddToken("vd0SC5SATgakfaOApOYa-DJPIScT3dEp1AzUgVms5");
        }

        public RestResponse GetAlltestCases(string caseCode)
        {
            var request = new RestRequest(GetCaseByCodeEndpoint, Method.Get).AddUrlSegment("code", caseCode);
            request.AddBody(caseCode);
            return apiClient.Execute(request);
        }

        public RestResponse CreateANewTestCase(string caseCode, string title)
        {
            var request = new RestRequest(GetCaseByCodeEndpoint, Method.Post).AddUrlSegment("code", caseCode);

            var body = new Dictionary<string, object>()
            {
                {"title", title},
            };
            request.AddBody(body);
            /// request = request.AddParameter("application/json", "{\"title\":" + title + "}", ParameterType.RequestBody);
            return apiClient.Execute(request);
        }

        public RestResponse GetASpecificTestCase(string caseCode, int id)
        {
            var request = new RestRequest(GetCaseByID, Method.Get).AddUrlSegment("code", caseCode).AddUrlSegment("id", id);
            return apiClient.Execute(request);
        }

        public RestResponse DeleteTestCase(string caseCode, int id)
        {
            var request = new RestRequest(GetCaseByID, Method.Delete).AddUrlSegment("code", caseCode).AddUrlSegment("id", id);
            return apiClient.Execute(request);
        }

        public RestResponse UpdateTestCase(string caseCode, int id, string newTitle)
        {
            var request = new RestRequest(GetCaseByID, Method.Patch).AddUrlSegment("code", caseCode).AddUrlSegment("id", id);

            var body = new Dictionary<string, object>()
            {
                {"title", newTitle},
            };

            request.AddBody(body);
            return apiClient.Execute(request);
        }

        public RestResponse CreateTestCasesinBulk(string caseCode, string title)
        {
            var request = new RestRequest(GetCaseByCodeEndpointbulk, Method.Post).AddUrlSegment("code", caseCode);
            request = request.AddParameter("application/json", "{\"cases\":[{\"title\":\"" + title + "\"}]}", ParameterType.RequestBody);
            request.AddBody(caseCode);
            return apiClient.Execute(request);
        }
    }
}
