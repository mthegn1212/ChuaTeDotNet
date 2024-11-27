using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices.JavaScript;
using Microsoft.AspNetCore.Http;

namespace BatDongSan.Models
{
    public class News
    {
        public int Id { get; set; }

        // Thông tin cơ bản
        [Required(ErrorMessage = "Title is required.")]
        [MaxLength(150, ErrorMessage = "Title cannot be longer than 150 characters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Content is required.")]
        public string Content { get; set; }
        
        [Required(ErrorMessage = "Detail is required.")]
        public string Detail { get; set; }
        
        // Hình ảnh
        [NotMapped]
        public IFormFile Images { get; set; }

        public string ImagePath { get; set; }

        // Metadata
        public string Link { get; set; }
        
        public string Meta { get; set; }
        
        public bool? Hide { get; set; }
        public int Order { get; set; }
        public DateTime? DateUp { get; set; }
    }
}