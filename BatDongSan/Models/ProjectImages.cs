using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BatDongSan.Models
{
    public class ProjectImages
    {
        [Key]
        public int Id { get; set; }

        public int ProjectId { get; set; }

        public string ImageUrl { get; set; }

        [ForeignKey("ProjectId")]
        public Projects Projects { get; set; }  // Liên kết với đối tượng Project
    }
}