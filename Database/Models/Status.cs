using System.ComponentModel.DataAnnotations;

namespace MsgDeliveryFailReporting.Database.Models
{
	public class Status
	{
		[Key]
		public Guid Id { get; set; }

		public string? Status_V { get; set; }

		public string? Status_DN { get; set; }
	}
}
