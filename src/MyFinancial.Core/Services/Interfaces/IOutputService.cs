using MyFinancial.Data.Entities;

namespace MyFinancial.Core.Services.Interfaces
{
    public interface IOutputService
    {
        public ICollection<Output> GetAll();
        public ICollection<Output> GetAllWithIncludes();
        public Output? GetById(int id);
        public Output? Save(Output input);
        public bool ChangeWasPaid (int id);
        public bool Delete(int id);
    }
}
