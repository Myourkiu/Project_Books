using Books.Model;

namespace Books.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> Get(); //usado para buscar
        Task<Book> Get(int Id);  //usado para consultar
        Task<Book> Create(Book book);  //usado para criar
        Task Update(Book book);  //usado para editar
        Task Delete(int Id);  //usado para deletar
        
    }
}
