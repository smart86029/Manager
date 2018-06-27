﻿// <auto-generated />
using Manager.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Manager.Data.Migrations.System
{
    [DbContext(typeof(SystemContext))]
    partial class SystemContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Manager.Domain.Models.System.Permission", b =>
                {
                    b.Property<int>("PermissionId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<bool>("IsEnabled");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32);

                    b.HasKey("PermissionId");

                    b.ToTable("Permission","System");

                    b.HasData(
                        new { PermissionId = 1, Description = "", IsEnabled = true, Name = "特殊權限" },
                        new { PermissionId = 2, Description = "", IsEnabled = true, Name = "登入" }
                    );
                });

            modelBuilder.Entity("Manager.Domain.Models.System.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsEnabled");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32);

                    b.HasKey("RoleId");

                    b.ToTable("Role","System");

                    b.HasData(
                        new { RoleId = 1, IsEnabled = true, Name = "Administrator" },
                        new { RoleId = 2, IsEnabled = true, Name = "HumanResources" }
                    );
                });

            modelBuilder.Entity("Manager.Domain.Models.System.RolePermission", b =>
                {
                    b.Property<int>("RoleId");

                    b.Property<int>("PermissionId");

                    b.HasKey("RoleId", "PermissionId");

                    b.HasIndex("PermissionId");

                    b.ToTable("RolePermission","System");
                });

            modelBuilder.Entity("Manager.Domain.Models.System.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BusinessEntityId");

                    b.Property<bool>("IsEnabled");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(32);

                    b.HasKey("UserId");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("User","System");

                    b.HasData(
                        new { UserId = 1, BusinessEntityId = 1, IsEnabled = true, PasswordHash = "mnzLU0AcKwCVczln3kVmxnQ4OQhGMHHVWb6/j4Yizs8=", UserName = "Admin" }
                    );
                });

            modelBuilder.Entity("Manager.Domain.Models.System.UserRole", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRole","System");

                    b.HasData(
                        new { UserId = 1, RoleId = 1 },
                        new { UserId = 1, RoleId = 2 }
                    );
                });

            modelBuilder.Entity("Manager.Domain.Models.System.RolePermission", b =>
                {
                    b.HasOne("Manager.Domain.Models.System.Permission", "Permission")
                        .WithMany("RolePermissions")
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Manager.Domain.Models.System.Role", "Role")
                        .WithMany("RolePermissions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Manager.Domain.Models.System.UserRole", b =>
                {
                    b.HasOne("Manager.Domain.Models.System.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Manager.Domain.Models.System.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
