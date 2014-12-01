using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Capstone.Models
{
    public class DetailedService
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Required]
        [Display(Name = "Unit Of Measurement")]
        public string UnitOfMeasurement { get; set; }

        // FKs
        public int UserId { get; set; } //Service Provider ID

        public virtual ServiceArea ServiceArea { get; set; }
        public virtual User ServiceProvider { get; set; }

        public virtual ICollection<Voucher> Vouchers { get; set; }
    }
}