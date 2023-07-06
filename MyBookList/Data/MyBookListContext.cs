using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyBookList.Models;

namespace MyBookList.Data
{
    public class MyBookListContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Status>()
                .HasKey(s => new { s.MemberFK, s.BookFK });
        }

        public MyBookListContext (DbContextOptions<MyBookListContext> options)
            : base(options)
        {
        }

        public DbSet<MyBookList.Models.Genres> Genres { get; set; } = default!;

        public DbSet<MyBookList.Models.Status>? Status { get; set; }

        public DbSet<MyBookList.Models.Authors>? Authors { get; set; }

        public DbSet<MyBookList.Models.Publishers>? Publishers { get; set; }

        public DbSet<MyBookList.Models.Books>? Books { get; set; }

        public DbSet<MyBookList.Models.Members>? Members { get; set; }
    }
}
