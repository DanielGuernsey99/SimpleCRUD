using Microsoft.EntityFrameworkCore;
using SimpleCRUD.BL.Services.Interfaces;
using SimpleCRUD.BL.Services;
using SimpleCRUD.Data.DataContext;

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddDbContext<SimpleCrudDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

    builder.Services.AddScoped<IApplicationRoleService, ApplicationRoleService>();
    builder.Services.AddScoped<IApplicationService, ApplicationService>();
    builder.Services.AddScoped<IApplicationUserRoleService, ApplicationUserRoleService>();
    builder.Services.AddScoped<IApplicationUserService, ApplicationUserService>();
    builder.Services.AddScoped<IUserRoleService, UserRoleService>();
    builder.Services.AddScoped<IUserService, UserService>();

    var app = builder.Build();

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
}
catch(Exception ex)
{
    Console.WriteLine(ex);
}
