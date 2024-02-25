using Microsoft.EntityFrameworkCore;
using MsgDeliveryFailReporting.Database.Models;
using MsgDeliveryFailReporting.Database.ViewModels;

namespace MsgDeliveryFailReporting.Database
{
	public class AppRecDbContext : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=DESKTOP-18ID9EB;Initial Catalog=AppRecDB;Integrated Security=True;TrustServerCertificate=True");
		}

		public DbSet<AppRec> AppRecs { get; set; }
		public DbSet<Error> Errors { get; set; }
		public DbSet<MessageType> MessageTypes { get; set; }
		public DbSet<Receiver> Receivers { get; set; }
		public DbSet<Sender> Senders { get; set; }
		public DbSet<Status> Statuses { get; set; }
		public virtual DbSet<NegativeApprecPeriod> NegativeApprecPeriods { get; set; }
	}
}
