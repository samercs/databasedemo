namespace DatabaseDemo.Models
{
    public class DbInitialzer : System.Data.Entity.CreateDatabaseIfNotExists<ApplicationContext>
    {
        protected override void Seed(ApplicationContext context)
        {
            context.Departments.Add(new Department
            {
                Name = "Test Dept 1"
            });
            context.Departments.Add(new Department
            {
                Name = "Test Dept 2"
            });

            context.Courses.Add(new Course
            {
                Name = "Sport"
            });

            base.Seed(context);

        }
    }
}