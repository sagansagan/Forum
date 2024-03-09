using Forum.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Forum.Web.Data
{
    public class ForumDbContext : DbContext
    {
        public ForumDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<TopicModel> Topics { get; set; }
        public DbSet<ThreadModel> Threads { get; set; }
        public DbSet<ReplyModel> Replies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //foreign keys mapping
            modelBuilder.Entity<ThreadModel>()
                .HasOne(x => x.Topic)
                .WithMany(x => x.Threads)
                .HasForeignKey(x => x.TopicId);


            modelBuilder.Entity<ReplyModel>()
                .HasOne(x => x.Thread)
                .WithMany(x => x.Replies)
                .HasForeignKey(x => x.ThreadId);

            // Database Seeding
            modelBuilder.Entity<TopicModel>().HasData(
                    new TopicModel { Id = 1, Title = "Cats", Description = "Discussion" },
                    new TopicModel { Id = 2, Title = "Food", Description = "Tips and Recipes" },
                    new TopicModel { Id = 3, Title = "Help", Description = "Get help" },
                    new TopicModel { Id = 4, Title = "Nature", Description = "Best sights" },
                    new TopicModel { Id = 5, Title = "Make-up", Description = "Tips and tricks" });
        }
    }
}
