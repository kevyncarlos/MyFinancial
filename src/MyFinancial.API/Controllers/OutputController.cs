using Microsoft.AspNetCore.Mvc;
using MyFinancial.Core.Services.Interfaces;
using MyFinancial.Data.Entities;

namespace MyFinancial.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OutputController : ControllerBase
    {
        private readonly ILogger<OutputController> _logger;
        private readonly IOutputService _outputService;

        public OutputController(ILogger<OutputController> logger, IOutputService outputService)
        {
            _logger = logger;
            _outputService = outputService;
        }

        [HttpGet]
        public IEnumerable<Output> Get()
        {
            _logger.LogInformation($"{nameof(OutputController)} -> {nameof(Get)}");

            return _outputService.GetAllWithIncludes();
        }

        [HttpPost]
        public Output? Save(Output output)
        {
            _logger.LogInformation($"{nameof(OutputController)} -> {nameof(Save)} - {nameof(output)}: {output}");

            return _outputService.Save(output);
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            _logger.LogInformation($"{nameof(OutputController)} -> {nameof(Delete)} - {nameof(id)}: {id}");

            return _outputService.Delete(id);
        }

        [HttpPatch]
        public bool ChangeWasPaid(int id)
        {
            _logger.LogInformation($"{nameof(OutputController)} -> {nameof(ChangeWasPaid)} - {nameof(id)}: {id}");

            return _outputService.ChangeWasPaid(id);
        }
    }
}