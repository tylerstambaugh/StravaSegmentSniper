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
//    pattern: "api/{controller}");

//app.UseRouting();

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllers();
//    //endpoints.MapControllerRoute(
//    //  name: "Admin",
//    //  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
//    endpoints.MapControllerRoute(
//      name: "default",
//      pattern: "{controller}/{action}/{id?}");
//    endpoints.MapRazorPages();
//});


//Use Rick.Docs.Samples to gather route information
//var routeInfo = new RouteInfo(endpoints);
//var routes = routeInfo.GetRoutes();

app.MapRazorPages();

app.MapFallbackToFile("index.html"); ;


app.Run();
