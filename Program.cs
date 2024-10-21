using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BloggingContext>(options =>
  options.UseNpgsql(builder.Configuration.GetConnectionString("BloggingContext")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<BloggingContext>();
    context.Database.EnsureCreated();
    // DbInitializer.Initialize(context);
}

app.MapGet("/add/writer", () =>
{
  using(var scope = app.Services.CreateScope()) 
  {
      var context = scope.ServiceProvider.GetRequiredService<BloggingContext>();
      context.Add<Models.Writer>(new Models.Writer{ 
          Username = "User1",
          Password = "123456",
          DisplayName = "Mahmoud",
          Email = "example@example.com",
      });
      context.SaveChanges();
  }
  return "Done.";
})
.WithName("AddWriter")
.WithOpenApi();

app.Run();

