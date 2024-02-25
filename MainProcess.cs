using MsgDeliveryFailReporting.Database.ViewModels;
using MsgDeliveryFailReporting.Enums;
using MsgDeliveryFailReporting.Services;
using MsgDeliveryFailReporting.XmlParsing;

namespace MsgDeliveryFailReporting
{
	public class MainProcess
	{
		FileSystemWatcher? watcher;
		ApprecService apprecService;
		StatisticsService statisticsService;

        public MainProcess()
        {
            apprecService = new ApprecService();
			statisticsService = new StatisticsService();
        }

        public void MonitorFolder()
		{
			watcher = new FileSystemWatcher();
			watcher.Path = @"C:\Users\Alexa\Desktop\VismaTask\MsgDeliveryFailReporting\Receipts";
			watcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName;
			watcher.Filter = "*.xml";

			watcher.Created += new FileSystemEventHandler(AppRecParsingProcess);

			watcher.EnableRaisingEvents = true;
		}

		private async void AppRecParsingProcess(object source, FileSystemEventArgs e)
		{
			if (e is not null && !string.IsNullOrEmpty(e.FullPath))
			{
				Console.WriteLine($"Parsing file {e.Name}");

				try
				{
					var parsedAppRec = XmlParser.ParseAppRecXml(e.FullPath);
					Console.WriteLine($"{e.Name} parsed successfully");

					if (parsedAppRec is not null)
					{
						try
						{
							await apprecService.SaveApprec(parsedAppRec);
							Console.WriteLine("Apprec saved to DB successfully");
						}
						catch (Exception ex)
						{
							Console.WriteLine($"Saving to DB failed with error message: {ex.Message}");
						}
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine($"Parsing failed with error message: {ex.Message}");
				}
			}
		}

		public async Task<List<NegativeApprecPeriod>> GetStatistics(StatisticsType type, string? identifier = "")
		{
			var result = new List<NegativeApprecPeriod>();

			if (type != StatisticsType.GLOBAL && string.IsNullOrEmpty(identifier))
			{
				throw new ArgumentNullException("Identifier cannot be null or empty!");
			}

			if (type == StatisticsType.GLOBAL)
			{
				result = await statisticsService.GetFailedApprecPeriodsGlobal();
			}

			if (type == StatisticsType.SENDER)
			{
				result = await statisticsService.GetFailedApprecPeriodsSender(identifier);
			}

			if (type == StatisticsType.RECEIVER)
			{
				result = await statisticsService.GetFailedApprecPeriodsReceiver(identifier);
			}

			return result;
		}
	}
}
