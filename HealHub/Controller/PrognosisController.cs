using HealHub.CrossCutting.Helpers;
using HealHub.Domain.Entities;
using HealHub.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HealHub.Controller
{
    [Route("api/prognosis")]
    [ApiController]
    public class PrognosisController : ControllerBase
    {
        private readonly IPrognosisService _service;

        public PrognosisController(IPrognosisService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public Result<Prognosis> getPrognosisById([FromRoute]int id) 
        {
            return _service.getPrognosis(id);
        }

        [HttpPost("create/{formId}")]
        public Result<Prognosis> createPrognosis([FromRoute]int formId)
        {
            return _service.createPrognosis(formId);
        }

        [HttpDelete("delete/{id}")]
        public Result<bool> deletePrognosis([FromRoute]int id)
        {
            return _service.deletePrognosis(id);
        }
    }
}
