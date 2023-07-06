﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyBookList.Data;

#nullable disable

namespace MyBookList.Migrations
{
    [DbContext(typeof(MyBookListContext))]
    partial class MyBookListContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AuthorsBooks", b =>
                {
                    b.Property<int>("AuthorsListId")
                        .HasColumnType("int");

                    b.Property<string>("BookListISBN")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("AuthorsListId", "BookListISBN");

                    b.HasIndex("BookListISBN");

                    b.ToTable("AuthorsBooks");
                });

            modelBuilder.Entity("MyBookList.Models.Authors", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Biography")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("MyBookList.Models.Books", b =>
                {
                    b.Property<string>("ISBN")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PublisherFK")
                        .HasColumnType("int");

                    b.Property<decimal>("Score")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ISBN");

                    b.HasIndex("PublisherFK");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("MyBookList.Models.Genres", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("BooksISBN")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BooksISBN");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("MyBookList.Models.Members", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("MyBookList.Models.Publishers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Publishers");
                });

            modelBuilder.Entity("MyBookList.Models.Status", b =>
                {
                    b.Property<int>("MemberFK")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<string>("BookFK")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnOrder(1);

                    b.Property<string>("Review")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReviewDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ScoreRating")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MemberFK", "BookFK");

                    b.HasIndex("BookFK");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("AuthorsBooks", b =>
                {
                    b.HasOne("MyBookList.Models.Authors", null)
                        .WithMany()
                        .HasForeignKey("AuthorsListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyBookList.Models.Books", null)
                        .WithMany()
                        .HasForeignKey("BookListISBN")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MyBookList.Models.Books", b =>
                {
                    b.HasOne("MyBookList.Models.Publishers", "Publisher")
                        .WithMany("BookList")
                        .HasForeignKey("PublisherFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("MyBookList.Models.Genres", b =>
                {
                    b.HasOne("MyBookList.Models.Books", null)
                        .WithMany("GenresList")
                        .HasForeignKey("BooksISBN");
                });

            modelBuilder.Entity("MyBookList.Models.Status", b =>
                {
                    b.HasOne("MyBookList.Models.Books", "Book")
                        .WithMany("StatusList")
                        .HasForeignKey("BookFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyBookList.Models.Members", "Member")
                        .WithMany("StatusList")
                        .HasForeignKey("MemberFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("MyBookList.Models.Books", b =>
                {
                    b.Navigation("GenresList");

                    b.Navigation("StatusList");
                });

            modelBuilder.Entity("MyBookList.Models.Members", b =>
                {
                    b.Navigation("StatusList");
                });

            modelBuilder.Entity("MyBookList.Models.Publishers", b =>
                {
                    b.Navigation("BookList");
                });
#pragma warning restore 612, 618
        }
    }
}