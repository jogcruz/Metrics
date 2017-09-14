using System;
using System.Web.Http;
using BusinessServices;
using DataModels;

namespace Metrics.Controllers
{
    public class TenantsController : ApiController
    {
        private ITenantServices tenantServices;
        private IJobServices jobServices;
        public TenantsController(IJobServices jobServices, ITenantServices tenantServices)
        {
            this.jobServices = jobServices;
            this.tenantServices = tenantServices;
        }

        public IHttpActionResult Get()
        {
            return Ok(tenantServices.GetTenantsSummary());
        }


        public IHttpActionResult Get(int id, string status)
        {
            return Ok(jobServices.GetJobs(id, status));
        }

     }
}
