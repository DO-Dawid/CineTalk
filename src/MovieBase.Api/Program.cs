using MovieBase.Api.Data;
using MovieBase.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MovieBaseContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

SearchMoviesEndpoint.Map(app);
ShowReviewsEndpoint.Map(app);
AddReviewEndpoint.Map(app);
DeleteReviewEndpoint.Map(app);

using (var scope = app.Services.CreateScope())
{
    var ctx = scope.ServiceProvider.GetRequiredService<MovieBaseContext>();
    ctx.Database.EnsureDeleted();
    ctx.Database.EnsureCreated();
}

app.Run();