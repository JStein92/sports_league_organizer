using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SportsLeagueOrganizer.Models;

namespace SportsLeagueOrganizer.Migrations
{
    [DbContext(typeof(SportsLeagueOrganizerContext))]
    [Migration("20171012175553_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("SportsLeagueOrganizer.Models.Division", b =>
                {
                    b.Property<int>("DivisionId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DivisionName");

                    b.Property<string>("SkillLevel");

                    b.HasKey("DivisionId");

                    b.ToTable("Divisions");
                });

            modelBuilder.Entity("SportsLeagueOrganizer.Models.Team", b =>
                {
                    b.Property<int>("TeamId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Captain");

                    b.Property<int>("DivisionId");

                    b.Property<string>("Players");

                    b.Property<string>("TeamName");

                    b.HasKey("TeamId");

                    b.HasIndex("DivisionId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("SportsLeagueOrganizer.Models.Team", b =>
                {
                    b.HasOne("SportsLeagueOrganizer.Models.Division", "Division")
                        .WithMany("Teams")
                        .HasForeignKey("DivisionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
