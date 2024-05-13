using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Student_Management_Portal;

namespace Student_Management_Portal;

public class StudentDbContext : DbContext
{
    public StudentDbContext() { }
    public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Admin> Admins { get; set; }
    public DbSet<Parent> Parents { get; set; }
    public DbSet<Student> Students { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Parent>().ToTable("TblParent");
        modelBuilder.Entity<Admin>().ToTable("TblAdmin");
        modelBuilder.Entity<Student>().ToTable("TblStudent");
        modelBuilder.Entity<User>().ToTable("TblUser");
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();
            var connectionString = configuration.GetConnectionString("StudentPortal");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }


}

