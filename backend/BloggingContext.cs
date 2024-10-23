using Microsoft.EntityFrameworkCore;
using BlogStack.Models;

public class BloggingContext : DbContext 
{
  public required DbSet<Writer> Writers { get; set; }
  public required DbSet<Post> Posts { get; set; }
  public required DbSet<Bookmark> Bookmarks { get; set; }

  public BloggingContext(DbContextOptions<BloggingContext> options) : base(options) {}

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Writer>().HasIndex(w => w.Email).IsUnique();
    modelBuilder.Entity<Writer>().ToTable("writers");
    
    modelBuilder.Entity<Post>().Property(p => p.Id).UseSerialColumn();
    modelBuilder.Entity<Post>().Property(p => p.Date).HasDefaultValueSql("NOW()");
    modelBuilder.Entity<Post>().ToTable("posts");

    modelBuilder.Entity<Bookmark>().Property(b => b.Id).UseSerialColumn();
    modelBuilder.Entity<Bookmark>().ToTable("bookmarks");
    base.OnModelCreating(modelBuilder);
  }
}
