using System.ComponentModel.DataAnnotations.Schema;

namespace BatDongSan.Models
{
    public class News
    {
        public int Id { get; set; }

        // Thông tin cơ bản
        public string Title { get; set; } // Tiêu đề bài đăng
        public string Content { get; set; } // Nội dung chi tiết bài đăng

        // Địa chỉ
        public string FullAddress { get; set; } // Địa chỉ đầy đủ (gộp Tỉnh, Quận, Phường, Đường)
        public string Province { get; set; } // Tỉnh/Thành
        public string District { get; set; } // Quận/Huyện
        public string Ward { get; set; } // Phường/Xã

        // Thông tin bất động sản
        public string PropertyType { get; set; } // Loại bất động sản (VD: Nhà, Đất, Chung cư)
        public double Area { get; set; } // Diện tích (m²)
        public decimal TotalPrice { get; set; } // Giá bán tổng cộng (VNĐ)
        public string ContactInfo { get; set; } // Thông tin liên hệ (Số điện thoại/Zalo/Email)

        // Hình ảnh
        [NotMapped]
        public IFormFile FeaturedImage { get; set; } // Hình ảnh đại diện

        [NotMapped]
        public List<IFormFile> UploadedImages { get; set; } // Các ảnh khác được tải lên

        public string FeaturedImagePath { get; set; } // Đường dẫn lưu ảnh đại diện
        public List<string> UploadedImagePaths { get; set; } // Đường dẫn lưu các ảnh tải lên

        // Metadata
        public string Link { get; set; } // Link liên kết (nếu có)
        public string Meta { get; set; } // Metadata (nếu có)
        public bool Hide { get; set; } // Trạng thái hiển thị
        public int Order { get; set; } // Thứ tự ưu tiên
        public DateTime DateUp { get; set; } // Ngày đăng
        
        // Constructor để thiết lập giá trị mặc định
        public News()
        {
            // Nếu người dùng không cung cấp giá trị, chúng ta sẽ tự động thiết lập các giá trị mặc định
            Hide = false; // Mặc định là hiển thị
            Order = 0;    // Mặc định là thứ tự ưu tiên 0
            DateUp = DateTime.Now; // Mặc định là ngày và giờ hiện tại
        }
    }
}