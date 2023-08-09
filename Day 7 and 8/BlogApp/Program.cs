using BlogApp.Data;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services
    .AddEntityFrameworkNpgsql()
    .AddDbContext<BlogDbContext>(
        opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultDbConnection"))
    );
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

// Configure JSON serialization options
var options = new JsonSerializerOptions
{
    ReferenceHandler = ReferenceHandler.Preserve
};

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting(); // Add this line for proper routing
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

app.Run();
