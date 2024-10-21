using Microsoft.EntityFrameworkCore;

public class BloggingContext : DbContext {
  public required DbSet<Models.Writer> Writers;
  public required DbSet<Models.Post> Posts;
  public required DbSet<Models.Bookmark> Bookmarks;

  public BloggingContext(DbContextOptions<BloggingContext> options) : base(options) {}

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.UseNpgsql(@"Host=localhost;Username=postgres;Password=postgres;Database=blogstack");
    base.OnConfiguring(optionsBuilder);
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Models.Writer>().ToTable("writers");
    modelBuilder.Entity<Models.Post>().ToTable("posts");
    modelBuilder.Entity<Models.Bookmark>().ToTable("bookmarks");
    base.OnModelCreating(modelBuilder);
  }
}
