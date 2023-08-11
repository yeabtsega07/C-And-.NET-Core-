using BlogApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data
{

    public class BlogDbContext : DbContext
    {   
        // DbSets for each model
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public BlogDbContext (DbContextOptions<BlogDbContext> options)
            : base(options)
        {
            
        }


        // override OnModelCreating to configure relationships
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   
            base.OnModelCreating(modelBuilder);

            // one to many relationship between Post and Comment
            // post has many comments
            modelBuilder.Entity<Comment>(entity => {
                entity
                    .HasOne(c => c.Post)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(c => c.PostId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Comment_Post");
            });

        }
    }

}