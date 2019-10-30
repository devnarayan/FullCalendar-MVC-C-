using MVC5FullCalandarPlugin.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace MVC5FullCalandarPlugin.Controllers
{
    public class HomeController : Controller
    {
        #region Index method

        /// <summary>
        /// GET: Home/Index method.
        /// </summary>
        /// <returns>Returns - index view page</returns> 
        public ActionResult Index()
        {
            // Info.
            return this.View();
        }

        #endregion

        #region Get Calendar data method.

        /// <summary>
        /// GET: /Home/GetCalendarData
        /// </summary>
        /// <returns>Return data</returns>
        public ActionResult GetCalendarData()
        {
            // Initialization.
            JsonResult result = new JsonResult();

            try
            {
                // Loading.
                List<PublicHoliday> data = this.LoadData();

                // Processing.
                result = this.Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                // Info
                Console.Write(ex);
            }

            // Return info.
            return result;
        }

        #endregion

        #region Helpers

        #region Load Data

        /// <summary>
        /// Load data method.
        /// </summary>
        /// <returns>Returns - Data</returns>
        private List<PublicHoliday> LoadData()
        {
            // Initialization.
            List<PublicHoliday> lst = new List<PublicHoliday>();

            try
            {
                // Initialization.
                string line = string.Empty;
                string srcFilePath = "Content/files/PublicHoliday.txt";
                var rootPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
                var fullPath = Path.Combine(rootPath, srcFilePath);
                string filePath = new Uri(fullPath).LocalPath;
                StreamReader sr = new StreamReader(new FileStream(filePath, FileMode.Open, FileAccess.Read));

                // Read file.
                while ((line = sr.ReadLine()) != null)
                {
                    // Initialization.
                    PublicHoliday infoObj = new PublicHoliday();
                    string[] info = line.Split(',');

                    // Setting.
                    infoObj.Sr = Convert.ToInt32(info[0].ToString());
                    infoObj.Title = info[1].ToString();
                    infoObj.Desc = info[2].ToString();
                    infoObj.Start_Date = info[3].ToString();
                    infoObj.End_Date = info[4].ToString();

                    // Adding.
                    lst.Add(infoObj);
                }

                // Closing.
                sr.Dispose();
                sr.Close();
            }
            catch (Exception ex)
            {
                // info.
                Console.Write(ex);
            }

            // info.
            return lst;
        }

        #endregion

        #endregion

        #region FullCalendar

        [HttpGet]
        public ActionResult Index1()
        {
            return View(new EventViewModel());
        }

        public JsonResult GetEvents(DateTime start, DateTime end)
        {
            var viewModel = new EventViewModel();
            var events = new List<EventViewModel>();
            start = DateTime.Today.AddDays(-14);
            end = DateTime.Today.AddDays(-11);

            for (var i = 1; i <= 5; i++)
            {
                events.Add(new EventViewModel()
                {
                    id = i,
                    title = "Event " + i,
                    start = start.ToString(),
                    end = end.ToString(),
                    allDay = false
                });

                start = start.AddDays(7);
                end = end.AddDays(7);
            }


            return Json(events.ToArray(), JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}