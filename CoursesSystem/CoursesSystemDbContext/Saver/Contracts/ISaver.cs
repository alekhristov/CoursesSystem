namespace CoursesSystem.Data.Saver.Contracts
{
    public interface ISaver
    {
        void SaveChanges();

        void SaveChangesAsync();
    }
}
