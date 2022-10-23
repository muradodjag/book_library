using System.ComponentModel.DataAnnotations;

namespace BookLibrary.Models
{
    public class Author
    {
        [Required]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }


    }

}
