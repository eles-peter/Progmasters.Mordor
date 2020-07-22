using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Progmasters.Mordor.Dtos.Horde;
using Progmasters.Mordor.Models;
using Progmasters.Mordor.ServicesAbstractions;

namespace Progmasters.Mordor.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HordeController : ControllerBase
    {
        private readonly IHordeService hordeService;
        private readonly ILogger<HordeController> logger;

        public HordeController(IHordeService hordeService, ILogger<HordeController> logger)
        {
            this.hordeService = hordeService;
            this.logger = logger;
        }
        [HttpGet]
        public ActionResult<IEnumerable<HordeDetails>> Get()
        {
            return Ok(hordeService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<HordeDetails> Get(int id)
        {
            return Ok(hordeService.GetHorde(id));
        }

        [HttpPost]
        public ActionResult<HordeDetails> Create([FromBody] HordeCreateItem hordeCreateItem)
        {
            HordeDetails createdHorde = hordeService.CreateHorde(hordeCreateItem);
            return Ok(createdHorde);
        }

        [HttpPut("{id}")]
        public ActionResult<HordeDetails> Update(int id, [FromBody] HordeCreateItem hordeCreateItem)
        {
            HordeDetails updatedHorde = hordeService.UpdateHorde(id, hordeCreateItem);
            if (updatedHorde != null)
            {
                return Ok(updatedHorde);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpDelete("{id}")]
        public ActionResult<IEnumerable<HordeDetails>> Delete(int id)
        {
            bool hordeIsDeleted = hordeService.DeleteHorde(id);
            if (hordeIsDeleted)
            {
                IEnumerable<HordeDetails> hordeList = hordeService.GetAll();
                return Ok(hordeList);                
            }
            else
            {
                return NotFound(id);
            }
        }
    }
}
