using System.ComponentModel.DataAnnotations;

namespace BookListRazor.Model
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [Required]
        public string BookName { get; set; }
        public string BookAuthor { get; set; }

        public string ISBN { get; set; }
    }
}
