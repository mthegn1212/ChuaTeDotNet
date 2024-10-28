using System.ComponentModel.DataAnnotations.Schema;

namespace BatDongSan.Models
{
    public class ChildMenus
    {
		public int Id { get; set; }
		public string Name { get; set; }
		public string Link { get; set; }
		public string Meta { get; set; }
		public bool Hide { get; set; }
		public int Order { get; set; }
		public DateTime DateBegin { get; set; }

		[ForeignKey("MenuItem")]
		public int MenuItemId { get; set; }

		public virtual MenuItem? MenuItem { get; set; }
	}
}
