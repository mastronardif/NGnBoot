using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Helpers
{
    public class DatatableHeaderDefinition
    {
        public string data { get; set; }
        public string title { get; set; }
        //public string width { get; set; }

        public bool visible { get; set; }
        public DatatableHeaderDefinition(string Data, string Title, bool visibility = true)
        {
            data = Data;
            title = Title;
            //width = "100%";
            visible = visibility;
        }
    }
}