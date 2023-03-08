using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp3.Shared
{
    public class BookCategory
    {
        [Key]
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Author { get; set; }
        public IList<BookItem>? BookItem { get; set; }
    }
    public class BookItem
    {
        [Key]
        public string BookId { get; set; }
        public string BookName { get; set; }
        [ForeignKey("BookCategory")]
        public string CategoryId { get; set; }
        public string? Description { get; set; }
        public bool? Active { get; set; }
        public DateTime Date { get; set; }
        public int? Price { get; set; }
        public string? Image { get; set; }
        public BookCategory? BookCategory { get; set; }

    }

    public class BCShopVM
    {
        public BCShopVM()
        {
            this.BookCategory = new BookCategory();
            this.BookItem = new List<BookItem>();
        }
        public BookCategory BookCategory { get; set; }
        public List<BookItem> BookItem { get; set; }
    }
    public class ImageFile
    {
        public string base64data { get; set; }
        public string contentType { get; set; }
        public string fileName { get; set; }
    }

}
