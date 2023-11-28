
using System;

namespace SewerageBillCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            double residentialRate = 0.05; // Rate per unit for residential users
            double commercialRate = 0.1; // Rate per unit for commercial users
            double fixedFee = 10; // Fixed fee for all users

            Console.WriteLine("Welcome to the Sewerage Bill Calculator!");
            Console.WriteLine("---------------------------------------");

            Console.WriteLine("Please enter your water consumption in cubic meters:");
            double waterConsumption;
            if (!double.TryParse(Console.ReadLine(), out waterConsumption) || waterConsumption < 0)
            {
                Console.WriteLine("Invalid input. Water consumption must be a positive number.");
                return;
            }

            Console.WriteLine("Please specify the type of usage:");
            Console.WriteLine("1 - Residential");
            Console.WriteLine("2 - Commercial");
            int usageType;
            if (!int.TryParse(Console.ReadLine(), out usageType) || (usageType != 1 && usageType != 2))
            {
                Console.WriteLine("Invalid input. Please choose 1 for Residential or 2 for Commercial.");
                return;
            }

            double rate;
            string usageTypeString;
            if (usageType == 1)
            {
                rate = residentialRate;
                usageTypeString = "Residential";
            }
            else
            {
                rate = commercialRate;
                usageTypeString = "Commercial";
            }

            double billAmount = (waterConsumption * rate) + fixedFee;

            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Calculation Summary:");
            Console.WriteLine("Water Consumption: {0} cubic meters", waterConsumption);
            Console.WriteLine("Usage Type: {0}", usageTypeString);
            Console.WriteLine("Rate per Unit: {0}", rate);
            Console.WriteLine("Fixed Fee: {0}", fixedFee);
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Your monthly sewerage bill amount: {0}", billAmount);
        }
    }
}

