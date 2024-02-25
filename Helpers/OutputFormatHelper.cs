using MsgDeliveryFailReporting.Database.ViewModels;

namespace MsgDeliveryFailReporting.Helpers
{
	public static class OutputFormatHelper
	{
		public static void FormatNegativeApprecPeriods(List<NegativeApprecPeriod> negativeApprecPeriods)
		{
			if (negativeApprecPeriods.Count == 0)
			{
				Console.WriteLine("No negative apprec periods detected");
				return;
			}

			foreach (var item in negativeApprecPeriods)
			{
				Console.WriteLine($"Period start: {item.PeriodStart}  Period end: {item.PeriodEnd}  Apprec count: {item.ApprecsFailed}");
			}

			Console.WriteLine();
		}
	}
}
