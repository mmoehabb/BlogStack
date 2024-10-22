using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BloggingContext>(options =>
  options.UseNpgsql(@"Host=localhost;Username=postgres;Password=postgres;Database=blogstack"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

using (var scope = app.Services.CreateScope()) {
  var service = scope.ServiceProvider.GetRequiredService<BloggingContext>();
  service.Database.EnsureCreated();
}

// Endpoints:
// [GET] /post/{postid}
// [GET] /posts/{index}/{num}
// [GET] /posts/top/{num}
// [GET] /bookmarks/{writer_username}
// [POST] /register
// [POST] /auth
// [POST] /post/add
// [POST] /bookmark/add
// [PATCH] /writer/edit
// [PATCH] /post/edit
// [DELETE] /writer/delete
// [DELETE] /post/delete
// [DELETE] /bookmark/delete

app.MapPost("/register", Results<Ok, Conflict<string>, BadRequest<Dictionary<string, string>>> (Writer w) =>
{
  using (var scope = app.Services.CreateScope())
  {
    var c = new WriterController(scope);
    if (c.Exists(w)) {
      return TypedResults.Conflict("Username or Email is already used.");
    }
    w.Password = Hasher.HmacSHA256("justanarbitrarykey", w.Password);
    var errors = c.Add(w);
    if (errors.Any()) {
      return TypedResults.BadRequest(errors);
    }
    return TypedResults.Ok();
  }
})
.WithName("AddWriter")
.WithOpenApi();

app.MapPost("/auth", Results<Ok, UnauthorizedHttpResult, NotFound> (Writer w) =>
{
  using (var scope = app.Services.CreateScope()) 
  {
    var c = new WriterController(scope);
    var data = c.Get(w.Username);
    if (data == null) {
      return TypedResults.NotFound();
    }
    w.Password = Hasher.HmacSHA256("justanarbitrarykey", w.Password);
    if (!data.Password.Equals(w.Password)) {
      return TypedResults.Unauthorized();
    }
    return TypedResults.Ok();
  }
})
.WithName("Authenticate")
.WithOpenApi();

app.Run();

