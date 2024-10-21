using Microsoft.EntityFrameworkCore;

namespace Models
{
  [PrimaryKey(nameof(Id))]
  public class Post {
    public required int Id { get; set; }
    public required Writer Writer { get; set; }
    public required string Title { get; set; }
    public required string Content { get; set; }
    public required DateTime Date { get; set; }
  }
}
