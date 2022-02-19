using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibApp.Models
{
    public class Book
    {
        public int Id { get; set; }
		[Required(ErrorMessage = "Name is required.")]
		[StringLength(255)]
		public string Name { get; set; }
		[Required(ErrorMessage = "Author name is required.")]
		public string AuthorName { get; set; }
		public Genre Genre { get; set; }
		[Required(ErrorMessage = "Genre is required.")]
		[Range(1, byte.MaxValue, ErrorMessage = "Genre is required.")]
		public byte? GenreId { get; set; }
		public DateTime DateAdded { get; set; }
		[Required(ErrorMessage = "Release date is required.")]
		public DateTime ReleaseDate { get; set; }
		[Required(ErrorMessage = "Number in stock is required.")]
		[Range(1, 20, ErrorMessage = "Number must be between 1 and 20.")]
		public int NumberInStock { get; set; }
		//[Required(ErrorMessage = "Number available is required.")]
		public int NumberAvailable { get; set; }
	}
      
}
