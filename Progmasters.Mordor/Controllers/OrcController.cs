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
            return Ok(orcService.getOrcFormData());
        }

        [HttpGet]
        public ActionResult<IEnumerable<OrcDetail>> Get()
        {
            IEnumerable<OrcDetail> orcList = orcService.GetAll();
            return Ok(orcList);
        }

        [HttpGet("{id}")]
        public ActionResult<OrcDetail> Get(int id)
        {
            return Ok(orcService.getOrc(id));
        }

        [HttpPost]
        public ActionResult Create([FromBody] OrcCreateItem orcCreateItem)
        {
            orcService.createOrc(orcCreateItem);

            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult<OrcDetail> Update(int id, [FromBody] OrcCreateItem orcCreateItem)
        {
            OrcDetail updatedOrc = orcService.updateOrc(id, orcCreateItem);
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
        public ActionResult<IEnumerable<OrcDetail>> Delete(int id)
        {
            bool orcIsDeleted = orcService.deleteOrc(id);
            if (orcIsDeleted)
            {
                IEnumerable<OrcDetail> orcList = orcService.GetAll();
                return Ok(orcList);
            }
            else
            {
                return NotFound(id);
            }
        }
    }
}
