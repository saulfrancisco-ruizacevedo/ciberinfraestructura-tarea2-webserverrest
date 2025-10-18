using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ciberinfraestructura_tarea2_webserver_rest.DataAccess;
using ciberinfraestructura_tarea2_webserver_rest.Models;
using System.Collections.Generic;

namespace ciberinfraestructura_tarea2_webserver_rest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CatPersonalController : ControllerBase
    {
        private readonly IDataAccessProvider _provider;

        public CatPersonalController(IDataAccessProvider provider)
        {
            _provider = provider;
        }

        [HttpGet]
        public async Task<IEnumerable<CatPersonal>> Get()
        {
            return await _provider.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CatPersonal>> Get(int id)
        {
            var item = await _provider.GetByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<CatPersonal>> Post([FromBody] CatPersonal item)
        {
            var created = await _provider.AddAsync(item);
            return CreatedAtAction(nameof(Get), new { id = created.id }, created);
        }

        // PUT and DELETE intentionally omitted per requirements
    }
}