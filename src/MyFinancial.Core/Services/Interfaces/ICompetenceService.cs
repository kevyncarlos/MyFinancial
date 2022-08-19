using MyFinancial.Data.Entities;

namespace MyFinancial.Core.Services.Interfaces
{
    public interface ICompetenceService
    {
        public ICollection<Competence> GetAll();
        public ICollection<Competence> GetAllWithIncludes();
        public Competence? GetById(int id);
        public Competence? Save(Competence competence);
        public bool Delete(int id);
    }
}
