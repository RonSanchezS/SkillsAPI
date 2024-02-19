﻿// <auto-generated />
using System;
using LibraryApiReforged.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace LibraryAPI.Migrations
{
    [DbContext(typeof(LibraryDbContext))]
    partial class LibraryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LibraryAPI.Models.Goal", b =>
                {
                    b.Property<Guid>("GoalID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.HasKey("GoalID");

                    b.HasIndex("UserID");

                    b.ToTable("Goals");
                });

            modelBuilder.Entity("LibraryAPI.Models.Lesson", b =>
                {
                    b.Property<Guid>("LessonID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DifficultyLevel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DurationEstimate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LessonID");

                    b.ToTable("Lessons");
                });

            modelBuilder.Entity("LibraryAPI.Models.LessonSkill", b =>
                {
                    b.Property<Guid>("LessonID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SkillID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LessonID", "SkillID");

                    b.HasIndex("SkillID");

                    b.ToTable("LessonSkills");
                });

            modelBuilder.Entity("LibraryAPI.Models.Skill", b =>
                {
                    b.Property<Guid>("SkillID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MasteryLevel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SkillID");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("LibraryAPI.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("LibraryAPI.Models.UserLesson", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<Guid>("LessonID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "LessonID");

                    b.HasIndex("LessonID");

                    b.ToTable("UserLessons");
                });

            modelBuilder.Entity("LibraryAPI.Models.UserSkill", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<Guid>("SkillID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "SkillID");

                    b.HasIndex("SkillID");

                    b.ToTable("UserSkills");
                });

            modelBuilder.Entity("LibraryAPI.Models.Goal", b =>
                {
                    b.HasOne("LibraryAPI.Models.User", "User")
                        .WithMany("Goals")
                        .HasForeignKey("UserID");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LibraryAPI.Models.LessonSkill", b =>
                {
                    b.HasOne("LibraryAPI.Models.Lesson", "Lesson")
                        .WithMany("LessonSkills")
                        .HasForeignKey("LessonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryAPI.Models.Skill", "Skill")
                        .WithMany("LessonSkills")
                        .HasForeignKey("SkillID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lesson");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("LibraryAPI.Models.UserLesson", b =>
                {
                    b.HasOne("LibraryAPI.Models.Lesson", "Lesson")
                        .WithMany("UserLessons")
                        .HasForeignKey("LessonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryAPI.Models.User", "User")
                        .WithMany("UserLessons")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lesson");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LibraryAPI.Models.UserSkill", b =>
                {
                    b.HasOne("LibraryAPI.Models.Skill", "Skill")
                        .WithMany("UserSkills")
                        .HasForeignKey("SkillID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryAPI.Models.User", "User")
                        .WithMany("UserSkills")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Skill");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LibraryAPI.Models.Lesson", b =>
                {
                    b.Navigation("LessonSkills");

                    b.Navigation("UserLessons");
                });

            modelBuilder.Entity("LibraryAPI.Models.Skill", b =>
                {
                    b.Navigation("LessonSkills");

                    b.Navigation("UserSkills");
                });

            modelBuilder.Entity("LibraryAPI.Models.User", b =>
                {
                    b.Navigation("Goals");

                    b.Navigation("UserLessons");

                    b.Navigation("UserSkills");
                });
#pragma warning restore 612, 618
        }
    }
}
