using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModels;

namespace BusinessServices
{
    public interface ITenantServices
    {
        IList<Tenant> GetTenantsSummary();
    }
}
