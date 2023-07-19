﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BusinessObject.ApiObjects.Services;

namespace UnitTests.ApiTests
{
    internal class CaseTests : BaseApiTest
    {

        protected TestCaseService caseService;


        [OneTimeSetUp]
        public void InitialService()
        {
            caseService = new TestCaseService();
        }

        [Test]
        public void GetAlltestCases()
        {
            var caseCode = "1";

            var response = caseService.GetAlltestCases(caseCode);
            Console.WriteLine(response.Content);
            Assert.IsTrue(response.StatusCode.Equals(HttpStatusCode.OK));
        }
        [Test]
        public void DeleteTestCase()
        {
            var caseCode = "TESTM";
            var id = 3;
            var response = caseService.DeleteTestCase(caseCode, id);
            Console.WriteLine(response.Content);
            Assert.IsTrue(response.StatusCode.Equals(HttpStatusCode.OK));
        }
        [Test]
        public void UpdateTestCase()
        {
            var caseCode = "TESTM";
            var id = 2;
            var newTitle = "new_test_case2";

            var response = caseService.UpdateTestCase(caseCode, id, newTitle);
            Console.WriteLine(response.Content);
            Assert.IsTrue(response.StatusCode.Equals(HttpStatusCode.OK));
        }
        [Test]
        public void CreateTestCasesinBulk()
        {
            var caseCode = "TESTM";
            var title = "test_case_bulk";

            var response = caseService.CreateTestCasesinBulk(caseCode, title);
            Console.WriteLine(response.Content);
            Assert.IsTrue(response.StatusCode.Equals(HttpStatusCode.OK));
        }
        [Test]
        public void CreateANewTestCase()
        {
            var caseCode = "TESTM";
            var title = "test_case";
            var response = caseService.CreateANewTestCase(caseCode, title);
            Console.WriteLine(response.Content);
            Assert.IsTrue(response.StatusCode.Equals(HttpStatusCode.OK));
        }
        [Test]
        public void GetASpecificTestCase()
        {
            var caseCode = "TESTM";
            var id = 2;

            var response = caseService.GetASpecificTestCase(caseCode, id);
            Console.WriteLine(response.Content);
            Assert.IsTrue(response.StatusCode.Equals(HttpStatusCode.OK));
        }
    }
}
