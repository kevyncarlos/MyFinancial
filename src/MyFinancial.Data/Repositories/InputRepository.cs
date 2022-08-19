using MyFinancial.Data.Entities;
using MyFinancial.Data.Repositories.Interfaces;

namespace MyFinancial.Data.Repositories
{
    public class InputRepository : RepositoryBase<Input>, IInputRepository
    {
        public InputRepository(MyFinancialDbContext context) : base(context)
        {
        }
    }
}
