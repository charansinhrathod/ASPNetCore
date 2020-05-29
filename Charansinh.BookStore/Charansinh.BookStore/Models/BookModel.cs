using Charansinh.BookStore.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Charansinh.BookStore.Models
{
    public class BookModel
    {
        
        public int ID { get; set; }
        [Required(ErrorMessage ="Book Title is required.")]
        [StringLength(50,ErrorMessage ="Book Title Length must be between 5 to 50.", MinimumLength =5)]
        public string Title { get; set; }
        [Required(ErrorMessage ="Book Author is required.")]
        public string Author { get; set; }
        
        public string Description { get; set; }
        public string Category { get; set; }
        [Required]
        public string Language { get; set; }
        [Required (ErrorMessage ="Book Language is required.")]
        public List<string> MultiLanguage { get; set; }

        public LanguageEnum LanguageEnum { get; set; }
        [Required(ErrorMessage ="Book Total Pages is required.")]
        [Range(5,500,ErrorMessage ="Enter valid total pages.")]
        public int? TotalPages { get; set; }
    }
}
