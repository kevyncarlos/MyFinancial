using MyFinancial.Data.Entities;
using MyFinancial.Data.Repositories.Interfaces;

namespace MyFinancial.Data.Repositories
{
    public class CompetenceRepository : RepositoryBase<Competence>, ICompetenceRepository
    {
        public CompetenceRepository(MyFinancialDbContext context) : base(context)
        {
        }
    }
}
