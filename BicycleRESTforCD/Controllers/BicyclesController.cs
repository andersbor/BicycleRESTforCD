using BicycleRESTforCD.Models;
using BicycleRESTforCD.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BicycleRESTforCD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BicyclesController : ControllerBase
    {
        private readonly BicycleRepository _bicycleRepository;

        public BicyclesController(BicycleRepository repo)
        {
            _bicycleRepository = repo;
        }

        // GET: api/<BicyclesController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IEnumerable<Bicycle> Get()
        {
            return _bicycleRepository.GetAll();
        }

        // GET api/<BicyclesController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Bicycle> Get(int id)
        {
            Bicycle? bicycle = _bicycleRepository.GetById(id);
            if (bicycle == null)
            {
                return NotFound();
            }
            return Ok(bicycle);
        }

        // POST api/<BicyclesController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<Bicycle> Post([FromBody] Bicycle value)
        {
            Bicycle bicycle = _bicycleRepository.Add(value);
            return CreatedAtAction(nameof(Get), new { id = bicycle.Id }, bicycle);
        }

        // PUT api/<BicyclesController>/5
        /*[HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }*/

        // DELETE api/<BicyclesController>/5
        [HttpDelete("{id}")]
        public ActionResult<Bicycle> Delete(int id)
        {
            Bicycle? bicycle = _bicycleRepository.Delete(id);
            if (bicycle == null)
            {
                return NotFound();
            }
            return Ok(bicycle);
        }
    }
}
