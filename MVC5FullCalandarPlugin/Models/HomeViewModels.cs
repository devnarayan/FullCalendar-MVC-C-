using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC5FullCalandarPlugin.Models
{
    public class PublicHoliday
    {
        public int Sr { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public string Start_Date { get; set; }
        public string End_Date { get; set; }
    }

    public class EventViewModel
    {
        public Int64 id { get; set; }

        public String title { get; set; }

        public String start { get; set; }

        public String end { get; set; }

        public bool allDay { get; set; }
    }
}
