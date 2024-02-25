using System.ComponentModel.DataAnnotations;

namespace MsgDeliveryFailReporting.Database.Models
{
	public class Receiver
	{
		[Key]
		public Guid Id { get; set; }

		public string? ReceiverId { get; set; } = "Unknown";

		public string? ReceiverName { get; set; } = "Unknown";
	}
}
