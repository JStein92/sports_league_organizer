using Microsoft.EntityFrameworkCore;
using SportsLeagueOrganizer.Models;

namespace SportsLeagueOrganizerListWithMigrations.Models
{
	public class SportsLeagueOrganizerDbContext : DbContext
	{
		public SportsLeagueOrganizerDbContext()
		{
		}

		public DbSet<Division> Divisions { get; set; }

		public DbSet<Team> Teams { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseMySql(@"Server=localhost;Port=8889;database=sports_league;uid=root;pwd=root;");
		}

		public SportsLeagueOrganizerDbContext(DbContextOptions<SportsLeagueOrganizerDbContext> options)
			: base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}
	}
}