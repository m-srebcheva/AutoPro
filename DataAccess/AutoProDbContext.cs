using DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
	public class AutoProDbContext : DbContext
	{
		public AutoProDbContext(DbContextOptions<AutoProDbContext> options)
			: base(options)
		{
		}

		public DbSet<Appointment> Appointments { get; set; }

		public DbSet<Brand> Brands { get; set; }

		public DbSet<Car> Cars { get; set; }

		public DbSet<Service> Services { get; set; }

		public DbSet<Technician> Technicians { get; set; }

		public DbSet<User> Users { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Appointment>(entity =>
			{
				entity.HasKey(e => e.Id);

				entity.Property(e => e.VisitDate);

				entity.Property(e => e.CreationDate);

				entity.Property(e => e.IsConfirmed);

				entity.HasOne(e => e.Service)
					.WithMany(s => s.Appointments)
					.HasForeignKey(e => e.ServiceId);

				entity.HasOne(e => e.Technician)
					.WithMany(t => t.Appointments)
					.HasForeignKey(e => e.TechnicianId);

				entity.HasOne(e => e.User)
					.WithMany(a => a.Appointments)
					.HasForeignKey(e => e.UserId);
			});

			modelBuilder.Entity<Brand>(entity =>
			{
				entity.HasKey(e => e.Id);

				entity.Property(e => e.Name)
					.IsRequired();
			});

			modelBuilder.Entity<Car>(entity =>
			{
				entity.HasKey(entity => entity.RegistrationNumber);

				entity.Property(e => e.Model);

				entity.HasOne(e => e.Brand)
					.WithMany(b => b.Cars)
					.HasForeignKey(e => e.BrandId);

				entity.HasOne(e => e.User)
					.WithMany(u => u.Cars)
					.HasForeignKey(e => e.UserId);
			});

			modelBuilder.Entity<Service>(entity =>
			{
				entity.HasKey(e => e.Id);

				entity.Property(e => e.Name);

				entity.Property(e => e.Description);

				entity.Property(e => e.Price);
			});

			modelBuilder.Entity<Technician>(entity =>
			{
				entity.HasKey(e => e.Id);

				entity.Property(e => e.FirstName);

				entity.Property(e => e.LastName);
			});

			modelBuilder.Entity<User>(entity =>
			{
				entity.HasKey(e => e.Id);

				entity.Property(e => e.FirstName);

				entity.Property(e => e.LastName);

				entity.Property(e => e.Email);

				entity.Property(e => e.PhoneNumber);

				entity.Property(e => e.Role);
			});
		}
	}
}
