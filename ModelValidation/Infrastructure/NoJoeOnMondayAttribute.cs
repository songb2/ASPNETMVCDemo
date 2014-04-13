using ModelValidation.Models;
using System.ComponentModel.DataAnnotations;

namespace ModelValidation.Infrastructure
{
    public class NoJoeOnMondayAttribute : ValidationAttribute
    {
        public NoJoeOnMondayAttribute()
        {
            ErrorMessage = "Joe cannot book appointments on Mondays";
        }

        public override bool IsValid(object value)
        {
            Appointment app = value as Appointment;

            if (app == null || string.IsNullOrEmpty(app.ClientName) || app.Date == null)
            {
                return true;
            }
            else
            {
                return !(app.ClientName == "Joe" && app.Date.DayOfWeek == System.DayOfWeek.Monday);
            }
        }
    }
}