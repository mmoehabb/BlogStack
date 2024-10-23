using Microsoft.AspNetCore.Http.HttpResults;
using Models;

public class WriterController
{
  private BloggingContext service;

  public WriterController(IServiceScope scope) 
  {
    this.service = scope.ServiceProvider.GetRequiredService<BloggingContext>();
  }

  public async Task<Writer?> Get(string username) 
  {
    return await service.Writers.FindAsync(username);
  }

  public bool Exists(Writer w) 
  {
    return service.Writers.Any(writer =>
      writer.Username.Equals(w.Username) ||
      writer.Email != null && writer.Email.Equals(w.Email)
    );
  }

  public async Task<Dictionary<string, string>> Add(Writer w) 
  {
    var errors = WriterValidator.Validate(w);
    if (errors.Any()) {
      return errors;
    }
    await service.Writers.AddAsync(w);
    await service.SaveChangesAsync();
    return errors;
  }

  public async Task<Results<Ok, NotFound>> Remove(Writer w) 
  {
    var found = service.Writers.Any(e => e.Equals(w));
    if (!found) {
      return TypedResults.NotFound();
    }
    service.Writers.Remove(w);
    await service.SaveChangesAsync();
    return TypedResults.Ok();
  }
}
