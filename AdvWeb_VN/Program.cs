using System;
using System.Linq;
using AdvWeb_VN.Application.Common;
using AdvWeb_VN.Utilities.Dtos;
using AdvWeb_VN.Utilities.Settings;
using AdvWeb_VN.ViewModels.Common;
using AdvWeb_VN.WebApp.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// ConfigureServices method in Startup

builder.Services.AddHttpClient("backendapi", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["BaseAddress"]!);
});
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddTransient<IUserApiClient, UserApiClient>();
builder.Services.AddTransient<IRoleApiClient, RoleApiClient>();
builder.Services.AddTransient<ICategoryApiClient, CategoryApiClient>();
builder.Services.AddTransient<IPostApiClient, PostApiClient>();
builder.Services.AddTransient<ITagApiClient, TagApiClient>();
builder.Services.AddTransient<ISubCategoryApiClient, SubCategoryApiClient>();
builder.Services.AddTransient<ICommentApiClient, CommentApiClient>();

IMvcBuilder razorBuilder = builder.Services.AddRazorPages();
var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

if (environment == Environments.Development)
{
    razorBuilder.AddRazorRuntimeCompilation();
}

var app = builder.Build();

// Configure method in Startup

// Cập nhật danh sách người donate
GeneralInformation.Donors = app.Configuration.GetValue<string>("Donors")!
    .Split(",").ToList();

DomainAddressHelper.ConfigureDomainAddresses(app.Configuration);
			
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHttpsRedirection();
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    //app.UseHsts();
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

await app.RunAsync();