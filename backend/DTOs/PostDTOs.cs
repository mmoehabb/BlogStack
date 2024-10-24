namespace BlogStack.DTOs
{
  public struct GetPostDTO 
  {
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Content { get; set; }
    public DateTime Date { get; set; }
  }
  public struct AddPostDTO
  {
    public required AuthWriterDTO Writer { get; set; }
    public required string Title { get; set; }
    public required string Content { get; set; }
  }
  public struct RmvPostDTO
  {
    public required int Id { get; set; }
    public required AuthWriterDTO Writer { get; set; }
  }
}
