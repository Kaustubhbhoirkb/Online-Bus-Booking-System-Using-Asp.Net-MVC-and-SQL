using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace rough.Models
{
    public partial class rough1Context : DbContext
    {
        public rough1Context()
        {
        }

        public rough1Context(DbContextOptions<rough1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Addbu> Addbus { get; set; } = null!;
        public virtual DbSet<Adminlogin> Adminlogins { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=NSL-LTRG030\\SQLEXPRESS19;Database=rough1;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Addbu>(entity =>
            {
                entity.ToTable("addbus");

                entity.Property(e => e.DateOfTransaction).HasColumnName("Date_Of_Transaction");
            });

            modelBuilder.Entity<Adminlogin>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("adminlogin");

                entity.Property(e => e.AdminId)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Admin_Id");

                entity.Property(e => e.Password)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employee");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.EmpName)
                    .HasMaxLength(100)
                    .HasColumnName("Emp_name");

                entity.Property(e => e.EmployeeId)
                    .HasMaxLength(100)
                    .HasColumnName("Employee_id");

                entity.Property(e => e.Gender).HasMaxLength(100);

                entity.Property(e => e.Password).HasMaxLength(100);

                entity.Property(e => e.Salary).HasColumnType("decimal(18, 0)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
