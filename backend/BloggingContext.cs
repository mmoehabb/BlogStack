using Microsoft.EntityFrameworkCore;
using Models;

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

public static class DbInitializer 
{
  public static void Initialize(BloggingContext context) 
  {
    if (context.Writers.Any()) {
      return; // Data has been seeded.
    }
    var writers = new Writer[] {
      new Writer{Username="Smith",Password="123321",DisplayName="SmithTheWriter",Email="smith@example.com"},
      new Writer{Username="Jack",Password="123123",DisplayName="JackBlogs",Email="jack@example.com"},
      new Writer{Username="John",Password="123456",DisplayName="JustJohn",Email="john@example.com"},
    };
    context.Writers.AddRange(writers);

    var posts = new Post[] {
      new Post{ Title="My first post.", Content="Just discovering the application!", Writer=writers[0] },
    };
    context.Posts.AddRange(posts);

    var bookmarks = new Bookmark[] {
      new Bookmark{ Writer=writers[1], Post=posts[0] }
    };
    context.Bookmarks.AddRange(bookmarks);
    context.SaveChanges();
  }
}
