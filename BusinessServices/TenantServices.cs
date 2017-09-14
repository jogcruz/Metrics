using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModels;

namespace BusinessServices
{
    public class TenantServices : BaseServices, ITenantServices
    {
        public TenantServices()
        {
        }

        public IList<Tenant> GetTenantsSummary()
        {
            var result = (from l in data
                         select new DataContext { TenantId = l.TenantId, Tenant = l.Tenant, Status = l.Status }).ToList();

            var tenants = result
                    .GroupBy(l => new { l.TenantId, l.Tenant, l.Status })
                    .Select(cl => new Tenant
                    {
                        Id = cl.First().TenantId,
                        Name = cl.First().Tenant,
                        Running = cl.Count(c => c.Status.ToLower().Equals("running")),
                        Ended = cl.Count(c => c.Status.ToLower().Equals("ended")),
                        Failed = cl.Count(c => c.Status.ToLower().Equals("failed"))
                    }).ToList();


            tenants = tenants
                    .GroupBy(l => new { l.Id, l.Name})
                    .Select(cl => new Tenant
                    {
                        Id = cl.First().Id,
                        Name = cl.First().Name,
                        Running = cl.Sum(c => c.Running),
                        Ended = cl.Sum(c => c.Ended),
                        Failed = cl.Sum(c => c.Failed)
                    }).ToList();

            return tenants;

        }
    }

}
