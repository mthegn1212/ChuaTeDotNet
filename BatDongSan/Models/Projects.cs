using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;

namespace BatDongSan.Models
{
    public class Projects
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Link { get; set; } = string.Empty;
        [NotMapped]
        private string _meta;
        public string Meta
        {
            get => _meta;
            set => _meta = RemoveDiacriticsAndSpaces(value);
        }

        public void UpdateMeta()
        {
            Meta = RemoveDiacriticsAndSpaces(Name);
        }

        // Phương thức loại bỏ dấu tiếng Việt và khoảng trắng
        private static string RemoveDiacriticsAndSpaces(string text)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;

            // Loại bỏ dấu tiếng Việt
            string normalizedString = text.Normalize(NormalizationForm.FormD);
            StringBuilder stringBuilder = new StringBuilder();

            foreach (char c in normalizedString)
            {
                UnicodeCategory unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            // Loại bỏ khoảng trắng và chuyển thành chữ thường
            return stringBuilder.ToString().Normalize(NormalizationForm.FormC).Replace(" ", "").ToLower();
        }
        public bool Hide { get; set; }
        public int Order { get; set; }
        public int Type { get; set; }
        public string? Locate { get; set; }
        public string Price { get; set; } = string.Empty;
        public string Area { get; set; } = string.Empty;
        public DateTime DateUp { get; set; }
        public int upById { get; set; }
        
        public string Image1 { get; set; } = string.Empty;
        public string Image2 { get; set; } = string.Empty;
        public string Image3 { get; set; } = string.Empty;
        public string Image4 { get; set; } = string.Empty;
        public string Image5 { get; set; } = string.Empty;

        //public ICollection<ProjectImage> ProjectImages { get; set; }

        public Projects()
        {
            Meta = RemoveVietnameseTone(Name).Trim().ToLower().Replace(" ", "-");
            Link = "/id=" + Id + "&name=" + Meta;
            Hide = false;
            DateUp = DateTime.Now;
        }

        public override string ToString()
        {
            return $"Project ID: {Id}, Name: {Name}, Description: {Description}, Link: {Link}, Price: {Price}, Area: {Area}, DateUp: {DateUp}, Hide: {Hide}, Order: {Order}, Type: {Type}, Locate; {Locate}";
        }
        private string RemoveVietnameseTone(string str)
        {
            // Chuyển đổi dấu tiếng Việt thành không dấu
            string formD = str.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();

            foreach (char c in formD)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(c);
                }
            }

            return sb.ToString().Normalize(NormalizationForm.FormC);
        }
    }
}