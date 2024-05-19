using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolClasses.Infrastructure.DataBase
{
    public interface IDatabaseProvider
    {
        string GetConnectionString();
    }
}
