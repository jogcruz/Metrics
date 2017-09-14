using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModels;

namespace BusinessServices
{
    public class JobServices : BaseServices, IJobServices
    {
        public JobServices()
        {
        }

        public IList<Job> GetJobs(int tenantId, string status)
        {
            //IList<Job> jobs = new List<Job>();

            var result = data.OfType<DataContext>().Where(s => s.TenantId == tenantId && s.Status.ToLower().Equals(status.ToLower()));

            IList<Job> jobs = result.Select(item => new Job
                                            {
                                                Name = item.JobName,
                                                Start = item.Start,
                                                End = item.End,
                                                Reason = item.Reason,
                                                TimeRunning = item.End != DateTime.MinValue ? (item.End.Subtract(item.Start)).Minutes : 0,
                                                TimeAverage = 23
                                            }).ToList();
            return jobs;

        }


    }
}
