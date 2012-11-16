using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using IMS.Core.Model;

namespace IMS.DBImplimentation
{
    internal class IMsDBContext:DbContext
    {
        public IMsDBContext() : base("ImsMainDB")
        {}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AppUsers>().Map(m => m.ToTable("AppUsers")).HasKey(t => t.PK_appUsers);
            modelBuilder.Entity<AppUsersModules>().Map(m => m.ToTable("AppUsersModules")).HasKey(t => t.PK_AppUsersModules);
            modelBuilder.Entity<MscItemCategory>().Map(m => m.ToTable("MscItemCategory")).HasKey(t => t.PK_MscItemCategory);
            modelBuilder.Entity<MscSubClassification>().Map(m => m.ToTable("MscSubClassification")).HasKey(t => t.PK_MscSubClassification);
            modelBuilder.Entity<MscIncentiveClass>().Map(m => m.ToTable("MscIncentiveClass")).HasKey(t => t.PK_MscIncentiveClass);
            modelBuilder.Entity<MstrAgency>().Map(m => m.ToTable("MstrAgency")).HasKey(t => t.PK_MstrAgency);
            modelBuilder.Entity<MstrBranches>().Map(m => m.ToTable("MstrBranches")).HasKey(t => t.PK_MstrBranches);
            modelBuilder.Entity<MstrDealer>().Map(m => m.ToTable("MstrDealer")).HasKey(t => t.PK_MstrDealer);
            modelBuilder.Entity<MstrFPS>().Map(m => m.ToTable("MstrFPS")).HasKey(t => t.PK_MstrFPS);
            modelBuilder.Entity<MstrItems>().Map(m => m.ToTable("MstrItems")).HasKey(t => t.PK_MstrItems);
            modelBuilder.Entity<MstrModules>().Map(m => m.ToTable("MstrModules")).HasKey(t => t.PK_MstrModules);
        }

        public DbSet<AppUsers> AppUsers { get; set; }
        public DbSet<AppUsersModules> AppUsersModules { get; set; }
        public DbSet<MscItemCategory> MscItemCategory { get; set; }
        public DbSet<MscSubClassification> MscSubClassification { get; set; }
        public DbSet<MscIncentiveClass> MscIncentiveClass { get; set; }
        public DbSet<MstrAgency> MstrAgency { get; set; }
        public DbSet<MstrBranches> MstrBranches { get; set; }
        public DbSet<MstrDealer> MstrDealer { get; set; }
        public DbSet<MstrFPS> MstrFPS { get; set; }
        public DbSet<MstrItems> MstrItems { get; set; }
        public DbSet<MstrModules> MstrModules { get; set; }
    }
}
