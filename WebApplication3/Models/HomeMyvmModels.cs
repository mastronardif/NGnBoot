using System;
using System.Collections.Generic;

namespace WebApplication3.Models
{
    public class MyViewModel
    {
        public string SelectedSexPreference { get; set; }
        public Dictionary<string, string> SexPreferences { get; set; }

        public MyViewModel()
        {
            SexPreferences = new Dictionary<string, string>();
        }
    }
}
