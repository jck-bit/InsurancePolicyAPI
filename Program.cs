using InsurancePolicyAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// builder.Services.AddDbContext<PolicyContext>(options =>
//     options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<PolicyContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", policy =>
    {
        policy.AllowAnyOrigin()   
              .AllowAnyMethod()   
              .AllowAnyHeader();
    });
});

var app = builder.Build();


app.UseCors("AllowAllOrigins");

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
