using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using examen2.Operaciones;
using examen2.Models;

namespace APIWebLibreria.Controllers
{
    [Route("api/library")]
    [ApiController]
    public class BookController : ControllerBase
    {
        //Variable de tipo BookDAO
        private BookDAO bookDAO = new BookDAO();

        //Ruta para crear nuevo Book (POST)
        [HttpPost("book")]
        public bool createNewBook(Book book)
        {
            return bookDAO.newBook(book.IdAuthor, book.Title, book.Chapters, book.Pages, book.Price);
        }

        //Ruta para traer bookWithAuthor (GET)
        [HttpGet("booksAuthors")]
        public List<BookWithAuthor> getBooksWithAuthor()
        {
            return bookDAO.getBooksWithAuthor();
        }

        //Ruta para traer Book por id (GET)
        [HttpGet("book")]
        public Book getBookById(int id)
        {
            return bookDAO.getBookById(id);
        }

        //Ruta para traer la info de todos los libros (GET)
        [HttpGet("books")]
        public List<Book> getBooks()
        {
            return bookDAO.getBooks();
        }
    }
}
