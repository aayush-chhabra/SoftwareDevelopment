using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone.Models;
using Newtonsoft.Json.Linq;

namespace Capstone.Views.Reporting
{
    public class ReportingController : Controller
    {
        private CapstoneDb db = new CapstoneDb();
        //
        // GET: /Reporting/

        public ActionResult Index()
        {
            return View();
        }

        public class ServicePieChart
        {
            public string Name;
            public int Value;
        }

        public ActionResult ServiceUsage()
        {
            return Json(CreateDataList(), JsonRequestBehavior.AllowGet);
        }

        public IEnumerable<ServicePieChart> CreateDataList()
        {
            List<ServicePieChart> data = new List<ServicePieChart>();

            var vouchereventsQuery = from v in db.VoucherEvents
                                     where v.Voucher.DetailedService.Id.Equals(1)
                                     //group v by v.Voucher.ProjectId into d
                                     select new
                                     {
                                         Name = v.Voucher.Project.Name,
                                         Value = v.AmountUsed
                                     };

            foreach (var v in vouchereventsQuery.ToList())
            {
                ServicePieChart r = new ServicePieChart() { Name = v.Name.ToString(), Value = v.Value };
                data.Add(r);
            }
            //ServicePieChart r = new ServicePieChart() { Name = "Introduction", Value = 20 };
            //ServicePieChart r1 = new ServicePieChart() { Name = "Basic 1", Value = 24 };
            //ServicePieChart r2 = new ServicePieChart() { Name = "PHP", Value = 74 };

            //data.Add(r);
            //data.Add(r1);
            //data.Add(r2);

            return data;
        }

        //public JsonResult ServiceUsage()
        //{
        //    List<object> data = new List<object>();

        //    foreach (var v in db.VoucherEvents) {
        //        //if (v.Voucher.DetailedService.Id == 1)
        //        //{
        //            data.Add(new[] { 1, 2 });
        //        //}
        //    }

        //    //data.Add(new[] { 01.03, 300 });
        //    //data.Add(new[] { 12.15, 350 });
        //    return Json(data, JsonRequestBehavior.AllowGet);
        //}

        private JArray CreateVoucherEventsList()
        {
            //List<VoucherEvent> events = new List<VoucherEvent>();

            //var vouchereventsQuery = from v in db.VoucherEvents
            //                         where v.Voucher.DetailedService.Id.Equals(serviceId)
            //                    select new { v.Voucher.Project.Name, v.AmountUsed };


            //VoucherEvent event1 = new VoucherEvent() {  };

            JArray events = JArray.FromObject(
               from v in db.VoucherEvents
               where v.Voucher.DetailedService.Id.Equals(1)
               select new { v.Voucher.Project.Name, v.AmountUsed }
            );

            //events.Add(event1);

            return events;
        }

    }
}
