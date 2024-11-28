using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace BatDongSan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        // Đọc dữ liệu từ file JSON
        private string ReadJsonFile(string fileName)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "data", fileName);
            return System.IO.File.ReadAllText(filePath);
        }

        // Lấy tất cả Tỉnh/Thành phố
        [HttpGet("tinh_tp")]
        public IActionResult GetTinhTp()
        {
            var data = ReadJsonFile("tinh_tp.json");
            var tinhTpList = JsonConvert.DeserializeObject<Dictionary<string, TinhTp>>(data);
            return Ok(tinhTpList);
        }

        // Lấy Quận/Huyện theo Tỉnh/Thành phố
        [HttpGet("quan_huyen")]
        public IActionResult GetQuanHuyen([FromQuery] string tinh_id)
        {
            var data = ReadJsonFile("quan_huyen.json");
            var quanHuyenList = JsonConvert.DeserializeObject<Dictionary<string, QuanHuyen>>(data)
                .Where(q => q.Value.parent_code == tinh_id)
                .ToDictionary(q => q.Key, q => q.Value);

            if (!quanHuyenList.Any())
            {
                return NotFound(new { message = "Quận/Huyện not found for the given Tỉnh/Thành phố." });
            }

            return Ok(quanHuyenList);
        }

        // Lấy Xã/Phường theo Quận/Huyện
        [HttpGet("xa_phuong")]
        public IActionResult GetXaPhuong([FromQuery] string quan_id)
        {
            var data = ReadJsonFile("xa_phuong.json");
            var xaPhuongList = JsonConvert.DeserializeObject<Dictionary<string, XaPhuong>>(data)
                .Where(x => x.Value.parent_code == quan_id)
                .ToDictionary(x => x.Key, x => x.Value);

            if (!xaPhuongList.Any())
            {
                return NotFound(new { message = "Xã/Phường not found for the given Quận/Huyện." });
            }

            return Ok(xaPhuongList);
        }
    }

    public class TinhTp
    {
        public string code { get; set; }
        public string name { get; set; }
    }

    public class QuanHuyen
    {
        public string code { get; set; }
        public string name { get; set; }
        public string parent_code { get; set; }
    }

    public class XaPhuong
    {
        public string code { get; set; }
        public string name { get; set; }
        public string parent_code { get; set; }
    }
}
