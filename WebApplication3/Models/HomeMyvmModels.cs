using System;
using System.Collections.Generic;

namespace WebApplication3.Models
{
    public class Employee {
        public string   name { get; set; }
        public int       age { get; set; }
        public double salary { get; set; }
    }

    public class MyViewModel
    {
        public string SelectedSexPreference { get; set; }
        public Dictionary<string, string> SexPreferences { get; set; }

        public Dictionary<int, Employee> employees { get; set; }

        public MyViewModel()
        {
            SexPreferences = new Dictionary<string, string>();
            LoadEmployees();
        }

        // setup empoloyees
        private void LoadEmployees()
        {
            employees = new Dictionary<int, Employee>() {
                { 1001, new Employee{ name="Bob",  age=33, salary=123.123}},
                { 1002, new Employee{ name="Fred", age=33, salary=124.123}},
                { 1003, new Employee{ name="Ann",  age=33, salary=125.123}}
            };


        }

    }
}
