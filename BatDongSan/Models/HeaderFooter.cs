using System;

namespace BatDongSan.Models
{
    public class HeaderFooter
    {
        public int Id { get; set; } // Mã id của header/footer
        public bool IsVisible { get; set; } // Trạng thái ẩn/hiện
        public string Content { get; set; } // Nội dung HTML hoặc văn bản hiển thị
        public DateTime DateCreate { get; set; } // Thời gian đăng
    }
}