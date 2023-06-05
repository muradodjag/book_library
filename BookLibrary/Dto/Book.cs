using BookLibrary.Models;

namespace BookLibrary.Dto
{
    public record BookRequest(

        string Title, string Price, List<Author> Authors, List<Genre> Genres
        );
    public class BookResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Test { get; set; }
        public string Test2 { get; set; }
        public string Price { get; set; }
        public List<Author> Authors { get; set; }
        public List<Genre> Genres { get; set; }    

        public static BookResponse FromBook(Book book)
        {
            return new BookResponse
            {
                Id = book.BookId,
                Title = book.Title,
                Price = book.Price,
                Authors = book.Authors,
                Genres = book.Genres
              
            };
        }
    }
}
