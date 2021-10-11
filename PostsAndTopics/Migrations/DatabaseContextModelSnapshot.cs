﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PostsAndTopics.Models.Database;

namespace PostsAndTopics.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PostsAndTopics.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Thought")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TopicId")
                        .HasColumnType("int");

                    b.Property<long?>("TopicId1")
                        .HasColumnType("bigint");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<long?>("UserId1")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("TopicId1");

                    b.HasIndex("UserId1");

                    b.ToTable("Post");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Thought = "We need to start by sorting the trash!",
                            TopicId = 1,
                            UserId = 2
                        },
                        new
                        {
                            Id = 2,
                            Thought = "also do not use natural animal hair",
                            TopicId = 1,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("PostsAndTopics.Models.Topic", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Theme")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<long?>("UserId1")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId1");

                    b.ToTable("Topic");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Theme = "Environment",
                            UserId = 1
                        });
                });

            modelBuilder.Entity("PostsAndTopics.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Password = "123456",
                            UserName = "Alex"
                        },
                        new
                        {
                            Id = 2L,
                            Password = "123456",
                            UserName = "Masha"
                        });
                });

            modelBuilder.Entity("PostsAndTopics.Models.Post", b =>
                {
                    b.HasOne("PostsAndTopics.Models.Topic", null)
                        .WithMany("Posts")
                        .HasForeignKey("TopicId1");

                    b.HasOne("PostsAndTopics.Models.User", null)
                        .WithMany("Posts")
                        .HasForeignKey("UserId1");
                });

            modelBuilder.Entity("PostsAndTopics.Models.Topic", b =>
                {
                    b.HasOne("PostsAndTopics.Models.User", null)
                        .WithMany("Topics")
                        .HasForeignKey("UserId1");
                });

            modelBuilder.Entity("PostsAndTopics.Models.Topic", b =>
                {
                    b.Navigation("Posts");
                });

            modelBuilder.Entity("PostsAndTopics.Models.User", b =>
                {
                    b.Navigation("Posts");

                    b.Navigation("Topics");
                });
#pragma warning restore 612, 618
        }
    }
}
