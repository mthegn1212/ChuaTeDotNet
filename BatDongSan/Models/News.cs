using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Text;

namespace BatDongSan.Models
{
    public class News
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [MaxLength(150, ErrorMessage = "Title cannot be longer than 150 characters.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Content is required.")]
        public string Content { get; set; } = string.Empty;

        [Required(ErrorMessage = "Detail is required.")]
        public string Detail { get; set; } = string.Empty;

        public string ImagePath { get; set; } = string.Empty;

        [NotMapped]
        private string _meta;
        public string Meta
        {
            get => _meta;
            set => _meta = RemoveDiacriticsAndSpaces(value);
        }

        public void UpdateMeta()
        {
            Meta = RemoveDiacriticsAndSpaces(Title);
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

        // Metadata
        public string Link { get; set; } = string.Empty;
        
        public DateTime DateUp { get; set; } = DateTime.Now;
        public int UpById { get; set; }

        // Optional Image fields (like Project's Images)
        public string Image1 { get; set; } = string.Empty;
        public string Image2 { get; set; } = string.Empty;
        public string Image3 { get; set; } = string.Empty;
        public string Image4 { get; set; } = string.Empty;
        public string Image5 { get; set; } = string.Empty;

        public News()
        {
            Meta = RemoveDiacriticsAndSpaces(Title).Trim().ToLower().Replace(" ", "-");
            Link = "/id=" + Id + "&title=" + Meta;
            Hide = false;
            DateUp = DateTime.Now;
        }

        public override string ToString()
        {
            return $"News ID: {Id}, Title: {Title}, Content: {Content}, Link: {Link}, DateUp: {DateUp}, Hide: {Hide}, Order: {Order}";
        }
    }
}
