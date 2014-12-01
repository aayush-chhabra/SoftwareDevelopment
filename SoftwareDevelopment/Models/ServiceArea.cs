using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Models
{
    public class ServiceArea
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<DetailedService> DetailedServices { get; set; }
    }
}