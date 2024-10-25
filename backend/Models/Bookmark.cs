using Microsoft.EntityFrameworkCore;

namespace BlogStack.Models
{
  [PrimaryKey(nameof(Id))]
  public class Bookmark {
    public int Id { get; set; }

    public string? WriterUsername { get; set; }
    public Writer? Writer { get; set; }

    public int? PostId { get; set; }
    public Post? Post  { get; set; }
  }
}
