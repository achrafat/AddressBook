using AddressBook.INFRASTRUCTURE.Data;
using AddressBook.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddScoped<IContactRepository, ContactRepository>();



var app = builder.Build();

app.UseCors(policy => policy
    .AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod()
    .WithExposedHeaders("Content-Disposition")); // Include this line if needed.;
// Map endpoints.
app.Map("/api", app =>
{
    app.UseRouting();

    // Your endpoints and middleware go here...

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });
});
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();


app.UseAuthorization();

app.MapControllers();


app.Run();
