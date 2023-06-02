using Authorization.Data.Data;
using Authorization.Data.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using StravaSegmentSniper.Data;
using StravaSegmentSniper.React.ActionHandlers;
using StravaSegmentSniper.Services.Internal.Adapters;
using StravaSegmentSniper.Services.Internal.Services;
using StravaSegmentSniper.Services.StravaAPI.Activity;
using StravaSegmentSniper.Services.StravaAPI.Athlete;
using StravaSegmentSniper.Services.StravaAPI.Segment;
using StravaSegmentSniper.Services.StravaAPI.TokenService;

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

            builder.Services.AddDefaultIdentity<WebAppUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<AuthDbContext>();

            builder.Services.AddIdentityServer()
                .AddApiAuthorization<WebAppUser, AuthDbContext>();

            builder.Services.AddAuthentication()
                .AddIdentityServerJwt();

            var appDataConnectionString = builder.Configuration.GetConnectionString("StravaSegmentSniperData");
            builder.Services.AddDbContext<StravaSegmentSniperDbContext>(options =>
                options.UseSqlServer(appDataConnectionString).UseLazyLoadingProxies());

            builder.Services.AddControllersWithViews();

            builder.Services.AddRazorPages();

            builder.Services.AddControllers().AddNewtonsoftJson();

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

            //add automapper
            builder.Services.AddAutoMapper(typeof(Program));

            //builder.Services.AddScoped<IStravaSegmentSniperDbContext>(provider => provider.GetService<StravaSegmentSniperDbContext>());

            //add DI services to the container
            builder.Services.AddScoped<IAthleteActivityService, AthleteActivityService>();
            builder.Services.AddScoped<IAthleteService, AthleteService>();
            builder.Services.AddScoped<IStravaToken, StravaTokenService>();
            builder.Services.AddScoped<IWebAppUserService, WebAppUserService>();
            builder.Services.AddScoped<IStravaAPIAthlete, StravaAPIAthlete>();
            builder.Services.AddScoped<IStravaAPIActivity, StravaAPIActivity>();
            builder.Services.AddScoped<IStravaAPISegment, StravaAPISegment>();
            builder.Services.AddScoped<IStravaAPIToken, StravaAPIToken>();
            builder.Services.AddScoped<IActivityAdapter, ActivityAdapter>();
            builder.Services.AddScoped<IStravaActivityActionHandler, StravaActivityActionHandler>();


            //register types for local EF data



            return builder;
        }



    }
}
