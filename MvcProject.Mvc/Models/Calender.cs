using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcProject.Mvc.Models
{
    public class Calender
    {
        public string title { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public bool allDay { get; set; }
    }
}