using Microsoft.EntityFrameworkCore;

namespace Models
{
  [PrimaryKey(nameof(Id))]
  public class Bookmark {
    public int Id { get; set; }
    public required Writer Writer { get; set; }
    public required Post Post  { get; set; }
  }
}
