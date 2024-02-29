using FAIT.Application.Abstraction;
using FAIT.Application.Implementations;
using FAIT.Domain.User;
using FAIT.Infrastructure;
using FAIT.Persistence.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<IFileServices, PhysicalFileServices>();
builder.Services.AddDbContext<ApplicationDbContext>(op => op.UseSqlServer(builder.Configuration["ConnectionStrings:Default"]));
builder.Services.AddIdentityCore<AppUser>().AddRoles<IdentityRole<Guid>>().AddEntityFrameworkStores<ApplicationDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();
app.Run();

