using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace SchoolClasses.Infrastructure.DataBase
{
    public class DatabaseProvider : IDatabaseProvider
    {
		private readonly IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.Development.json").Build();

		public string GetConnectionString()
        {
            return config["Constants:ConnectionString"];
        }
    }
}
