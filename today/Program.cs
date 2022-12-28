using Microsoft.EntityFrameworkCore;
using today.Data;
using today.Repositories;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<DbCustomercontext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Shekel")));

builder.Services.AddScoped<ICustomerService, CustomerService>();

builder.Services.AddDbContext<DbGroupContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Shekel")));

builder.Services.AddScoped<IGroupService, GroupService>();

builder.Services.AddDbContext<DbFactoryContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Shekel")));

builder.Services.AddScoped<IFactoryService, FactoryService>();

builder.Services.AddDbContext<DbFactoriesToCustomerContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Shekel")));

builder.Services.AddScoped<IFactoriesToCustomerService, FactoriesToCustomerService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
