using Authorization.Data.Data;
using Authorization.Data.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using StravaSegmentSniper.Data;
using StravaSegmentSniper.React.ActionHandlers.Activity;
using StravaSegmentSniper.React.ActionHandlers.Segment;
using StravaSegmentSniper.React.ActionHandlers.StravaApiToken;
using StravaSegmentSniper.Services.Internal.Adapters;
using StravaSegmentSniper.Services.Internal.Services;
using StravaSegmentSniper.Services.StravaAPI.Activity;
using StravaSegmentSniper.Services.StravaAPI.Athlete;
using StravaSegmentSniper.Services.StravaAPI.Segment;
using StravaSegmentSniper.Services.StravaAPI.TokenService;
using System.Text;

namespace StravaSegmentSniper.React.Helpers
{
    public class WebAppBuilderConfig
    {
        public static WebApplicationBuilder ConfigureBuilder()
        {
            var builder = WebApplication.CreateBuilder();


            var authConnectionString = builder.Configuration.GetConnectionString("AuthorizationData");
            builder.Services.AddDbContext<AuthDbContext>(options =>
                options.UseSqlServer(authConnectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            var appDataConnectionString = builder.Configuration.GetConnectionString("StravaSegmentSniperData");
            builder.Services.AddDbContext<StravaSegmentSniperDbContext>(options =>
                options.UseSqlServer(appDataConnectionString).UseLazyLoadingProxies());

            builder.Services.AddDefaultIdentity<WebAppUser>(options => options.SignIn.RequireConfirmedAccount = true)
                 .AddRoles<IdentityRole>()
                 .AddEntityFrameworkStores<AuthDbContext>();

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireAdministratorRole",
                     policy => policy.RequireRole("Administrator"));
            });

            builder.Services.AddIdentityServer()
                .AddApiAuthorization<WebAppUser, AuthDbContext>();

            builder.Services.AddAuthentication("Bearer")
                .AddIdentityServerJwt().AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = builder.Configuration["Jwt:Issuer"],
                        ValidAudience = builder.Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                    };
                });

            //may want to take this out in production...
            builder.Services.AddDirectoryBrowser();

            builder.Services.AddControllers().AddNewtonsoftJson();
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            //builder.Services.AddRouting(ctx => ctx.LowercaseUrls = false);

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "JWTToken_Auth_API",
                    Version = "v1"
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
            });

            builder.Services.AddAutoMapper(typeof(Program));

            //builder.Services.AddScoped<IStravaSegmentSniperDbContext>(provider => provider.GetService<StravaSegmentSniperDbContext>());

            //add DI services to the container
            builder.Services.AddScoped<IAthleteActivityService, AthleteActivityService>();
            builder.Services.AddScoped<IAthleteService, AthleteService>();
            builder.Services.AddScoped<IStravaTokenService, StravaTokenService>();
            builder.Services.AddScoped<IWebAppUserService, WebAppUserService>();
            builder.Services.AddScoped<IStravaAPIAthlete, StravaAPIAthlete>();
            builder.Services.AddScoped<IStravaApiActivity, StravaApiActivity>();
            builder.Services.AddScoped<IStravaApiSegment, StravaApiSegment>();
            builder.Services.AddScoped<IStravaApiToken, StravaApiToken>();
            builder.Services.AddScoped<IActivityAdapter, ActivityAdapter>();
            builder.Services.AddScoped<ISegmentAdapter, SegmentAdapter>();
            builder.Services.AddScoped<IStravaActivityActionHandler, StravaActivityActionHandler>();
            builder.Services.AddScoped<IStravaApiTokenActionHandler, StravaApiTokenActionHandler>();
            builder.Services.AddScoped<ISnipeSegmentActionHandler, SnipeSegmentActionHandler>();
            builder.Services.AddScoped<IStarSegmentActionHandler, StarSegmentActionHandler>();
            builder.Services.AddScoped<IExchangeAuthCodeForTokenHandler, ExchangeAuthCodeForTokenHandler>();

            return builder;
        }



    }
}
