using System.ComponentModel.DataAnnotations;

namespace BookLibrary.Models
{
    public class BookGenre
    {
        [Key]
        public int BookId { get; set; } = 0;
        public Book Book { get; set; }
        public int GenreId { get; set; } = 0;
        public Genre Genre { get; set; }  
    }
}
