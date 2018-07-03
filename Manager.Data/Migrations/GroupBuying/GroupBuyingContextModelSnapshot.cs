﻿// <auto-generated />
using System;
using Manager.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Manager.Data.migrations.groupbuying
{
    [DbContext(typeof(GroupBuyingContext))]
    partial class GroupBuyingContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("GroupBuying")
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Manager.Domain.Models.GroupBuying.Store", b =>
                {
                    b.Property<int>("StoreId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Description")
                        .HasMaxLength(512);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32);

                    b.Property<string>("Remark")
                        .HasMaxLength(512);

                    b.HasKey("StoreId");

                    b.ToTable("Store");
                });

            modelBuilder.Entity("Manager.Domain.Models.GroupBuying.Store", b =>
                {
                    b.OwnsOne("Manager.Domain.Models.Generic.Address", "Address", b1 =>
                        {
                            b1.Property<int?>("StoreId")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnName("City")
                                .HasMaxLength(32);

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasColumnName("Country")
                                .HasMaxLength(32);

                            b1.Property<string>("District")
                                .IsRequired()
                                .HasColumnName("District")
                                .HasMaxLength(32);

                            b1.Property<string>("PostalCode")
                                .IsRequired()
                                .HasColumnName("PostalCode")
                                .HasMaxLength(8);

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnName("Street")
                                .HasMaxLength(128);

                            b1.ToTable("Store","GroupBuying");

                            b1.HasOne("Manager.Domain.Models.GroupBuying.Store")
                                .WithOne("Address")
                                .HasForeignKey("Manager.Domain.Models.Generic.Address", "StoreId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("Manager.Domain.Models.Generic.Phone", "Phone", b1 =>
                        {
                            b1.Property<int?>("StoreId")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("AreaCode")
                                .IsRequired()
                                .HasColumnName("AreaCode")
                                .HasMaxLength(4);

                            b1.Property<string>("BaseNumber")
                                .IsRequired()
                                .HasColumnName("BaseNumber")
                                .HasMaxLength(8);

                            b1.Property<string>("CountryCode")
                                .IsRequired()
                                .HasColumnName("CountryCode")
                                .HasMaxLength(4);

                            b1.Property<string>("Extension")
                                .IsRequired()
                                .HasColumnName("Extension")
                                .HasMaxLength(8);

                            b1.Property<int>("PhoneType")
                                .HasColumnName("PhoneType");

                            b1.ToTable("Store","GroupBuying");

                            b1.HasOne("Manager.Domain.Models.GroupBuying.Store")
                                .WithOne("Phone")
                                .HasForeignKey("Manager.Domain.Models.Generic.Phone", "StoreId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
