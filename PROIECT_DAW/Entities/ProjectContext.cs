using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROIECT_DAW.Entities
{

    //Ctrl + . For error fixes suggestions

    //Installed Nuget Packages
    /*   
      EntityFrameworkCore, care este ORM-ul in sine 
      EntityFrameworkCore.Relational 
      EntityFrameworkCore.SqlServer, care este provider-ul spre SqlServer(baza de date pe care o vom folosi)
      EntityFrameworkCore.Tools
    */

    //1. Add-Migration NameMigration
    //2. Verificati migration-ul 
    //3. Daca totul e ok, => Update-Database

    public class ProjectContext : IdentityDbContext<User, Role, string, IdentityUserClaim<string>,
        UserRole, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options) { }


        public DbSet<ToDoTask> ToDoTasks { get; set; }
        public DbSet<Reminder> Reminders { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ToDoTaskCategory> ToDoTaskCategories { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //One to One
            builder.Entity<ToDoTask>()
                .HasOne(todotask => todotask.Reminder)
                .WithOne(reminder => reminder.ToDoTask);


            //One to Many
            builder.Entity<ToDoTask>()
                .HasMany(todotask => todotask.Notes)
                .WithOne(note => note.ToDoTask);


            //Many To Many
            builder.Entity<ToDoTaskCategory>().HasKey(todotaskcategory => new { todotaskcategory.TaskId, todotaskcategory.CategoryId });

            builder.Entity<ToDoTaskCategory>()
                .HasOne(todotaskcategory => todotaskcategory.ToDoTask)
                .WithMany(todotask => todotask.ToDoTaskCategories)
                .HasForeignKey(todotaskcategory => todotaskcategory.TaskId);

            builder.Entity<ToDoTaskCategory>()
                .HasOne(todotaskcategory => todotaskcategory.Category)
                .WithMany(category => category.ToDoTaskCategories)
                .HasForeignKey(todotaskcategory => todotaskcategory.CategoryId);
        }
    }
}
