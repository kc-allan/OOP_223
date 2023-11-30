using System;

namespace WaterBillCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int choice = -1;
                double residentialRate = 25.00;
                double commercialRate = 30.50;
                double industrialRate = 35.75;
                double billAmount = 0;
                double consumption = 0.0;
                string usageType = "";

                Console.WriteLine("Enter the usage type:\n0.) Residential\n1.) Commercial\n2.) Industrial\n3.) Exit");
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid Choice. Try Again");
                    continue;
                }

                if (choice == 0)
                {
                    usageType = "Residential";
                }
                else if (choice == 1)
                {
                    usageType = "Commercial";
                }
                else if (choice == 2)
                {
                    usageType = "Industrial";
                }
                else if (choice == 3)
                {
                    Console.WriteLine("Exiting...");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid usage type. Please try again.");
                    continue;
                }

                Console.WriteLine("Enter the water consumption in cubic meters: ");
                try
                {
                    consumption = Convert.ToDouble(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Water consumption must be a number");
                    continue;
                }

                // Billing Algorithm
                if (usageType == "Residential")
                {
                    billAmount = consumption * residentialRate;
                }
                else if (usageType == "Commercial")
                {
                    billAmount = consumption * commercialRate;
                }
                else if (usageType == "Industrial")
                {
                    billAmount = consumption * industrialRate;
                }

                // Display Monthly Water Bill Calculation
                Console.WriteLine("\nMonthly Water Bill Calculation:");
                Console.WriteLine($"Water Consumption: {consumption} cubic meters");
                Console.WriteLine($"Usage Type: {usageType}");
                Console.WriteLine($"Bill Amount: {billAmount} KES");
            }
        }
    }
}

