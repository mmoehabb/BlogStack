using Microsoft.AspNetCore.Http.HttpResults;
using Models;

public class WriterController
{
  private BloggingContext service;

  public WriterController(IServiceScope scope) {
    this.service = scope.ServiceProvider.GetRequiredService<BloggingContext>();
  }

  public bool Conflict(Writer w) {
    return service.Writers.Any(writer => 
      writer.Username.Equals(w.Username) ||
      writer.Email != null && writer.Email.Equals(w.Email)
    );
  }

  public Results<Ok, BadRequest<string>> Add(Writer w) {
    service.Writers.Add(w);
    service.SaveChanges();
    return TypedResults.Ok();
  } 
}
