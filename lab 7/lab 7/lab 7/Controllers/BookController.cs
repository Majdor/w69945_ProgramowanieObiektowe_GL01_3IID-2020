using Microsoft.AspNetCore.Mvc;

namespace lab_7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _repository;

        public BookController(IBookRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public List<Book> GetAll()
        {
            return _repository.GetAll();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {
            if (book == null)
            {
                return BadRequest("Book is null");
            }

            _repository.Create(book);
            return Ok(true);
        }
    }
}
