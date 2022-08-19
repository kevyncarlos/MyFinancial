using Microsoft.Extensions.Logging;
using MyFinancial.Core.Services.Interfaces;
using MyFinancial.Data.Entities;
using MyFinancial.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinancial.Core.Services
{
    public class OutputService : IOutputService
    {
        private readonly ILogger<OutputService> _logger;
        private readonly IOutputRepository _outputRepository;

        public OutputService(ILogger<OutputService> logger, IOutputRepository outputRepository)
        {
            _logger = logger;
            _outputRepository = outputRepository;
        }

        public bool ChangeWasPaid(int id)
        {
            _logger.LogInformation($"{nameof(OutputService)} -> {nameof(ChangeWasPaid)} - {nameof(id)}: {id}");

            var input = _outputRepository.GetById(id);

            if(input != null)
            {
                input.WasPaid = !input.WasPaid;

                _outputRepository.AddOrUpdate(input);
                _outputRepository.SaveChanges();

                return true;
            }

            return false;
        }

        public bool Delete(int id)
        {
            _logger.LogInformation($"{nameof(OutputService)} -> {nameof(Delete)} - {nameof(id)}: {id}");

            var result = _outputRepository.Delete(id);
            _outputRepository.SaveChanges();

            return result;
        }

        public ICollection<Output> GetAll()
        {
            _logger.LogInformation($"{nameof(OutputService)} -> {nameof(GetAll)}");

            return _outputRepository.GetAll().ToList();
        }

        public ICollection<Output> GetAllWithIncludes()
        {
            _logger.LogInformation($"{nameof(OutputService)} -> {nameof(GetAllWithIncludes)}");

            return _outputRepository.GetAll(new[] { "Competence" }).ToList();
        }

        public Output? GetById(int id)
        {
            _logger.LogInformation($"{nameof(OutputService)} -> {nameof(GetById)} - {nameof(id)}: {id}");

            return _outputRepository.GetById(id);
        }

        public Output? Save(Output output)
        {
            _logger.LogInformation($"{nameof(OutputService)} -> {nameof(Save)} - {nameof(output)}: {output}");

            try
            {
                _outputRepository.AddOrUpdate(output);
                _outputRepository.SaveChanges();

                return output;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                return null;
            }
        }
    }
}
