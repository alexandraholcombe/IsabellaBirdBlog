using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using IsabellaBirdBlog.Models;

namespace IsabellaBirdBlog.Migrations
{
    [DbContext(typeof(IsabellaBirdBlogContext))]
    [Migration("20170420152437_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IsabellaBirdBlog.Models.Experience", b =>
                {
                    b.Property<int>("ExperienceId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ExperienceDesc")
                        .IsRequired()
                        .HasColumnType("varchar(MAX)");

                    b.Property<string>("ExperienceName")
                        .IsRequired();

                    b.Property<int>("LocationId");

                    b.HasKey("ExperienceId");

                    b.HasIndex("LocationId");

                    b.ToTable("Experiences");
                });

            modelBuilder.Entity("IsabellaBirdBlog.Models.Location", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("GeoClass")
                        .IsRequired();

                    b.Property<string>("LocationName")
                        .IsRequired();

                    b.HasKey("LocationId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("IsabellaBirdBlog.Models.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("LocationId");

                    b.Property<string>("PersonName")
                        .IsRequired();

                    b.HasKey("PersonId");

                    b.HasIndex("LocationId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("IsabellaBirdBlog.Models.PersonExperience", b =>
                {
                    b.Property<int>("PersonId");

                    b.Property<int>("ExperienceId");

                    b.HasKey("PersonId", "ExperienceId");

                    b.HasIndex("ExperienceId");

                    b.HasIndex("PersonId");

                    b.ToTable("PersonsExperiences");
                });

            modelBuilder.Entity("IsabellaBirdBlog.Models.Experience", b =>
                {
                    b.HasOne("IsabellaBirdBlog.Models.Location", "Location")
                        .WithMany("Experiences")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IsabellaBirdBlog.Models.Person", b =>
                {
                    b.HasOne("IsabellaBirdBlog.Models.Location", "Location")
                        .WithMany("Persons")
                        .HasForeignKey("LocationId");
                });

            modelBuilder.Entity("IsabellaBirdBlog.Models.PersonExperience", b =>
                {
                    b.HasOne("IsabellaBirdBlog.Models.Experience", "Experience")
                        .WithMany("PersonsExperiences")
                        .HasForeignKey("ExperienceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("IsabellaBirdBlog.Models.Person", "Person")
                        .WithMany("PersonsExperiences")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
