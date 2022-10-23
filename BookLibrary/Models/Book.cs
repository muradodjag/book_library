using BookLibrary.Dto;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BookLibrary.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        public string Title { get; set; }

        public string Price { get; set; }



        public List<Author> Authors { get; set; }
        public List<Genre> Genres { get; set; }

        public static Book Map(BookRequest bookRequest)
        {
            return new Book
            {
                Title = bookRequest.Title,
                Price = bookRequest.Price,

            };
        }

        public void ReplaceWithBookRequest(BookRequest bookRequest)
        {
            Price = bookRequest.Price;
            Title = bookRequest.Title;
            
            
        }

    }

}
