using Microsoft.EntityFrameworkCore;

namespace SportsLeagueOrganizer.Models
{
	public class SportsLeagueOrganizerContext : DbContext
	{

        public SportsLeagueOrganizerContext(){
            
        }
		public DbSet<Division> Divisions { get; set; }
		public DbSet<Team> Teams { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
			=> optionsBuilder
				.UseMySql(@"Server=localhost;Port=8889;database=sports_league;uid=root;pwd=root;");

		public SportsLeagueOrganizerContext(DbContextOptions<SportsLeagueOrganizerContext> options)
        : base(options)
        {
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}
	}

}

