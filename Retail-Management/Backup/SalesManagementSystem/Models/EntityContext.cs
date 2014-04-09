using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Infrastructure;

namespace SalesManagementSystem.Models
{
    public class EntityContext : DbContext
    {
        public DbSet<AllowRule> AllowRules { get; set; }
        public DbSet<AssessGrade> AssessGrade { get; set; }
        public DbSet<AssessItem> AssessItems { get; set; }
        public DbSet<AssessReport> AssessReports { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Commodity> Commodities { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<SalesRecord> SalesRecords { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Inbox)
                .WithRequired(m => m.Receiver)
                .HasForeignKey(m => m.ReceiverID)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<User>()
                .HasMany(u => u.Outbox)
                .WithRequired(m => m.Sender)
                .HasForeignKey(m => m.SenderID)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<User>()
                 .HasMany(u => u.Roles)
                 .WithMany(r => r.Users);
            modelBuilder.Entity<User>()
                .HasMany(u => u.StoresBelonged)
                .WithMany(s => s.Employees)
                .Map(m =>
                {
                    m.MapLeftKey("UserID");
                    m.MapRightKey("StoreID");
                    m.ToTable("StoreEmployees");
                });
            modelBuilder.Entity<User>()
                .HasMany(u => u.StoresCharged)
                .WithMany(s => s.Inspectors)
                .Map(m =>
                {
                    m.MapLeftKey("UserID");
                    m.MapRightKey("StoreID");
                    m.ToTable("StoreInspectors");
                });
        }
    }
}