using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using Core.Configuration;

namespace Core
{
    public class BaseService
    {
        protected BaseApiClient apiClient;
        protected static NLog.Logger logger = LogManager.GetCurrentClassLogger();
        public BaseService(string url)
        {
            this.apiClient = new BaseApiClient(url);
            apiClient.AddToken(Configuration.Configuration.Api.Token);

        }
    }
}
