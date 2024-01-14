using System.Collections.Generic;
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
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace AdvWeb_VN.BackendApi
{
	public class Startup
	{
		readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddCors(options =>
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
			services.AddDbContext<AdvWebDbContext>(options =>
			options.UseSqlServer(Configuration.GetConnectionString(SystemConstants.MainConnectionString)));
			services.AddIdentity<User, Role>()
				.AddEntityFrameworkStores<AdvWebDbContext>()
				.AddDefaultTokenProviders();

			/*services.AddAuthorization(options =>
			{
				options.FallbackPolicy = new AuthorizationPolicyBuilder()
					.RequireAuthenticatedUser()
					.Build();
			});*/

			// Authorization handlers.
			services.AddTransient<IPostService, PostService>();
			services.AddTransient<UserManager<User>, UserManager<User>>();
			services.AddTransient<SignInManager<User>, SignInManager<User>>(); 
			services.AddTransient<RoleManager<Role>, RoleManager<Role>>();
			services.AddTransient<IUserService, UserService>();
			services.AddTransient<IStorageService, FileStorageService>();
			services.AddTransient<IRoleService, RoleService>();
			services.AddTransient<ISubCategoryService, SubCategoryService>();
			services.AddTransient<ICommentService, CommentService>();
			services.AddTransient<ICategoryService, CategoryService>();
			services.AddTransient<ITagService, TagService>();
			services.AddTransient<IProductImageService, ProductImageService>();

			//services.AddTransient<IValidator<LoginRequest>, LoginRequestValidator>();
			//services.AddTransient<IValidator<RegisterRequest>, RegisterRequestValidator>();

			services.AddControllers()
				.AddFluentValidation(fv=>fv.RegisterValidatorsFromAssemblyContaining<LoginRequestValidator>());

			services.AddSwaggerGen(c =>
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
			string issuer = Configuration.GetValue<string>("Tokens:Issuer");
			string signingKey = Configuration.GetValue<string>("Tokens:Key");
			byte[] signingKeyBytes = System.Text.Encoding.UTF8.GetBytes(signingKey);

			services.AddAuthentication(opt =>
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
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				//app.UseHsts();
			}

			// Migrate database on startup
			using (var scope = app.ApplicationServices.CreateScope())
			{
				scope.ServiceProvider.GetRequiredService<AdvWebDbContext>().Database.Migrate();
			}
			
			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseAuthentication();
			app.UseRouting();

			app.UseCors(MyAllowSpecificOrigins);

			app.UseAuthorization();

			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger SciAdvWeb V1");
			});
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
