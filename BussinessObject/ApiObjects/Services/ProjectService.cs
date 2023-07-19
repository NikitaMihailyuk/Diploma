﻿using BusinessObject.ApiObjects.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using RestSharp;


namespace BusinessObject.ApiObjects.Services
{
    internal class ProjectService : BaseService
    {
        public string ProjectEndpoint = "/project";
        public string GetProjectByCodeEndpoint = "/project/{code}";
        public string ProjectAcces = "/project/{code}/access";


        public ProjectService() : base("https://api.qase.io/v1")
        {

        }
        public RestResponse GetProjectByCode(string code)
        {

            var request = new RestRequest(GetProjectByCodeEndpoint).AddUrlSegment("code", code);
            return apiClient.Execute(request);
        }

        public RestResponse CreateProject(CreateProjectModel project)
        {
            var request = new RestRequest(ProjectEndpoint, Method.Post);
            request.AddBody(project);
            return apiClient.Execute(request);
        }

        public Project GetProjectByCode<ProjectType>(string code) where ProjectType : Project
        {
            var request = new RestRequest(GetProjectByCodeEndpoint).AddUrlSegment("code", code);
            return apiClient.Execute<CommonResultResponse<Project>>(request).Result;
        }

        public RestResponse GetAllProjects(int limit, int offset)
        {
            var request = new RestRequest(ProjectEndpoint, Method.Get);
            request = request.AddUrlSegment("limit", limit).AddUrlSegment("offset", offset);
            return apiClient.Execute(request);
        }
        public RestResponse DeleteProjectByCode(string code)
        {
            var request = new RestRequest(GetProjectByCodeEndpoint, Method.Delete);
            request = request.AddUrlSegment("code", code);
            return apiClient.Execute(request);
        }

        public RestResponse RevokeAccessToProjectByCode(string code, int memberid)
        {
            var request = new RestRequest(ProjectAcces, Method.Delete);
            request = request.AddUrlSegment("code", code).AddParameter("application/json", "{\"member_id\":" + memberid + "}", ParameterType.RequestBody);
            Console.WriteLine(request);
            return apiClient.Execute(request);
        }

        public RestResponse GrantAccesstToProjectByCode(string code, int memberid)
        {
            var request = new RestRequest(ProjectAcces, Method.Post);
            request = request.AddUrlSegment("code", code).AddParameter("application/json", "{\"member_id\":" + memberid + "}", ParameterType.RequestBody);
            Console.WriteLine(request);
            return apiClient.Execute(request);
        }
    }
}
