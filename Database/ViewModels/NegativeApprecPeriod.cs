using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace MsgDeliveryFailReporting.Database.ViewModels
{
	[Keyless]
	public class NegativeApprecPeriod
	{
		[Column("PeriodStart")]
		public DateTime PeriodStart { get; set; }

		[Column("PeriodEnd")]
		public DateTime PeriodEnd { get; set; }

		[Column("Status")]
		public string Status { get; set; } = string.Empty;

		[Column("ApprecsFailed")]
		public int ApprecsFailed { get; set; }
	}
}
