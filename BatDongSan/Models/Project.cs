namespace BatDongSan.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string Meta { get; set; }
        public string Img { get; set; }
        public bool Hide { get; set; }
        public int Order { get; set; }
        public int Type {  get; set; }
        public string locate { get; set; }
        public int price {  get; set; }
        public string Area { get; set; }
        public DateTime DateUp { get; set; }
    }
}
