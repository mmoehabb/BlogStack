using Microsoft.AspNetCore.Http.HttpResults;
using Models;

public class WriterController
{
  private BloggingContext service;

  public WriterController(IServiceScope scope) 
  {
    this.service = scope.ServiceProvider.GetRequiredService<BloggingContext>();
  }

  public Writer? Get(string username) 
  {
    return service.Writers.Find(username);
  }

  public bool Exists(Writer w) 
  {
    return service.Writers.Any(writer =>
      writer.Username.Equals(w.Username) ||
      writer.Email != null && writer.Email.Equals(w.Email)
    );
  }

  public Dictionary<string, string> Add(Writer w) 
  {
    var errors = WriterValidator.Validate(w);
    if (errors.Any()) {
      return errors;
    }
    service.Writers.Add(w);
    service.SaveChanges();
    return errors;
  }

  public Results<Ok, NotFound> Remove(Writer w) 
  {
    var found = service.Writers.Any(e => e.Equals(w));
    if (!found) {
      return TypedResults.NotFound();
    }
    service.Writers.Remove(w);
    service.SaveChanges();
    return TypedResults.Ok();
  }
}
