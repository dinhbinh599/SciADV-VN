using System.Collections.Generic;
using System.Configuration;
using AdvWeb_VN.Application.Catalog.Categories;
using AdvWeb_VN.Application.Catalog.Comments;
using AdvWeb_VN.Application.Catalog.Posts;
using AdvWeb_VN.Application.Catalog.ProductImages;
using AdvWeb_VN.Application.Catalog.SubCategories;
using AdvWeb_VN.Application.Catalog.Tags;
using AdvWeb_VN.Application.Common;
using AdvWeb_VN.Application.System.Roles;
using AdvWeb_VN.Application.System.Users;
using AdvWeb_VN.Data.EF;
using AdvWeb_VN.Data.Entities;
using AdvWeb_VN.Utilities.Constants;
using AdvWeb_VN.ViewModels.System.Users;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

const string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// ConfigureServices method in Startup

builder.Services.AddCors(options =>
{
	options.AddPolicy(name: MyAllowSpecificOrigins,
					  builder =>
					  {
						  builder
						  .AllowAnyOrigin()
						  .AllowAnyHeader()
						  .AllowAnyMethod();
					  });
});
builder.Services.AddDbContext<AdvWebDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString(SystemConstants.MainConnectionString) ?? string.Empty));
builder.Services.AddIdentity<User, Role>()
	.AddEntityFrameworkStores<AdvWebDbContext>()
	.AddDefaultTokenProviders();

/*builder.Services.AddAuthorization(options =>
{
	options.FallbackPolicy = new AuthorizationPolicyBuilder()
		.RequireAuthenticatedUser()
		.Build();
});*/

		// Authorization handlers.
builder.Services.AddTransient<IPostService, PostService>();
builder.Services.AddTransient<UserManager<User>, UserManager<User>>();
builder.Services.AddTransient<SignInManager<User>, SignInManager<User>>(); 
builder.Services.AddTransient<RoleManager<Role>, RoleManager<Role>>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IStorageService, FileStorageService>();
builder.Services.AddTransient<IRoleService, RoleService>();
builder.Services.AddTransient<ISubCategoryService, SubCategoryService>();
builder.Services.AddTransient<ICommentService, CommentService>();
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<ITagService, TagService>();
builder.Services.AddTransient<IProductImageService, ProductImageService>();
//builder.Services.AddTransient<IValidator<LoginRequest>, LoginRequestValidator>();
//builder.Services.AddTransient<IValidator<RegisterRequest>, RegisterRequestValidator>();
builder.Services.AddControllers();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();
builder.Services.AddSwaggerGen(c =>
{
	c.SwaggerDoc("v1", new OpenApiInfo { Title = "Swagger SciAdvWeb", Version = "v1" });
	c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
	{
		Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n
                   Enter 'Bearer' [space] and then your token in the text input below.
                   \r\n\r\nExample: 'Bearer 12345abcdef'",
		Name = "Authorization",
		In = ParameterLocation.Header,
		Type = SecuritySchemeType.ApiKey,
		Scheme = "Bearer"
	});
	c.AddSecurityRequirement(new OpenApiSecurityRequirement()
	  {
		{
		  new OpenApiSecurityScheme
		  {
			Reference = new OpenApiReference
			  {
				Type = ReferenceType.SecurityScheme,
				Id = "Bearer"
			  },
			  Scheme = "oauth2",
			  Name = "Bearer",
			  In = ParameterLocation.Header,
			},
			new List<string>()
		  }
		});
});
string issuer = builder.Configuration.GetValue<string>("Tokens:Issuer");
string signingKey = builder.Configuration.GetValue<string>("Tokens:Key");
byte[] signingKeyBytes = System.Text.Encoding.UTF8.GetBytes(signingKey);

builder.Services.AddAuthentication(opt =>
{
	opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
	options.RequireHttpsMetadata = false;
	options.SaveToken = true;
	options.TokenValidationParameters = new TokenValidationParameters()
	{
		ValidateIssuer = true,
		ValidIssuer = issuer,
		ValidateAudience = true,
		ValidAudience = issuer,
		ValidateLifetime = true,
		ValidateIssuerSigningKey = true,
		ClockSkew = System.TimeSpan.Zero,
		IssuerSigningKey = new SymmetricSecurityKey(signingKeyBytes)
	};
});

var app = builder.Build();

// Configure method in Startup

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

// Migrate database on startup
using (var scope = app.Services.CreateScope())
{
	await scope.ServiceProvider.GetRequiredService<AdvWebDbContext>().Database.MigrateAsync();
}

app.UseStaticFiles();

app.UseAuthentication();
app.UseRouting();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.UseSwagger();

if (!app.Environment.IsProduction())
{
	app.UseSwaggerUI(c =>
	{
		c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger SciAdvWeb V1");
	});
}

app.UseEndpoints(endpoints =>
{
	endpoints.MapControllerRoute(
		name: "default",
		pattern: "{controller=Home}/{action=Index}/{id?}");
});

await app.RunAsync();


