using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Helpers
{
    public class DataTableResponse
    {
        public int draw { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }
        public string error { get; set; }
        public List<Dictionary<string, object>> data { get; set; }

        public DataTableResponse()
        {
            data = new List<Dictionary<string, object>>();
            draw = 1;
            recordsFiltered = 0;
            recordsTotal = 0;
            error = "";
        }
    }
}