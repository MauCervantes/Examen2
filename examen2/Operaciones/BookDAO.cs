using examen2.Context;
using examen2.Models;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examen2.Operaciones
{
    public class BookDAO
    {
        private LibraryExamen2Context contexto = new LibraryExamen2Context();

        //Create new Book (POST)
        public bool newBook(int idAuthor, string title, int chapters, int pages, double price)
        {
            //Como hacemos conexion a base de datos todo debe de estar dentro de un try catch
            try
            {
                //Checamos que el autor que introduzcamos si exista
                var authorExist = contexto.Authors.Where(author => author.Id == idAuthor).FirstOrDefault();

                //Si existe authorExist entonces procedemos a crear nuevo book
                if(authorExist != null)
                {
                    Book book = new Book();
                    book.IdAuthor = idAuthor;
                    book.Title = title;
                    book.Chapters = chapters;
                    book.Pages = pages;
                    book.Price = price;

                    //Guardamos nuevo libro en contexto
                    contexto.Books.Add(book);
                    contexto.SaveChanges();

                    //retornamos true como operación exitosa
                    return true;
                }
                //En caso de que el author no exista retornamos false como "error"
                else
                {
                    return false;
                }
            }catch (Exception ex)
            {
                //Si genera exception retornamos falso como "error"
                return false;
            }
        }

        //get all books including author (GET) for index.html
        public List<BookWithAuthor> getBooksWithAuthor()
        {
            //Realizamos query junto con Join para traernos todos los libros con 
            //el nombre de su respectivo Author
            var query = from books in contexto.Books
                        join authors in contexto.Authors on books.IdAuthor
                equals authors.Id
                        select new BookWithAuthor
                        {
                            titleBook = books.Title,
                            author = authors.Name,
                            chaptersBook = books.Chapters,
                            pagesBook = books.Pages,
                            priceBook = books.Price
                        };

            //Retorna el resultado de ejecutar el query
            return query.ToList();
        }

        //Get book by id (GET)
        public Book getBookById(int idBook)
        {
            var book = contexto.Books.Where(bookFind => bookFind.Id == idBook).FirstOrDefault();
            return book;
        }

        //Get all info from Books (GET)
        public List<Book> getBooks()
        {
            var books = contexto.Books.ToList<Book>();
            return books;
        }
    }
}
