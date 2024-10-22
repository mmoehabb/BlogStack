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
  DbInitializer.Initialize(service);
}

// Endpoints:
// [GET] /post/{postid}
// [GET] /posts/{index}/{num}
// [GET] /posts/top/{num}
// [GET] /bookmarks/{writer_username}
// [POST] /register
// [POST] /login
// [POST] /post/add
// [POST] /bookmark/add
// [PATCH] /writer/edit
// [PATCH] /post/edit
// [DELETE] /writer/delete
// [DELETE] /post/delete
// [DELETE] /bookmark/delete

app.MapPost("/register", Results<Ok, Conflict<string>> (Writer w) =>
{
  using (var scope = app.Services.CreateScope()) {
    var c = new WriterController(scope);
    if (c.Conflict(w)) {
      return TypedResults.Conflict("Username or Email is already used.");
    }
    c.Add(w);
    return TypedResults.Ok();
  }
})
.WithName("AddWriter")
.WithOpenApi();

app.Run();

