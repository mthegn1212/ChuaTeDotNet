using System.ComponentModel.DataAnnotations;

namespace BatDongSan.Models;

public class PostNewModel
{
    [Microsoft.Build.Framework.Required]
    public string TinhThanh { get; set; }

    [Microsoft.Build.Framework.Required]
    public string QuanHuyen { get; set; }

    [Microsoft.Build.Framework.Required]
    public string PhuongXa { get; set; }

    [Microsoft.Build.Framework.Required]
    public string LoaiBDS { get; set; }

    [Microsoft.Build.Framework.Required]
    [Range(1, 100000, ErrorMessage = "Diện tích phải nằm trong khoảng từ 1 đến 10000 m².")]
    public int DienTich { get; set; }

    [Microsoft.Build.Framework.Required]
    [Range(1000000, 100000000, ErrorMessage = "Mức giá phải nằm trong khoảng từ 1 triệu đến 1 tỷ VND/m².")]
    public int MucGia { get; set; }

    [Microsoft.Build.Framework.Required]
    public string MoTa { get; set; }

    [Microsoft.Build.Framework.Required]
    public string LienHe { get; set; }
}
