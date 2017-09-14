using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataModels
{
    public class Tenant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Running { get; set; }
        public int Ended { get; set; }
        public int Failed { get; set; }
    }
}