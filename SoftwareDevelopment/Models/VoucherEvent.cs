using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Capstone.Models
{
    public class VoucherEvent
    {
        public int Id { get; set; }
        public int AmountUsed { get; set; }

        [Timestamp]
        public byte[] TimeUsed { get; set; }

        public int VoucherId { get; set; }
        // FK
        public virtual Voucher Voucher { get; set; }
    }
}