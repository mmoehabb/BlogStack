namespace BlogStack.DTOs
{
  public struct AddWriterDTO
  {
    public required string Username { get; set; }
    public required string Password { get; set; }
    public required string DisplayName { get; set; }
    public string? Email { get; set; }
  }
  public struct AuthWriterDTO
  {
    public required string Username { get; set; }
    public required string Password { get; set; }
  }
}
