using Books.Model;
using Books.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Books.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        public BooksController(IBookRepository bookRepository) //injetando a interface pq os métodos necessários estão nela
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]

        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await _bookRepository.Get();  //pegar todos os livros
        }

        [HttpGet("(Id)")]

        public async Task<ActionResult<Book>> GetBooks(int Id)
        {
            return await _bookRepository.Get(Id);  //buscar um livro por id
        }

        [HttpPost]

        public async Task<ActionResult<Book>> PostBook([FromBody] Book book)
        {
            var newBook = await _bookRepository.Create(book);  //criar um livro
            return CreatedAtAction(nameof(GetBooks), new { Id = newBook.Id }, newBook );
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int Id)
        {
            var bookToDelete = await _bookRepository.Get(Id);  //deletar um livro

            if (bookToDelete == null)
                return NotFound();

            await _bookRepository.Delete(bookToDelete.Id);
            return NoContent();

            
        }

        [HttpPut]
        public async Task<ActionResult> PutBooks(int Id, [FromBody] Book book)
        {
            if (Id != book.Id)
                return BadRequest();

                await _bookRepository.Update(book);  //atualizar um livro

            return NoContent();
        }


    }
}
