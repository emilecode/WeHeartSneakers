using Microsoft.EntityFrameworkCore;
using WeHeartSneakers.API.Entities;

namespace WeHeartSneakers.API.Data;

public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
	{ }


	public DbSet<Product> Products { get; set; }


	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Product>(entity =>
		{
			entity.HasKey(p => p.Id);
			entity.Property(p => p.Name)
				.IsRequired()
				.HasMaxLength(150);
			entity.Property(p => p.Description)
				.HasMaxLength(2000);
			entity.Property(p => p.Price)
				.HasPrecision(10, 2);
			entity.Property(p => p.IsActive)
				.HasDefaultValue(true);
			entity.Property(p => p.CreatedAt)
				.IsRequired();
			entity.Property(p => p.UpdatedAt)
				.IsRequired(false);
		});
	}
}
