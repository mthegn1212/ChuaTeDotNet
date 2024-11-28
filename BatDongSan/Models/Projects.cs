using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace BatDongSan.Models
{
    public class Projects
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }  // Lưu trữ nội dung HTML
        public string Link { get; set; }
        public string Meta { get; set; }
        public bool Hide { get; set; }
        public int Order { get; set; }
        public int Type { get; set; }

        [NotMapped]
        public string? Province { get; set; }
        
        [NotMapped]
        public string? District { get; set; }
        
        [NotMapped]
        public string? Ward { get; set; }
        
        [NotMapped]
        public string? Street { get; set; }
        
        public string? Locate { get; set; }
        public string Price { get; set; }
        public string Area { get; set; }
        public DateTime DateUp { get; set; }
        public int upById { get; set; }

        // List of ProjectImage (Instead of List<string>)
        public List<ProjectImages> ProjectImages { get; set; }  // Danh sách ảnh

        [NotMapped]
        public string? RepresentativeImage { get; set; }  // Đường dẫn ảnh đại diện (ảnh đầu tiên)

        public Projects()
        {
            Hide = false;
            DateUp = DateTime.Now;
            Locate = $"{Province} {District} {Ward} {Street}";
            ProjectImages = new List<ProjectImages>();  // Khởi tạo danh sách ảnh
            Meta = $"-{Id}";
            Link = $"/project/{upById}{Id}";
            
            // Set the first image as the representative image if any images are uploaded
            RepresentativeImage = ProjectImages.FirstOrDefault()?.ImageUrl;  // Lấy ảnh đầu tiên làm ảnh đại diện
        }
    }
}