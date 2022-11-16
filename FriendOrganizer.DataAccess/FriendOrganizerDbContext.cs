using FriendOrganizer.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace FriendOrganizer.DataAccess
{
    public class FriendOrganizerDbContext : DbContext
    {
        public DbSet<Friend> Friends { get; set; }

        public string DbPath { get; }

        public FriendOrganizerDbContext()
        {
            DbPath = Path.Join(AppDomain.CurrentDomain.BaseDirectory, "AvaloniaFriendOrganizer.db");
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Friend>(entity => { entity.Property(x => x.FirstName).IsRequired(); });

            #region FriendSeed
            modelBuilder.Entity<Friend>()
                .HasData(
                        new Friend { Id = 1, FirstName = "Thomas", LastName = "Huber" },
                            new Friend { Id = 2, FirstName = "Urs", LastName = "Meier" },
                            new Friend { Id = 3, FirstName = "Erkan", LastName = "Egin" },
                            new Friend { Id = 4, FirstName = "Sara", LastName = "Huber" });
            #endregion

            new FriendEntityTypeConfiguration().Configure(modelBuilder.Entity<Friend>());
        }

    }

    public class FriendEntityTypeConfiguration : IEntityTypeConfiguration<Friend>
    {
        public void Configure(EntityTypeBuilder<Friend> builder)
        {
            builder
                .Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(x => x.LastName)
                .HasMaxLength(50);

            builder
                .Property(x => x.Email)
                .HasMaxLength(50);
        }
    }
}
