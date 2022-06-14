using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Model
{
	public class BaseEntity
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
	}
}
