using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Capstone.Models
{
    public enum ProjectStatus {
        approved, pending
    }
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Display(Name = "Project Status")]
        [DisplayFormat(NullDisplayText = "Pending Approval")]
        public ProjectStatus? Status { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Voucher> Vouchers { get; set; }
    }
}