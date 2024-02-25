using MsgDeliveryFailReporting;
using MsgDeliveryFailReporting.Database.ViewModels;
using MsgDeliveryFailReporting.Enums;
using MsgDeliveryFailReporting.Helpers;

var appIsRunning = true;

var mainProcess = new MainProcess();

Console.WriteLine("AppRec parsing app example has started");

while (appIsRunning)
{
	Console.WriteLine("---------------------------------------------------------");
	Console.WriteLine("1. To view periods of negative apprecs received globally, press 1");
	Console.WriteLine("2. To view periods of negative apprecs received per sender, press 2");
	Console.WriteLine("3. To view periods of negative apprecs received for receiver, press 3");
	Console.WriteLine("To quit app, press q");
	Console.WriteLine("---------------------------------------------------------");

	mainProcess.MonitorFolder();

	var data = new List<NegativeApprecPeriod>();

	var action = Console.ReadLine();

	switch (action?.Trim())
	{
		case "q":
			break;
		case "1":
			data = await mainProcess.GetStatistics(StatisticsType.GLOBAL);
			break;
		case "2":

			Console.Write("Please input sender identifier or name: ");
			var senderId = Console.ReadLine();

			try
			{
				data = await mainProcess.GetStatistics(StatisticsType.SENDER, senderId);
				break;
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error occured, message: {ex.Message}");
				break;
			}
		case "3":
			Console.Write("Please input receiver identifier or name: ");
			var receiverId = Console.ReadLine();

			try
			{
				data = await mainProcess.GetStatistics(StatisticsType.RECEIVER, receiverId);
				break;
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error occured, message: {ex.Message}");
				break;
			}
		default:
			Console.WriteLine("Unknown command");
			continue;
	}

	OutputFormatHelper.FormatNegativeApprecPeriods(data);
}