using MyFinancial.Data.Entities;
using MyFinancial.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinancial.Data.Repositories
{
    public class OutputRepository : RepositoryBase<Output>, IOutputRepository
    {
        public OutputRepository(MyFinancialDbContext context) : base(context)
        {
        }
    }
}
