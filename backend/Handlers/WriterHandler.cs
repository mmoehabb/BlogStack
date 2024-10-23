using Microsoft.AspNetCore.Http.HttpResults;
using Models;

public class WriterHandler 
{
  private WebApplication app;

  public WriterHandler(WebApplication app) {
    this.app = app;
  }

  public async Task<Results<
    Ok, 
    Conflict<string>, 
    BadRequest<Dictionary<string, string>>
  >> Register (Writer w)
  {
    using (var scope = app.Services.CreateScope())
    {
      var c = new WriterController(scope);
      if (c.Exists(w)) {
        return TypedResults.Conflict("Username or Email is already used.");
      }
      w.Password = Hasher.HmacSHA256("justanarbitrarykey", w.Password);
      var errors = await c.Add(w);
      if (errors.Any()) {
        return TypedResults.BadRequest(errors);
      }
      return TypedResults.Ok();
    }
  }

  public async Task<Results<Ok, UnauthorizedHttpResult, NotFound>> Auth (Writer w) 
  {
    using (var scope = app.Services.CreateScope()) 
    {
      var c = new WriterController(scope);
      var data = await c.Get(w.Username);
      if (data == null) {
        return TypedResults.NotFound();
      }
      w.Password = Hasher.HmacSHA256("justanarbitrarykey", w.Password);
      if (!data.Password.Equals(w.Password)) {
        return TypedResults.Unauthorized();
      }
      return TypedResults.Ok();
    }
  }
}
