using EFCore_MySql_Example.Storage.Context;
using EFCore_MySql_Example.WebApi;
using EFCore_MySql_Example.WebApi.Helpers;
using EFCore_MySql_Example.WebApi.Interfaces;
using EFCore_MySql_Example.WebApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder.WithOrigins("http://localhost:4200")
                          .AllowAnyHeader()
                            .AllowAnyMethod()
                        .AllowCredentials(); ;
                      });
});

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

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = TokenHelper.Issuer,
                ValidAudience = TokenHelper.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Convert.FromBase64String(TokenHelper.Secret))
            };

        });

builder.Services.AddAuthorization();



builder.Services.AddTransient<ITokenService, TokenService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<ITaskService, TaskService>();

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

app.UseStaticFiles();
app.UseRouting();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
