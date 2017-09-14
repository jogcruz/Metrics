using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels
{
    public class DataContext
    {
        public int TenantId { get; set; }
        public String Tenant { get; set; }
        public String JobName { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public String Status { get; set; }
        public String Reason { get; set; }

    }
}
