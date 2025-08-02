using Microsoft.EntityFrameworkCore;
using UserManagement.Application.UseCases.CreateUser;
using UserManagement.Application.UseCases.DeleteUser;
using UserManagement.Application.UseCases.GetIsers;
using UserManagement.Application.UseCases.GetUser;
using UserManagement.Application.UseCases.GetUserEmail;
using UserManagement.Application.UseCases.UpdateUser;
using UserManagement.Domain.Repositories;
using UserManagement.Infrastructure.Data;
using UserManagement.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Database
builder.Services.AddDbContext<UserManagementDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();

// Handlers
builder.Services.AddScoped<CreateUserHandler>();
builder.Services.AddScoped<GetUserHandler>();
builder.Services.AddScoped<UpdateUserHandler>();
builder.Services.AddScoped<DeleteUserHandler>();
builder.Services.AddScoped<GetUsersHandle>();
builder.Services.AddScoped<GetUserEmailHandler>();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
