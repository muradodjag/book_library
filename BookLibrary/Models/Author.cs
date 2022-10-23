using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BookLibrary.Models
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }

        public string FullName { get; set; }

        [JsonIgnore]
        public  List<Book>? Books { get; set; }



    }

}
