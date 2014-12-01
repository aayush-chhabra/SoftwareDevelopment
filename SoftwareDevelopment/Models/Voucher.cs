using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Capstone.Models
{
    public enum Status
    {
        Approved, Active, Complete, Expired
    }
    public class Voucher
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        [Required]
        [Display(Name = "Permitted Quantity")]
        [Range(0, 5000)]
        public int PermittedQuantity { get; set; }

        [Display(Name = "Status")]
        public Status? Status { get; set; }

        public int ProjectId { get; set; }

        public int DetailedServiceId { get; set; }


        //FKs
        public virtual Project Project { get; set; }
        public virtual DetailedService DetailedService { get; set; }

        public virtual ICollection<VoucherEvent> VoucherEvents { get; set; }
    }
}