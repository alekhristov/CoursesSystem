using System;

namespace CoursesSystem.Utils.Contracts
{
    public interface IDateTimeProvider
    {
        DateTime Now();

        DateTime UtcNow();
    }
}
