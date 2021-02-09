using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace BookLib.DAL.Entities
{
    /// <summary>
    /// Database context class for the given database
    /// </summary>
    public partial class BookLibContext : DbContext
    {
        public BookLibContext()
        {
            Database.EnsureCreated();
        }

        public BookLibContext(DbContextOptions<BookLibContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<ReadingProgress> ReadingProgresses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //Hides the connection string from storing here
                var builder = new ConfigurationBuilder();
                builder.SetBasePath(Directory.GetCurrentDirectory());
                builder.AddJsonFile("appsettings.json");
                var config = builder.Build();
                string connectionString = config.GetConnectionString("Main");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Ukrainian_CI_AS");

            modelBuilder.Entity<Author>(entity =>
            {
                entity.HasIndex(e => e.Name, "UQ__Authors__737584F67AEC10FF")
                    .IsUnique();

                entity.Property(e => e.ID).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasIndex(e => e.BookName, "UQ__Books__876F4DA1BBF6BF11")
                    .IsUnique();

                entity.Property(e => e.ID).HasColumnName("ID");

                entity.Property(e => e.AuthorID).HasColumnName("AuthorsID");

                entity.Property(e => e.BookName)
                    .IsRequired()
                    .HasMaxLength(70);

                entity.HasOne(d => d.Authors)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.AuthorID)
                    .HasConstraintName("FK__Books__AuthorsID__7D0E9093");
            });

            modelBuilder.Entity<ReadingProgress>(entity =>
            {
                entity.ToTable("ReadingProgress");

                entity.HasIndex(e => e.BookdID, "UQ__ReadingP__E7C520CF0DE12E07")
                    .IsUnique();

                entity.Property(e => e.ID).HasColumnName("ID");

                entity.Property(e => e.BookdID).HasColumnName("BooksID");

                entity.Property(e => e.FinishPage)
                    .HasMaxLength(8)
                    .HasDefaultValueSql("('Finished')");

                entity.Property(e => e.IsCompleted)
                    .IsRequired()
                    .HasMaxLength(3)
                    .HasDefaultValueSql("('Yes')");

                entity.HasOne(d => d.Books)
                    .WithOne(p => p.ReadingProgress)
                    .HasForeignKey<ReadingProgress>(d => d.BookdID)
                    .HasConstraintName("FK__ReadingPr__Books__00DF2177");
            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
