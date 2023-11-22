using HealHub.CrossCutting.Helpers;
using HealHub.Domain.Entities;
using HealHub.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HealHub.Controller
{
    [Route("api/form")]
    [ApiController]
    public class FormController : ControllerBase
    {
        private readonly IFormService _service;

        public FormController(IFormService service)
        {
            _service = service;
        }

        [HttpGet]
        public Result<List<Form>> getAllForms()
        {
            return _service.getAllForms();
        }

        [HttpPost]
        public Result<Form> createForm(Form form)
        {
            return _service.createForm(form);
        }

        [HttpPut("/update/{id}")]
        public Result<Form> updateForm([FromRoute]int id, Form form)
        {
            return _service.updateForm(id, form);
        }

        [HttpDelete("/delete/{id}")]
        public Result<bool> deleteForm([FromRoute]int id)
        {
            return _service.deleteForm(id);
        }

    }
}
