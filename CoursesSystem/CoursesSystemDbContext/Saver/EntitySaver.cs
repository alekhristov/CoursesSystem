using CoursesSystem.Data.Saver.Contracts;

namespace CoursesSystem.Data.Saver
{
    public class EntitySaver : ISaver
    {
        private readonly CoursesSystemDbContext context;

        public EntitySaver(CoursesSystemDbContext context)
        {
            this.context = context;
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        public async void SaveChangesAsync()
        {
            await this.context.SaveChangesAsync();
        }
    }
}
