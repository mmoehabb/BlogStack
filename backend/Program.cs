using Microsoft.EntityFrameworkCore;

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

var writerHandler = new WriterHandler(app);

app.MapPost("/register", writerHandler.Register).WithName("RegisterWriter").WithOpenApi();
app.MapPost("/auth", writerHandler.Auth).WithName("AuthenticateWriter").WithOpenApi();

app.Run();

