using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

//Configure Services?
builder.Services.AddControllersWithViews();

builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});

builder.Services.AddMvc();

//Giris yapmamis kisileri ayni sayfaya yonlendiriyor.
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(x=>
    {
        x.LoginPath = "/Login/Index";
    });

var app = builder.Build();


//Configure metodu

//CSS gibi kutuphanelerin calismasi icin yazilmasi sart
app.UseStaticFiles();

//Error Page Yapisi icin
app.UseStatusCodePagesWithReExecute("/ErrorPage/Error1/","?code={0}");

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

//app.MapGet("/", () => "Hello World!");

//Default endpoint semasi ({controller:Home}/{action:Index}/{id?}) 
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Blog}/{action=Index}/{id?}");
});

app.Run();
