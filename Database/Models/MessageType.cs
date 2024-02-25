using System.ComponentModel.DataAnnotations;

namespace MsgDeliveryFailReporting.Database.Models
{
	public class MessageType
	{
		[Key]
		public Guid Id { get; set; }

		public string? V { get; set; }

		public string? DN { get; set; }
	}
}
