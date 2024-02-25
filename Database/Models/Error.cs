using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MsgDeliveryFailReporting.Database.Models
{
	public class Error
	{
		[Key]
		public Guid Id { get; set; }

		public string? Err_V { get; set; }

		public string? Err_S { get; set; }

		public string? Err_DN { get; set; }

		public string? Err_OT { get; set; }

		[ForeignKey("AppRec")]
		public string AppRecId { get; set; }
		public AppRec AppRec { get; set; } = null!;
	}
}
