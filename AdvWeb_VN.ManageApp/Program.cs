using System;
using AdvWeb_VN.ManageApp.Services;
using AdvWeb_VN.Utilities.Settings;
using AdvWeb_VN.ViewModels.System.Users;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// ConfigureServices method in Startup
builder.Services.AddHttpClient("GeroSaga_BackEnd",
    client => client.BaseAddress = new Uri(builder.Configuration.GetSection("BaseAddress").Get<string>()));
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login";
        options.AccessDeniedPath = "/User/Forbidden/";
        options.ExpireTimeSpan = TimeSpan.FromDays(30); // Set cookie expiration time
        options.SlidingExpiration = true; // Extend expiration on activity
    });
builder.Services.AddControllersWithViews();

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();
			
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromDays(1);
});

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddTransient<IUserApiClient, UserApiClient>();
builder.Services.AddTransient<IRoleApiClient, RoleApiClient>();
builder.Services.AddTransient<ICategoryApiClient, CategoryApiClient>();
builder.Services.AddTransient<IPostApiClient, PostApiClient>();
builder.Services.AddTransient<ITagApiClient, TagApiClient>();
builder.Services.AddTransient<ISubCategoryApiClient, SubCategoryApiClient>(); 
builder.Services.AddTransient<ICommentApiClient, CommentApiClient>();
builder.Services.AddTransient<IProductImageApiClient, ProductImageApiClient>();

builder.Services.AddHttpContextAccessor();

IMvcBuilder razorBuilder = builder.Services.AddRazorPages();
var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
		
if (environment == Environments.Development)
{
    razorBuilder.AddRazorRuntimeCompilation();
}

var app = builder.Build();

DomainAddressHelper.ConfigureDomainAddresses(app.Configuration);

// Configure method in Startup
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    //app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();
app.UseRouting();

app.UseAuthorization();
app.UseSession();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

await app.RunAsync();