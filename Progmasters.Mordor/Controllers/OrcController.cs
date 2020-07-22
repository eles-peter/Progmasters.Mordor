using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Progmasters.Mordor.Dtos.Orc;
using Progmasters.Mordor.ServicesAbstractions;

namespace Progmasters.Mordor.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrcController : ControllerBase
    {
        private readonly IOrcService orcService;
        private readonly ILogger<OrcController> logger;

        public OrcController(IOrcService orcService, ILogger<OrcController> logger)
        {
            this.orcService = orcService;
            this.logger = logger;
        }

        [HttpGet("formData")]
        public ActionResult<OrcFormData> GetOrcFornData()
        {
            return Ok(orcService.GetOrcFormData());
        }

        [HttpGet]
        public ActionResult<IEnumerable<OrcDetails>> Get()
        {
            return Ok(orcService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<OrcDetails> Get(int id)
        {
            return Ok(orcService.GetOrc(id));
        }

        [HttpPost]
        public ActionResult Create([FromBody] OrcCreateItem orcCreateItem)
        {
            orcService.CreateOrc(orcCreateItem);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult<OrcDetails> Update(int id, [FromBody] OrcCreateItem orcCreateItem)
        {
            OrcDetails updatedOrc = orcService.UpdateOrc(id, orcCreateItem);
            if (updatedOrc != null) 
            {
                return Ok(updatedOrc);
            } 
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")] 
        public ActionResult<IEnumerable<OrcDetails>> Delete(int id)
        {
            bool orcIsDeleted = orcService.DeleteOrc(id);
            if (orcIsDeleted)
            {
                IEnumerable<OrcDetails> orcList = orcService.GetAll();
                return Ok(orcList);
            }
            else
            {
                return NotFound(id);
            }
        }
    }
}
