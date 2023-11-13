using examen2.Models;
using examen2.Operaciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIWebLibreria.Controllers
{
    [Route("api/library")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private AuthorDAO authorDAO = new AuthorDAO();

        //Ruta para crear nuevo author (POST)
        [HttpPost("author")]
        public bool createAuthor(Author author)
        {
            return authorDAO.newAuthor(author.Name);
        }

        //Ruta para ver todos los authors (GET)
        [HttpGet("authors")]
        public List<Author> getAuthors() 
        {
            return authorDAO.getAuthors();
        }

        //Ruta para obtener los libros a partir del author que busquemos (GET)
        [HttpGet("booksAuthor")]
        public List<BookWithAuthor> getBooksByAuthor(string nameAuthor)
        {
            return authorDAO.getBooksByAuthor(nameAuthor);
        }
    }
}
