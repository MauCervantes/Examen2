using examen2.Context;
using examen2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examen2.Operaciones
{
    public class AuthorDAO
    {
        private LibraryExamen2Context contexto = new LibraryExamen2Context();

        //Create new Author (POST)
        public bool newAuthor(string nameAuthor)
        {

            //Como todo va a hacerse con conexion a base de datos necesitamos un try catch
            try
            {
                //Hacemos comprovacion de que no exista el author que queremos agregar
                var authorExist = contexto.Authors.Where(a => a.Name == nameAuthor).FirstOrDefault();

                //En caso de que no exista el author procedemos a insertarlo
                if (authorExist == null)
                {
                    Author author = new Author();
                    author.Name = nameAuthor;

                    //Guardamos cambios en el contexto 
                    contexto.Authors.Add(author);
                    contexto.SaveChanges();

                    //retornamos true como cambios realizados exitosamente
                    return true;
                }
                //en caso de que el author ya exista retornamos false como "error"
                else
                {
                    return false;
                }
            }catch (Exception ex)
            {
                //Si genera exception retornamos false como "error"
                return false;
            }
        }

        //Get authors (GET)
        public List<Author> getAuthors()
        {
            var authors = contexto.Authors.ToList<Author>();
            return authors;
        }

        //get books by an author (GET)
        public List<BookWithAuthor> getBooksByAuthor(string nameAuthor)
        {
            //Realizamos query junto con Join para traernos todos los libros con 
            //el nombre de su respectivo Author que se esta buscando
            var query = from books in contexto.Books
                        join author in contexto.Authors on books.IdAuthor
                equals author.Id
                where author.Name == nameAuthor
                        select new BookWithAuthor
                        {
                            titleBook = books.Title,
                            author = author.Name,
                            chaptersBook = books.Chapters,
                            pagesBook = books.Pages,
                            priceBook = books.Price
                        };

            //Retorna el resultado de ejecutar el query
            return query.ToList();
        }
    }
}
