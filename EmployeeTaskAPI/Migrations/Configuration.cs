namespace EmployeeTaskAPI.Migrations
{
    using EmployeeTaskAPI.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EmployeeTaskAPI.Models.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EmployeeTaskAPI.Models.DataContext context)
        {
            context.Employees.AddOrUpdate(e => e.EmployeeId,
                new Employee { FirstName = "David", LastName = "Jackson", HiredDate = DateTime.Parse("2012-12-20") },
                new Employee { FirstName = "Hary", LastName = "Potter", HiredDate = DateTime.Parse("2013-11-15") },
                new Employee { FirstName = "James", LastName = "Gordon", HiredDate = DateTime.Parse("2014-12-31") }
                );
            context.Tasks.AddOrUpdate(t => t.TaskId,
                new ETask { TaskName = "Coding", StartTime = DateTime.Parse("2019-12-11"), Deadline = DateTime.Parse("2019-12-12"), EmployeeId = 1 },
                new ETask { TaskName = "Clean Room", StartTime = DateTime.Parse("2019-12-13"), Deadline = DateTime.Parse("2019-12-14"), EmployeeId = 1 }
                );
        }
    }
}
