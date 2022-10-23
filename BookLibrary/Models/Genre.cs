using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BookLibrary.Models
{
	public class Genre
	{
		[Key]
		public int GenreId { get; set; }
		public string Name { get; set; }
		[JsonIgnore] public List<Book>? Books { get; set; }

    }

}