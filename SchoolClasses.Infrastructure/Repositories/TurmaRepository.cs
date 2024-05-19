using SchoolClasses.Core.Interfaces.Repositories;
using SchoolClasses.Infrastructure.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolClasses.Infrastructure.Repositories
{
    public class TurmaRepository : ITurmaRepository
    {
        IDatabaseProvider _provider;
        public TurmaRepository(IDatabaseProvider provider)
        {
            _provider = provider;
        }
    }
}
