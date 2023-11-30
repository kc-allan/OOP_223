using System;

class PayeCalculator
{
    static void Main()
    {
        Console.WriteLine("Welcome to the PAYE Tax Calculator!");

        // Get user inputs
        double income = GetUserInput("Enter your monthly income: ");
        double allowances = GetUserInput("Enter your allowances: ");
        double deductions = GetUserInput("Enter your deductions: ");

        // Calculate PAYE tax
        double taxableIncome = Math.Max(0, income - allowances - deductions);
        double payeTax = CalculatePaye(taxableIncome);

        // Display tax calculation
        DisplayTaxCalculation(income, allowances, deductions, taxableIncome, payeTax);

        // Generate tax certificate (optional)
        Console.Write("Do you want to generate a tax certificate? (yes/no): ");
        string generateCertificate = Console.ReadLine().ToLower();
        if (generateCertificate == "yes")
        {
            var userDetails = GetUserDetails();
            var taxCertificate = GenerateTaxCertificate(userDetails, income, allowances, deductions, taxableIncome, payeTax);

            // Save or print the tax certificate as needed
            Console.WriteLine("\n--- Tax Certificate ---");
            Console.WriteLine(taxCertificate);
        }
    }

    static double GetUserInput(string prompt)
    {
        double userInput;
        Console.Write(prompt);
        while (!double.TryParse(Console.ReadLine(), out userInput))
        {
            Console.WriteLine("Invalid input. Please enter a numeric value.");
            Console.Write(prompt);
        }
        return userInput;
    }

    static double CalculatePaye(double income)
    {
        // Define PAYE tax brackets and rates for Kenya in 2023
        double[] brackets = { 24000, 32333, 40567, 48800, 57033, 76567, 96100, 115633, 135167, double.MaxValue };
        double[] rates = { 0.1, 0.15, 0.2, 0.25, 0.3, 0.35, 0.4, 0.45, 0.5, 0.6 };

        // Calculate PAYE tax
        double tax = 0;
        for (int i = 0; i < brackets.Length; i++)
        {
            if (income > brackets[i])
            {
                tax += (brackets[i] - (i > 0 ? brackets[i - 1] : 0)) * rates[i];
            }
            else
            {
                tax += (income - (i > 0 ? brackets[i - 1] : 0)) * rates[i];
                break;
            }
        }

        return tax;
    }

    static void DisplayTaxCalculation(double income, double allowances, double deductions, double taxableIncome, double payeTax)
    {
        Console.WriteLine("\n--- Tax Calculation ---");
        Console.WriteLine($"Income: {income}");
        Console.WriteLine($"Allowances: {allowances}");
        Console.WriteLine($"Deductions: {deductions}");
        Console.WriteLine($"Taxable Income: {taxableIncome}");
        Console.WriteLine($"PAYE Tax: {payeTax}");
    }

    static string GenerateTaxCertificate(UserDetails userDetails, double income, double allowances, double deductions, double taxableIncome, double payeTax)
    {
        string taxCertificate = $"--- Tax Certificate ---\n" +
                                $"Name: {userDetails.Name}\n" +
                                $"ID Number: {userDetails.IDNumber}\n" +
                                $"Income: {income}\n" +
                                $"Allowances: {allowances}\n" +
                                $"Deductions: {deductions}\n" +
                                $"Taxable Income: {taxableIncome}\n" +
                                $"PAYE Tax: {payeTax}";

        return taxCertificate;
    }

    static UserDetails GetUserDetails()
    {
        Console.Write("Enter your full name: ");
        string name = Console.ReadLine();

        Console.Write("Enter your ID number: ");
        string idNumber = Console.ReadLine();

        // Add more user details as needed

        return new UserDetails { Name = name, IDNumber = idNumber };
    }
}

class UserDetails
{
    public string Name { get; set; }
    public string IDNumber { get; set; }

    // Add more properties as needed
}
