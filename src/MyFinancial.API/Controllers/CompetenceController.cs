using Microsoft.AspNetCore.Mvc;
using MyFinancial.Core.Services.Interfaces;
using MyFinancial.Data.Entities;

namespace MyFinancial.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompetenceController : ControllerBase
    {
        private readonly ILogger<CompetenceController> _logger;
        private readonly ICompetenceService _competenceService;

        public CompetenceController(ILogger<CompetenceController> logger, ICompetenceService competenceService)
        {
            _logger = logger;
            _competenceService = competenceService;
        }

        [HttpGet]
        public IEnumerable<Competence> Get()
        {
            _logger.LogInformation($"{nameof(CompetenceController)} -> {nameof(Get)}");

            return _competenceService.GetAllWithIncludes();
        }

        [HttpPost]
        public Competence? Save(Competence competence)
        {
            _logger.LogInformation($"{nameof(CompetenceController)} -> {nameof(Save)} - {nameof(competence)}: {competence}");

            return _competenceService.Save(competence);
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            _logger.LogInformation($"{nameof(CompetenceController)} -> {nameof(Delete)} - {nameof(id)}: {id}");

            return _competenceService.Delete(id);
        }
    }
}