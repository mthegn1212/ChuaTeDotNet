using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BatDongSan.Models
{
    public class MenuItem
    {
        public int Id { get; set; }

        [Display(Name = "Tên Menu")]
        public string Name { get; set; }

        [Display(Name = "Đường Dẫn")]
        public string Link { get; set; }

        [Display(Name = "Thẻ Meta")]
        public string Meta { get; set; }

        [Display(Name = "Ẩn")]
        public bool Hide { get; set; }

        [Display(Name = "Thứ Tự")]
        public int Order { get; set; }

        [Display(Name = "Ngày Bắt Đầu")]
        [DataType(DataType.Date)]
        public DateTime DateBegin { get; set; }

        [Display(Name = "Danh Sách Menu Con")]
        public virtual ICollection<ChildMenus> ChildMenus { get; set; } = new List<ChildMenus>();

        public bool HasChild()
        {
            return ChildMenus != null && ChildMenus.Any();
        }
    }
}