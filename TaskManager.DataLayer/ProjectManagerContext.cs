using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using ProjectManager.EntityModel;

namespace ProjectManager.DataLayer
{

    public partial class ProjectManagerContext : DbContext
    {
        public ProjectManagerContext()
            : base("name=TaskManagerEF")
        {
            Database.SetInitializer(new ProjectManagerContextInitializer());
        }

        public DbSet<TaskData> TaskData { get; set; }
        public DbSet<ParentTaskData> ParentTaskData {get;set;}

        public DbSet<ProjectData> ProjectData { get; set; }

        public DbSet<UserData> UserData { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {            
            modelBuilder.Entity<TaskData>();
            modelBuilder.Entity<ParentTaskData>();
            modelBuilder.Entity<ProjectData>();
            modelBuilder.Entity<UserData>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
