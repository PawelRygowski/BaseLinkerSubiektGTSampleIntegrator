using BaseSubjektIntegrator.BaseLinker;
using BaseSubjektIntegrator.SubiektGT;
using BaseSubjektIntegrator.UI;
using System;
using System.Diagnostics;
using System.Threading;

namespace BaseSubjektIntegrator
{
	class Program
	{
		[STAThread]
		static void Main(string[] args)
		{
			ConsoleUI ui = new ConsoleUI();
			Configuration configuration = new Configuration();
			BaseLinkerConnector baseLinkerConnector = new BaseLinkerConnector(configuration);
			SubiektGTConnector subiektGTConnector = new SubiektGTConnector(configuration);
			BaseLinkerOrderModel baseLinkerOrder;
			Stopwatch stopWatch = new Stopwatch(); //mock traficShaper

			do
			{
				Console.Clear();
				baseLinkerOrder = null;
				do
				{
					int orderId = ui.ShowOptions("Type in the BaseLinker order id:");

					if (stopWatch.ElapsedMilliseconds != 0 && stopWatch.ElapsedMilliseconds < configuration.Interval)
					{
						Console.WriteLine($"Waiting for next request for {configuration.Interval - stopWatch.ElapsedMilliseconds} miliseconds...");
						Thread.Sleep(6000 - (int)stopWatch.ElapsedMilliseconds);
					}

					baseLinkerOrder = baseLinkerConnector.GetOrderById(orderId);

					stopWatch.Reset();
					stopWatch.Start();

					if (baseLinkerOrder == null) Console.WriteLine($"No order with id {orderId}");
				} while (baseLinkerOrder == null);
				Console.WriteLine("Order downloaded successfully.");
				Console.WriteLine("Sending order to Subiekt GT API...");
				subiektGTConnector.SendOrder(baseLinkerOrder);
			} while (ui.ShowAlternative("Process another order?(y//n)"));
		}
	}
}
