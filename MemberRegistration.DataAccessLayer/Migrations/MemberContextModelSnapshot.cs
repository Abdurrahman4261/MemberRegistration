﻿// <auto-generated />
using System;
using MemberRegistration.DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MemberRegistration.DataAccessLayer.Migrations
{
    [DbContext(typeof(MemberContext))]
    partial class MemberContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MemberRegistration.EntityLayer.Concrete.Answer", b =>
                {
                    b.Property<int>("AnswerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AnswerId"));

                    b.Property<string>("Answer1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Answer10")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Answer2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Answer3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Answer4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Answer5")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Answer6")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Answer7")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Answer8")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Answer9")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("AnswerId");

                    b.HasIndex("UserId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("MemberRegistration.EntityLayer.Concrete.Resume", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Resumes");
                });

            modelBuilder.Entity("MemberRegistration.EntityLayer.Concrete.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"));

                    b.Property<int>("UserRoleId")
                        .HasColumnType("int");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("MemberRegistration.EntityLayer.Concrete.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegisterTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Topicality")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserRoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MemberRegistration.EntityLayer.Concrete.UserRole", b =>
                {
                    b.Property<int>("UserRoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserRoleId"));

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("UserRoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("MemberRegistration.EntityLayer.Model.AllUserInfos", b =>
                {
                    b.Property<int>("AllUserInfosId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AllUserInfosId"));

                    b.Property<int>("NumberOfSurveyAnswers")
                        .HasColumnType("int");

                    b.Property<int>("QuestioEightResponseRate")
                        .HasColumnType("int");

                    b.Property<int>("QuestioFiveResponseRate")
                        .HasColumnType("int");

                    b.Property<int>("QuestioFourResponseRate")
                        .HasColumnType("int");

                    b.Property<int>("QuestioNineResponseRate")
                        .HasColumnType("int");

                    b.Property<int>("QuestioOneResponseRate")
                        .HasColumnType("int");

                    b.Property<int>("QuestioSevenResponseRate")
                        .HasColumnType("int");

                    b.Property<int>("QuestioSixResponseRate")
                        .HasColumnType("int");

                    b.Property<int>("QuestioTenResponseRate")
                        .HasColumnType("int");

                    b.Property<int>("QuestioThreeResponseRate")
                        .HasColumnType("int");

                    b.Property<int>("QuestioTwoResponseRate")
                        .HasColumnType("int");

                    b.Property<int>("Topicality")
                        .HasColumnType("int");

                    b.HasKey("AllUserInfosId");

                    b.ToTable("AllUserInfos");
                });

            modelBuilder.Entity("MemberRegistration.EntityLayer.Concrete.Answer", b =>
                {
                    b.HasOne("MemberRegistration.EntityLayer.Concrete.User", null)
                        .WithMany("Answers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MemberRegistration.EntityLayer.Concrete.Resume", b =>
                {
                    b.HasOne("MemberRegistration.EntityLayer.Concrete.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MemberRegistration.EntityLayer.Concrete.UserRole", b =>
                {
                    b.HasOne("MemberRegistration.EntityLayer.Concrete.Role", null)
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MemberRegistration.EntityLayer.Concrete.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("MemberRegistration.EntityLayer.Concrete.User", b =>
                {
                    b.Navigation("Answers");
                });
#pragma warning restore 612, 618
        }
    }
}
