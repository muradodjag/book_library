using System.ComponentModel.DataAnnotations;

namespace BookLibrary.Models
{
    public class BookAuthor
    {
        [Key]
        public int BookId { get; set; }
        public virtual List<Book> Books { get; set; } = null!;
        public int AuthorId { get; set; }
        public virtual List<Author> Authors { get; set; } = null!;
    }
}
