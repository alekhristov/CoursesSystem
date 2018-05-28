using CoursesSystem.Utils.Contracts;
using System;

namespace CoursesSystem.Utils
{
    /// <summary>
    /// Abstracts DateTime in order to be testable
    /// </summary>
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime Now()
        {
            return DateTime.Now;
        }

        public DateTime UtcNow()
        {
            return DateTime.UtcNow;
        }
    }
}
