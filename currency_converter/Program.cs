using System;
using System.Collections.Generic;

public class CurrencyConverter
{
    private static Dictionary<string, double> exchangeRates = new Dictionary<string, double>()
    {
        // Currency Code | Exchange Rate (USD/Currency)
        {"USD", 1.00},
        {"EUR", 0.98},
        {"JPY", 136.26},
        {"GBP", 0.66},
        {"AUD", 1.53},
        {"CAD", 1.32},
        {"CHF", 0.95},
        {"CNY", 6.76},
        {"HKD", 7.84},
        {"INR", 80.56},
        {"KRW", 1325.30},
        {"MXN", 20.29},
        {"NZD", 1.61},
        {"SGD", 1.36},
        {"THB", 37.36},
        {"TRY", 18.50},
        {"BRL", 5.12},
        {"RUB", 63.28},
        {"SEK", 10.12},
        {"NOK", 9.44},
        {"DKK", 7.44},
        {"PLN", 4.96},
        {"HUF", 378.26},
        {"CZK", 26.24},
        {"RON", 4.95},
        {"KES", 121.66}
    };

    public static double ConvertCurrency(string fromCurrency, string toCurrency, double amount)
    {
        // Convert currency codes to uppercase for consistency
        fromCurrency = fromCurrency.ToUpper();
        toCurrency = toCurrency.ToUpper();

        if (!exchangeRates.ContainsKey(fromCurrency) || !exchangeRates.ContainsKey(toCurrency))
        {
            throw new Exception("Invalid currency code");
        }

        double conversionRate = exchangeRates[toCurrency] / exchangeRates[fromCurrency];
        double convertedAmount = amount * conversionRate;

        return convertedAmount;
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Currency Converter | Exchange Rate (USD/Currency)");

        while (true)
        {
            Console.WriteLine("Enter the base currency you want to convert from:");
            string? baseCurrency = Console.ReadLine();

            Console.WriteLine("Enter the amount you want to convert:");

            // Validate user input for amount
            if (!double.TryParse(Console.ReadLine(), out double amount))
            {
                Console.WriteLine("Invalid input. Please enter a valid amount.");
                continue;
            }

            Console.WriteLine("Enter the target currency you want to convert to:");
            string? targetCurrency = Console.ReadLine();

            // Check for null before calling ConvertCurrency
            if (baseCurrency is not null && targetCurrency is not null)
            {
                try
                {
                    double convertedAmount = ConvertCurrency(baseCurrency, targetCurrency, amount);
                    Console.WriteLine("Converted amount: {0} {1}", convertedAmount, targetCurrency);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter valid currency codes.");
            }

            Console.WriteLine("Do you want to perform another conversion? (Y/N)");
            string answer = Console.ReadLine()?.ToUpper() ?? "";

            if (answer != "Y")
            {
                Console.WriteLine("Do you want to see all available currencies? (Y/N)");
                string seeAllCurrencies = Console.ReadLine()?.ToUpper() ?? "";

                if (seeAllCurrencies == "Y")
                {
                    Console.WriteLine("Available Currencies:");
                    foreach (var currency in exchangeRates.Keys)
                    {
                        Console.WriteLine(currency);
                    }
                }

                Console.WriteLine("Thank you for using the Currency Converter. Goodbye!");
                break;
            }
        }
    }
}
