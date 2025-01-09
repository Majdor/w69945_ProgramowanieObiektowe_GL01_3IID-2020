using Microsoft.AspNetCore.Mvc;

namespace lab_7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController1 : ControllerBase
    {
        private static List<string> values = new List<string> { "value1", "value2" };

        // GET: api/ValuesController1
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return values;
        }

        // GET: api/ValuesController1/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id < 0 || id >= values.Count)
            {
                return NotFound("Value not found");
            }
            return Ok(values[id]);
        }

        // POST: api/ValuesController1
        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            values.Add(value);
            return CreatedAtAction(nameof(Get), new { id = values.Count - 1 }, value);
        }

        // PUT: api/ValuesController1/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            if (id < 0 || id >= values.Count)
            {
                return NotFound("Value not found");
            }
            values[id] = value;
            return NoContent();
        }

        // DELETE: api/ValuesController1/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id < 0 || id >= values.Count)
            {
                return NotFound("Value not found");
            }
            values.RemoveAt(id);
            return NoContent();
        }
    }
}
