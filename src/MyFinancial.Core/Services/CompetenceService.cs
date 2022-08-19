using Microsoft.Extensions.Logging;
using MyFinancial.Core.Services.Interfaces;
using MyFinancial.Data.Entities;
using MyFinancial.Data.Repositories.Interfaces;

namespace MyFinancial.Core.Services
{
    public class CompetenceService : ICompetenceService
    {
        private readonly ILogger<CompetenceService> _logger;
        private readonly ICompetenceRepository _competenceRepository;

        public CompetenceService(ILogger<CompetenceService> logger, ICompetenceRepository competenceRepository)
        {
            _logger = logger;
            _competenceRepository = competenceRepository;
        }

        public ICollection<Competence> GetAll()
        {
            _logger.LogInformation($"{nameof(CompetenceService)} -> {nameof(GetAll)}");

            return _competenceRepository.GetAll().ToList();
        }

        public ICollection<Competence> GetAllWithIncludes()
        {
            _logger.LogInformation($"{nameof(CompetenceService)} -> {nameof(GetAllWithIncludes)}");

            return _competenceRepository.GetAll(new[] { "Inputs", "Outputs" }).ToList();
        }

        public Competence? GetById(int id)
        {
            _logger.LogInformation($"{nameof(CompetenceService)} -> {nameof(GetById)} - {nameof(id)}: {id}");

            return _competenceRepository.GetById(id);
        }

        public Competence? Save(Competence competence)
        {
            _logger.LogInformation($"{nameof(CompetenceService)} -> {nameof(Save)} - {nameof(competence)}: {competence}");

            try
            {
                _competenceRepository.AddOrUpdate(competence);
                _competenceRepository.SaveChanges();

                return competence;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                return null;
            }
        }

        public bool Delete(int id)
        {
            _logger.LogInformation($"{nameof(CompetenceService)} -> {nameof(Delete)} - {nameof(id)}: {id}");

            var result = _competenceRepository.Delete(id);
            _competenceRepository.SaveChanges();

            return result;
        }
    }
}
