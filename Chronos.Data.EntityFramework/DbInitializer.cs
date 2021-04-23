namespace Chronos.Data.EntityFramework
{
    public static class DbInitializer
    {
        public static void Initialize(ChronosDbContext context)
        {
            context.Database.EnsureCreated();

            //context.SaveChanges();
        }
    }
}
