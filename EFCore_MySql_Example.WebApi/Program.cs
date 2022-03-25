using EFCore_MySql_Example.Storage.Context;
using EFCore_MySql_Example.WebApi;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


if (builder.Environment.IsDevelopment())
{
    var connectionStringId = "LocalTestDb";
    var connectionString = builder.Configuration.GetConnectionString(connectionStringId);

    /*in order for this to work it is neccessary to first create db*/
    var serverVersion =  new MySqlServerVersion(new Version(8, 0, 28));
    //MySqlServerVersion.AutoDetect(connectionString);
   // builder.Services.AddDbContext<StorageContext>(options => options.UseMySql(connectionString, serverVersion, options => options.EnableRetryOnFailure())) ;

     builder.Services.AddDbContext<StorageContext>(options => options.UseMySql(connectionString, serverVersion,
     options => options.MigrationsAssembly(Constants.cStorageDatabaseMySqlAssemblyName)));
}

var app = builder.Build();

using (var serviceScope = app.Services.CreateScope())
{
    var provider = serviceScope.ServiceProvider;

    var storageContext = provider.GetRequiredService<StorageContext>();
    //storageContext.Database.EnsureCreated();
    storageContext.Database.Migrate();
}

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
