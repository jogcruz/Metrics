using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModels;

namespace BusinessServices
{
    public class BaseServices
    {

        protected List<DataContext> data = new List<DataContext>
        {
            new DataContext{TenantId = 1, Tenant = "Client 1 LastName Inc.", JobName = "Import Inventory", Start = new DateTime(2017,08,30,9,10,15), Status = "running" },
            new DataContext{TenantId = 2, Tenant = "Client 2", JobName = "Import Inventory", Start = new DateTime(2017,08,30,9,12,0), Status = "running" },
            new DataContext{TenantId = 4, Tenant = "Client 4", JobName = "Import Inventory", Start = new DateTime(2017,08,30,7,10,15), Status = "running" },
            new DataContext{TenantId = 1, Tenant = "Client 1 LastName Inc.", JobName = "Export Inventory", Start = new DateTime(2017,08,30,9,0,0), End = new DateTime(2017,08,30,9,24,0), Status = "ended" },
            new DataContext{TenantId = 1, Tenant = "Client 1 LastName Inc.", JobName = "My Job", Start = new DateTime(2017,08,30,7,10,15), Status = "running" },
            new DataContext{TenantId = 3, Tenant = "Client 3", JobName = "Import Inventory", Start = new DateTime(2017,08,29,5,0,3), End = new DateTime(2017,08,29,9,30,0), Status = "ended" },
            new DataContext{TenantId = 3, Tenant = "Client 3", JobName = "Export Inventory", Start = new DateTime(2017,08,30,9,10,15), End = new DateTime(2017,08,30,9,24,0), Status = "failed", Reason = "Export was aborted" }
        };

    }
}
