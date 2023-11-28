using System;

namespace  PowerBillCalculator
{
	class Program
	{
		static void Main(string[] args)
		{
			while (true)
			{
				int choice = -1;
				double residentialRate = 12.50;
				double commercialRate = 15.75;
				double industrialRate = 18.90;
				double billAmount = 0;
				double consumption = 0.0;
				string usageType = "";

				Console.WriteLine("Enter the usage type:\n0.) Residential\n1.)commercial\n2.)Industrial\n3.)exit");
				try
				{
					choice = Convert.ToInt32(Console.ReadLine());
				}
				catch (FormatException)
				{
					Console.WriteLine("Invalid Choice Try Again");
					continue;
				}

				if (choice == 0)
				{
					billAmount = consumption * residentialRate;
					usageType = "Residential";

				}
				else if (choice == 1)
				{
					billAmount = consumption * commercialRate;
					usageType = "commercial";

				}
				else if (choice == 2)
				{
					billAmount = consumption * industrialRate;
					usageType = "industrial";

				}
				else if (choice == 3)
				{
					Console.WriteLine("Exiting...");
					break;
				}
				else
				{
					Console.WriteLine("invalid usage type. please try again.");
					continue;
				}
				Console.WriteLine("Enter the power consumption: ");
				try
				{
					consumption = Convert.ToDouble(Console.ReadLine());
				}
				catch (FormatException)
				{
					Console.WriteLine("power consumption must be a number");
					continue;
				}

				Console.WriteLine("MonthlyPower bill calculation:");
				Console.WriteLine($"Power Consumption: {consumption}kWh");
				Console.WriteLine($"Usage Type: {usageType}");
				Console.WriteLine($"Bill Amount: {billAmount} KES");
			}
		}
	}
}
