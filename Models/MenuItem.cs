namespace BatDongSan.Models
{
    public class MenuItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public string Meta { get; set; }
        public bool Hide { get; set; }
        public int Order { get; set; }
        public DateTime DateBegin { get; set; }
		public virtual ICollection<ChildMenus> ChildMenus { get; set; } = new List<ChildMenus>();
        public bool HasChild()
        {
            return ChildMenus != null && ChildMenus.Any();
        }
    }
}
