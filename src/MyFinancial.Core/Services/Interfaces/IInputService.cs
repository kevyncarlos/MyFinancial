using MyFinancial.Data.Entities;

namespace MyFinancial.Core.Services.Interfaces
{
    public interface IInputService
    {
        public ICollection<Input> GetAll();
        public ICollection<Input> GetAllWithIncludes();
        public Input? GetById(int id);
        public Input? Save(Input input);
        public bool ChangeWasPaid (int id);
        public bool Delete(int id);
    }
}
