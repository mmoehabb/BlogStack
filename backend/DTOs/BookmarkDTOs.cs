namespace BlogStack.DTOs
{
  public struct GetBookmarkDTO {
    public required int Id { get; set; }
    public required string PostTitle { get; set; }
  }
  public struct AddBookmarkDTO
  {
    public required int PostId { get; set; }
    public required AuthWriterDTO Writer { get; set; }
  }
  public struct RmvBookmarkDTO
  {
    public required int Id { get; set; }
    public required AuthWriterDTO Writer { get; set; }
  }
}
