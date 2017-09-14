using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModels;

namespace BusinessServices
{
    public interface IJobServices
    {
        IList<Job> GetJobs(int tenantId, string status);

    }
}
