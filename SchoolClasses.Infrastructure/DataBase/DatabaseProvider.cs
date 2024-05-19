using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolClasses.Infrastructure.DataBase
{
    public class DatabaseProvider : IDatabaseProvider
    {
        public string GetConnectionString()
        {
            return "Data Source=154.38.177.250\\SQLEXPRESS;Initial Catalog=SchoolClasses;Persist Security Info=True;User ID=infortronics;Password=Server2024; TrustServerCertificate=True;";
        }
    }
}
