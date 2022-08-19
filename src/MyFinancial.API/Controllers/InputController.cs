using Microsoft.AspNetCore.Mvc;
using MyFinancial.Core.Services.Interfaces;
using MyFinancial.Data.Entities;

namespace MyFinancial.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InputController : ControllerBase
    {
        private readonly ILogger<InputController> _logger;
        private readonly IInputService _inputService;

        public InputController(ILogger<InputController> logger, IInputService inputService)
        {
            _logger = logger;
            _inputService = inputService;
        }

        [HttpGet]
        public IEnumerable<Input> Get()
        {
            _logger.LogInformation($"{nameof(InputController)} -> {nameof(Get)}");

            return _inputService.GetAllWithIncludes();
        }

        [HttpPost]
        public Input? Save(Input input)
        {
            _logger.LogInformation($"{nameof(InputController)} -> {nameof(Save)} - {nameof(input)}: {input}");

            return _inputService.Save(input);
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            _logger.LogInformation($"{nameof(InputController)} -> {nameof(Delete)} - {nameof(id)}: {id}");

            return _inputService.Delete(id);
        }

        [HttpPatch]
        public bool ChangeWasPaid(int id)
        {
            _logger.LogInformation($"{nameof(InputController)} -> {nameof(ChangeWasPaid)} - {nameof(id)}: {id}");

            return _inputService.ChangeWasPaid(id);
        }
    }
}