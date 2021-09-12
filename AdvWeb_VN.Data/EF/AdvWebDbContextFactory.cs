using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdvWeb_VN.Data.EF
{
	public class AdvWebDbContextFactory : IDesignTimeDbContextFactory<AdvWebDbContext>
	{
		//Thiết lập kết nối đến Database
		public AdvWebDbContext CreateDbContext(string[] args)
		{
			IConfigurationRoot configuration = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("Appsettings.json").Build();

			var conn = configuration.GetConnectionString("SciADV_Db");
			var optionsBuilder = new DbContextOptionsBuilder<AdvWebDbContext>();
			optionsBuilder.UseSqlServer(conn);

			return new AdvWebDbContext(optionsBuilder.Options);
		}
	}
}
