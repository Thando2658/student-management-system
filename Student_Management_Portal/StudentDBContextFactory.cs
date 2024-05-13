using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_Portal;

public class StudentDBContextFactory : IDesignTimeDbContextFactory<StudentDbContext>
{
    public StudentDbContext CreateDbContext(string[] args)
    {
        // Build configuration
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        // Get connection string
        string connectionString = configuration.GetConnectionString("StudentPortal");

        // Create options builder
        var optionsBuilder = new DbContextOptionsBuilder<StudentDbContext>();
        optionsBuilder.UseSqlServer(connectionString);

        // Create DbContext instance
        return new StudentDbContext(optionsBuilder.Options);
    }
}
