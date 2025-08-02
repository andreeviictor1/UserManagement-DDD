using Microsoft.EntityFrameworkCore;
using UserManagement.Domain.Entities;
using System.Data.Common;
using UserManagement.Domain.Entities.User;

namespace UserManagement.Infrastructure.Data
{
    public class UserManagementDbContext : DbContext
    {

        public UserManagementDbContext(DbContextOptions<UserManagementDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nome).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Password).IsRequired().HasMaxLength(200);
                entity.Property(e => e.CreatedAt).IsRequired();
                entity.Property(e => e.UpdatedAt);

                entity.HasIndex(e => e.Email).IsUnique();

            });
        }


    }
}
