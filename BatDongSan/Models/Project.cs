using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BatDongSan.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string Meta { get; set; }
        //public string Img { get; set; }
        public bool Hide { get; set; }
        public int Order { get; set; }
        public int Type { get; set; }
        [NotMapped]
        public string? Province { get; set; } // Tỉnh/Thành
        [NotMapped]
        public string? District { get; set; } // Quận/Huyện
        [NotMapped]
        public string? Ward { get; set; }
        [NotMapped]
        public string? Street { get; set; }
        public string? Locate { get; set; }
        
        public string Price { get; set; }

        public string Area { get; set; }
        public DateTime DateUp { get; set; }
        public int upById { get; set; }

        //[NotMapped]
        //public List<IFormFile> UploadedImages { get; set; } // Các ảnh khác được tải lên
        public List<string> UploadedImagePaths { get; set; } // Đường dẫn lưu các ảnh tải lên
        public Project()
        {
            Hide = false;
            DateUp = DateTime.Now;
            Locate = Province + " " + District + " " + Ward + " " + Street;
            UploadedImagePaths = new List<string>();
            Meta = "-" + Id;
            string formattedName = Name.Replace(" ", "").ToLower();
            Link = "/project/" + formattedName + upById;
        }
    }
}