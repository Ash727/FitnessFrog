using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Treehouse.FitnessFrog.Data;
using Treehouse.FitnessFrog.Models;

namespace Treehouse.FitnessFrog.Controllers
{
    public class EntriesController : Controller
    {
        private EntriesRepository _entriesRepository = null;

        public EntriesController()
        {
            _entriesRepository = new EntriesRepository();
        }

        public ActionResult Index()
        {
            List<Entry> entries = _entriesRepository.GetEntries();

            // Calculate the total activity.
            double totalActivity = entries
                .Where(e => e.Exclude == false)
                .Sum(e => e.Duration);

            // Determine the number of days that have entries.
            int numberOfActiveDays = entries
                .Select(e => e.Date)
                .Distinct()
                .Count();

            ViewBag.TotalActivity = totalActivity;
            ViewBag.AverageDailyActivity = (totalActivity / (double)numberOfActiveDays);

            return View(entries);
        }

        public ActionResult Add()
        {
            // Controllers have a request property that you can get information from Http method 
            //if (Request.HttpMethod == "POST") {
            //}
            // or see AddPost request method below 
            return View();
        }

        // here were saying if we are in the add view and recieve a httpPost request runthis method 
        // similar to spark Post("uri/somthin",(req,res ) )
        // This weill run  when in the add view and post request sent 
        [ActionName("Add"), HttpPost]
        public ActionResult AddPost( DateTime? date, int? activityId, double? duration, 
            Entry.IntensityLevel? intensity, bool? exclude, string notes )
        {    
            DateTime dateValue;
            //DateTime.TryParse(date, out dateValue);

            // To get information from the forms we could use 
            //ViewBag.Date = date;
            // or 
           // ViewBag.Date = ModelState["Date"].Value.AttemptedValue;
           // ViewBag.ActivityId = ModelState["ActivityId"].Value.AttemptedValue; ;
            // But because we use using Html.beginForm() in add 
            // this automatically does it for us cause it uses model state 


            return View();
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View();
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View();
        }
    }
}