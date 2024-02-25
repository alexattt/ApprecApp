using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MsgDeliveryFailReporting.Database.Models
{
	public class Sender
	{
		[Key]
		public Guid Id { get; set; }

		public string? SenderId { get; set; } = "Unknown";

		public string? SenderName { get; set; } = "Unknown";
	}
}
