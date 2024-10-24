namespace BlogStack.DTOs
{
  public static class WriterDTOs 
  {
    public struct Add 
    {
      public required string Username { get; set; }
      public required string Password { get; set; }
      public required string DisplayName { get; set; }
      public string? Email { get; set; }
    }
    public struct Auth
    {
      public required string Username { get; set; }
      public required string Password { get; set; }
    }
  }
}
