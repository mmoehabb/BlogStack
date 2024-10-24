using BlogStack.Models;

public static class PostValidator 
{
  // Validate function ensures that a writer object is well supplied
  // and returns an empty dictionary. Otherwise, it returns the di-
  // ctionary filled with the related invalid data inputs.
  public static Dictionary<string, string> Validate(Post p)
  {
    var errors = new Dictionary<string, string>();
    if (p.Title.Length < 8) errors["title"] = "Title must contain at least 8 characters.";
    if (p.Content.Length < 16) errors["content"] = "Content must contain at least 16 characters.";
    return errors;
  }
}
