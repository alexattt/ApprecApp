using Microsoft.EntityFrameworkCore;
using MsgDeliveryFailReporting.Database;
using MsgDeliveryFailReporting.Database.ViewModels;

namespace MsgDeliveryFailReporting.Services
{
	public class StatisticsService
	{
		public AppRecDbContext _dbContext;

		public StatisticsService()
		{
			_dbContext = new AppRecDbContext();
		}

		public async Task<List<NegativeApprecPeriod>> GetFailedApprecPeriodsGlobal()
		{
			List<NegativeApprecPeriod> globalFailedPeriods =
				await _dbContext.NegativeApprecPeriods
					.FromSqlInterpolated($"EXEC dbo.GetFailedApprecPeriodsGlobal")
					.ToListAsync();

			return globalFailedPeriods;
		}

		public async Task<List<NegativeApprecPeriod>> GetFailedApprecPeriodsSender(string SenderIdentifier)
		{
			List<NegativeApprecPeriod> senderFailedPeriods =
				await _dbContext.NegativeApprecPeriods
					.FromSqlInterpolated($"EXEC dbo.GetFailedApprecPeriodsSender {SenderIdentifier}")
					.ToListAsync();

			return senderFailedPeriods;
		}

		public async Task<List<NegativeApprecPeriod>> GetFailedApprecPeriodsReceiver(string ReceiverIdentifier)
		{
			List<NegativeApprecPeriod> senderFailedPeriods =
				await _dbContext.NegativeApprecPeriods
					.FromSqlInterpolated($"EXEC dbo.GetFailedApprecPeriodsReceiver {ReceiverIdentifier}")
					.ToListAsync();

			return senderFailedPeriods;
		}
	}
}
