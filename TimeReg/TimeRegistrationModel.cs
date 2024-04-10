using System;

namespace EmployeeTimeTracker
{
    public class TimeRegistrationModel
    {
        private String name;
        private DateTime date;
        private double hours;
        private string userDefinedRegistration;
        public TimeRegistrationModel()
        {
        }

        public string Name { get => name; set => name = value; }
        public DateTime Date { get => date; set => date = value; }
        public double Hours { get => hours; set => hours = value; }
        public string UserDefinedRegistration { get => userDefinedRegistration; set => userDefinedRegistration = value; }

    }
}