using Microsoft.EntityFrameworkCore;

namespace Models
{
  [PrimaryKey(nameof(Username))]
  public class Writer {
    public required string Username { get; set; }
    public required string Password { get; set; }
    public required string DisplayName { get; set; }
    public string? Email { get; set; }
  }
}
