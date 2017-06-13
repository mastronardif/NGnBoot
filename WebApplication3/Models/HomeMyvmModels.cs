using System;
using System.Collections.Generic;

namespace WebApplication3.Models
{
    public class Employee {
        public string   name { get; set; }
        public int       age { get; set; }
        public double salary { get; set; }
    }

    public class UserModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Company { get; set; }
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

        public List<UserModel> GetUsers()
        {
            var usersList = new List<UserModel>
            {
                new UserModel
                {
                    UserId = 1,
                    UserName = "Ram",
                    Company = "Mindfire Solutions"
                },
                new UserModel
                {
                    UserId = 1,
                    UserName = "chand",
                    Company = "Mindfire Solutions"
                },
                new UserModel
                {
                    UserId = 1,
                    UserName = "Abc",
                    Company = "Abc Solutions"
                }
            };

            return usersList;
        }

    }
}
