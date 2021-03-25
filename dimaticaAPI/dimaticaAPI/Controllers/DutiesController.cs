using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dimaticaAPI.Models;
using dimaticaAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace dimaticaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DutiesController : ControllerBase
    {

        private readonly DutyService _dutyService;

        public DutiesController(DutyService dutyService)
        {
            _dutyService = dutyService;
        }

        [HttpGet]
        public ActionResult<List<Duty>> Get() => _dutyService.Get();

        [HttpGet("{id:length(24)}", Name = "GetDuty")]
        public ActionResult<Duty> Get(string id)
        {
            var duty = _dutyService.Get(id);

            if (duty == null)
            {
                return NotFound();
            }

            return duty;
        }

        [HttpPost]
        public ActionResult<Duty> Create(Duty duty)
        {

                _dutyService.Create(duty);
                return CreatedAtRoute("GetDuty", new { id = duty.Id.ToString() }, duty);
                      
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Duty newDuty)
        {
            var duty = _dutyService.Get(id);

            if (duty == null)
            {
                return NotFound();
            }

            _dutyService.Update(id, newDuty);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var duty = _dutyService.Get(id);

            if (duty == null)
            {
                return NotFound();
            }

            _dutyService.Remove(duty.Id);

            return NoContent();
        }

    }
}
