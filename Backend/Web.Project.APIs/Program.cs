using System.Security.Claims;
using System.Text;
using FinalProject.Dal;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebApplications4.DAL;

var builder = WebApplication.CreateBuilder(args);
const string allowAllPolicy="AllowAllPolicy";

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Authentication

builder.Services.AddIdentity<User, IdentityRole>(
    options =>
    {
        options.Password.RequiredLength = 8;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireDigit = false;
        options.Password.RequireLowercase = false;
        options.Password.RequireUppercase = false;
    }
    )
    .AddEntityFrameworkStores<KhadamatiContext>();

builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = "XYZ";
        options.DefaultChallengeScheme = "XYZ";
    })
    .AddJwtBearer("XYZ", option =>
    {
        string secretKey = builder.Configuration.GetValue<string>("SecretKey")!;
        var keyinbytes = Encoding.ASCII.GetBytes(secretKey);
        var key = new SymmetricSecurityKey(keyinbytes);

        option.TokenValidationParameters = new TokenValidationParameters
        {
            IssuerSigningKey = key,
            ValidateIssuer = false,
            ValidateAudience = false
        };
    }
    );

#endregion Authentication

#region Authorization

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("UserPolicy",
        p => p.RequireClaim(ClaimTypes.Role, "User", "Admin"));
});

#endregion Authorization

#region Database
string? connection = builder.Configuration.GetConnectionString("C1");
builder.Services.AddDbContext<KhadamatiContext>(
    i => i.UseSqlServer(connection)
    );
#endregion



#region Repo
builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<IBookMarkRepo, BookMarkRepo>();
builder.Services.AddScoped<IRequestrepo, Requestrepo>();
builder.Services.AddScoped<INotificationRepo, NotificationRepo>();
builder.Services.AddScoped<IUnitofWork, UnitofWork>();
builder.Services.AddScoped<IServiceRepo,ServiceRepo>();
builder.Services.AddScoped<IPictureRepo,PictureRepo>();
builder.Services.AddScoped<ICategoryrepo, Catregoryrepo>();
builder.Services.AddScoped<IRatingRepo, RatingRepo>();
#endregion

#region Manager
builder.Services.AddScoped<IUserManger, UserManger>();
builder.Services.AddScoped<IRequestmanager, RequestManger>();
builder.Services.AddScoped<INotificationManager, NotificationManager>();
builder.Services.AddScoped<IServiceManager,ServiceManager>();
builder.Services.AddScoped<IPictureManager,PictureManager>();
builder.Services.AddScoped<ICategoryManger, CategoryManger>();
builder.Services.AddScoped<IRatingManager,RatingManager>();
#endregion

#region Cors
builder.Services.AddCors(options=>
{
  options.AddPolicy(allowAllPolicy,builder=>
  {
    builder.AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod();
  });
});
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(allowAllPolicy);

// step number 4
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
