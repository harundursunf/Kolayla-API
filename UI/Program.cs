using Business.Abstract;
using Business.Concrete;
using Businness.Abstract;
using Businness.Concrete;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Context;
using DataAccess.Ef;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// DbContext
builder.Services.AddDbContext<StudyFlowApiDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("StudyFlow")));

// JWT Authentication Configuration
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = "StudyFlowAPI", // Token oluþtururken kullanýlan issuer
            ValidateAudience = true,
            ValidAudience = "StudyFlowClient", // Token oluþtururken kullanýlan audience
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("seninSecretKey")) // Secret key
        };
    });

// CORS Configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Dependency Injection
builder.Services.AddScoped<ICompletedTopicService, CompletedTopicManager>();
builder.Services.AddScoped<ICompletedTopicDal, EfCompletedTopicDal>();
builder.Services.AddScoped<ITopicService, TopicManager>();
builder.Services.AddScoped<ITopicDal, EfTopicDal>();
builder.Services.AddScoped<IUserService, UserManager>();
builder.Services.AddScoped<IUserDal, EfUserDal>();
builder.Services.AddScoped<IAuthService, AuthManager>();
builder.Services.AddScoped<ITokenHandler, Core.Utilities.Security.JWT.TokenHandler>();
builder.Services.AddScoped<IDailyGoalDal, EfDailyGoalDal>();
builder.Services.AddScoped<IDailyGoalService, DailyGoalManager>();
builder.Services.AddScoped<IFactService, FactManager>();
builder.Services.AddScoped<IFactDal, EfFactDal>();
builder.Services.AddScoped<IFavoriteFactService, FavoriteFactManager>();
builder.Services.AddScoped<IFavoriteFactDal, EfFavoriteFactDal>();
builder.Services.AddScoped<IFavoriteQuoteService, FavoriteQuoteManager>();
builder.Services.AddScoped<IFavoriteQuoteDal, EfFavoriteQuoteDal>();
builder.Services.AddScoped<INetEntryService, NetEntryManager>();
builder.Services.AddScoped<INetEntryDal, EfNetEntryDal>();
builder.Services.AddScoped<IStudyRecordService, StudyRecordManager>();
builder.Services.AddScoped<IStudyRecordDal, EfStudyRecordDal>();
builder.Services.AddScoped<IQuoteService, QuoteManager>();
builder.Services.AddScoped<IQuoteDal, EfQuoteDal>();
builder.Services.AddScoped<INoteService, NoteManager>();
builder.Services.AddScoped<INoteDal, EfNoteDal>();

// Controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "StudyFlow API", Version = "v1" });
});

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "StudyFlow API v1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

// CORS middleware
app.UseCors("AllowAll");

// Authentication and Authorization Middleware
app.UseAuthentication();  // JWT Authentication
app.UseAuthorization();   // Authorization

app.MapControllers();

app.Run();
