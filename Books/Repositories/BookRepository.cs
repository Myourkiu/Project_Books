using Books.Data;
using Books.Model;
using Microsoft.EntityFrameworkCore;

namespace Books.Repositories
{
    public class BookRepository : IBookRepository
    {
        public readonly AppDbContext _appDb;
        public BookRepository(AppDbContext appDb)
        {
            _appDb = appDb;
        }

        public async Task<Book> Create(Book book)
        {
            _appDb.Books.Add(book);
            await _appDb.SaveChangesAsync();

            return book;

            //o await é usado quando voce tiver fazendo de fato a execução da ação do método
            //por exemplo, a ação do metodo create é no salvamento do dado no banco
        }

        public async Task Delete(int Id)
        {
            var bookToDelete = await _appDb.Books.FindAsync(Id);
            _appDb.Books.Remove(bookToDelete);
            await _appDb.SaveChangesAsync();
        }

        public async Task<IEnumerable<Book>> Get()
        {
            return await _appDb.Books.ToListAsync();
        }

        public async Task<Book> Get(int Id)
        {
            return await _appDb.Books.FindAsync(Id);
        }

        public async Task Update(Book book)
        {
            _appDb.Entry(book).State = EntityState.Modified;
            await _appDb.SaveChangesAsync();
        }
    }
}
