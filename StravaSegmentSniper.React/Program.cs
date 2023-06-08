using Authorization.Data.Data;
using Microsoft.EntityFrameworkCore;
using StravaSegmentSniper.Data;
using StravaSegmentSniper.React.Helpers;

//var builder = WebApplication.CreateBuilder(args);
var builder = WebAppBuilderConfig.ConfigureBuilder();



var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//var service = (IServiceScopeFactory)app.Services.GetService(typeof(IServiceScopeFactory));

//using (var db = service.CreateScope().ServiceProvider.GetService<AuthDbContext>())
//{
//    db.Database.Migrate();
//}

//using (var db = service.CreateScope().ServiceProvider.GetService<StravaSegmentSniperDbContext>())
//{
//    db.Database.Migrate();
//}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseIdentityServer();
app.UseAuthorization();

app.UseSwagger();

app.UseSwaggerUI();

app.MapControllers();
//app.MapControllerRoute(
//    name: "default",
//    pattern: "api/");

app.MapRazorPages();

app.MapFallbackToFile("index.html"); ;


app.Run();
