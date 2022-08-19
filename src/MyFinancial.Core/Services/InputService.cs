using Microsoft.Extensions.Logging;
using MyFinancial.Core.Services.Interfaces;
using MyFinancial.Data.Entities;
using MyFinancial.Data.Repositories.Interfaces;

namespace MyFinancial.Core.Services
{
    public class InputService : IInputService
    {
        private readonly ILogger<InputService> _logger;
        private readonly IInputRepository _inputRepository;

        public InputService(ILogger<InputService> logger, IInputRepository inputRepository)
        {
            _logger = logger;
            _inputRepository = inputRepository;
        }

        public bool ChangeWasPaid(int id)
        {
            _logger.LogInformation($"{nameof(InputService)} -> {nameof(ChangeWasPaid)} - {nameof(id)}: {id}");

            var input = _inputRepository.GetById(id);

            if(input != null)
            {
                input.WasPaid = !input.WasPaid;

                _inputRepository.AddOrUpdate(input);
                _inputRepository.SaveChanges();

                return true;
            }

            return false;
        }

        public bool Delete(int id)
        {
            _logger.LogInformation($"{nameof(InputService)} -> {nameof(Delete)} - {nameof(id)}: {id}");

            var result = _inputRepository.Delete(id);
            _inputRepository.SaveChanges();

            return result;
        }

        public ICollection<Input> GetAll()
        {
            _logger.LogInformation($"{nameof(InputService)} -> {nameof(GetAll)}");

            return _inputRepository.GetAll().ToList();
        }

        public ICollection<Input> GetAllWithIncludes()
        {
            _logger.LogInformation($"{nameof(InputService)} -> {nameof(GetAllWithIncludes)}");

            return _inputRepository.GetAll(new[] { "Competence" }).ToList();
        }

        public Input? GetById(int id)
        {
            _logger.LogInformation($"{nameof(InputService)} -> {nameof(GetById)} - {nameof(id)}: {id}");

            return _inputRepository.GetById(id);
        }

        public Input? Save(Input input)
        {
            _logger.LogInformation($"{nameof(InputService)} -> {nameof(Save)} - {nameof(input)}: {input}");

            try
            {
                _inputRepository.AddOrUpdate(input);
                _inputRepository.SaveChanges();

                return input;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                return null;
            }
        }
    }
}
