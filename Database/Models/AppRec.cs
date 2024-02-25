using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MsgDeliveryFailReporting.Database.Models
{
	public class AppRec
	{
		[Key]
		public string Id { get; set; }

		[ForeignKey("MessageType")]
		public Guid? MsgTypeId { get; set; }
		public virtual MessageType? MsgType { get; set; }

		public string MIGversion { get; set; } = "1.0 2004-11-21";

		public string? SoftwareName { get; set; }

		public string? SoftwareVersion { get; set; }

		public DateTime GenDate { get; set; }

		[ForeignKey("Status")]
		public Guid? StatusId { get; set; }
		public virtual Status? Status { get; set; }

		[ForeignKey("Sender")]
		public Guid? SenderId { get; set; }
		public virtual Sender Sender { get; set; } = new Sender();

		[ForeignKey("Receiver")]
		public Guid? ReceiverID { get; set; }
		public virtual Receiver Receiver { get; set; } = new Receiver();

		public ICollection<Error> Errors { get; } = new List<Error>();
	}
}
