using Microsoft.EntityFrameworkCore;

namespace Models
{
  [Keyless]
  public class Bookmark {
    public required Writer Writer { get; set; }
    public required Post Post  { get; set; }
  }
}
