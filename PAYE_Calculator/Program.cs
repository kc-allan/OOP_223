#pragma warning disable CS8604, CS8600, CS0168, CS8601

using System;
using System.Collections.Generic;
using UserAccounts;


namespace PayeCalculator
{
    class Program
    {
        public static bool session = false;
        public static UserAccount in_session = null;
        public static void CalculatorConsole()
       {
            int[][] taxBrackets = new int[7][];
            taxBrackets[0] = new int[] { 0, 24000, 10 };
            taxBrackets[1] = new int[] { 24001, 40000, 15 };
            taxBrackets[2] = new int[] { 40001, 60000, 20 };
            taxBrackets[3] = new int[] { 60001, 100000, 25 };
            taxBrackets[4] = new int[] { 100001, 150000, 30 };
            taxBrackets[5] = new int[] { 150001, 250000, 35 };
            taxBrackets[6] = new int[] { 250001, int.MaxValue, 40 };
            try
            {
                Console.Write("Enter monthly income: ");
                double income = double.Parse(Console.ReadLine());
                Console.Write("Enter allowances: ");
                double allowances = double.Parse(Console.ReadLine());
                Console.Write("Enter deductions: ");
                double deductions = double.Parse(Console.ReadLine());

                // Calculate taxable income
                double taxableIncome = income - allowances - deductions;

                // Calculate PAYE tax amount
                double payeTax = 0;
                foreach (int[] bracket in taxBrackets)
                {
                    if (taxableIncome > bracket[0] && taxableIncome <= bracket[1])
                    {
                        payeTax = taxableIncome * (bracket[2] / 100);
                            payeTax = (taxableIncome - bracket[0]) * bracket[2] / 100;
                        break;
                    }
                    else if (taxableIncome > bracket[1])
                    {
                        payeTax = taxableIncome * (bracket[2] / 100);
                        payeTax = (bracket[1] - bracket[0]) * bracket[2] / 100;
                    }
                }
                // Display PAYE tax amount
                Console.WriteLine("Your PAYE tax amount is: KES {0:N2}", payeTax);
                if (session)
                {
                    DateTime current_time = DateTime.Now;
                    Dictionary<string, string> values = new Dictionary<string, string>()
                    {
                        {"income", income.ToString()},
                        {"deductions", deductions.ToString()},
                        {"allowances", allowances.ToString()},
                        {"paye_amount", payeTax.ToString()}
                    };
                    in_session.History[current_time.ToString()] = values;
                    UserAccount.UpdateHistory(in_session);
                }
            }
            catch (System.FormatException e)
            {
                Console.WriteLine("Invalid input value");
            }
        }
        static void Main()
        {
            // User inputs
            Dictionary<int, string> menu = new Dictionary<int, string>(){
                {1, "Create Account"},
                {2, "Login"},
                {3, "Calculate TAX"},
                {4, "Generate Calculations Report/History"},
                {5, "Logout"}
            };
            while (true)
            {
                Console.WriteLine("===================================");
                if (!session)
                {
                    for (int i = 1; i <= 3; i++)
                    {
                        Console.WriteLine($"{i}. {menu[i]}");
                    }
                }
                else
                {
                    foreach (KeyValuePair<int, string> item in menu)
                    {
                        if (item.Key != 1 && item.Key != 2)
                        {
                            Console.WriteLine($"{item.Key}. {item.Value}");
                        }
                    }
                }
                Console.WriteLine("===================================");
                bool running = true;
                while (true)
                {
                    if (!(session))
                    {
                        Console.Write(")> ");
                    }
                    else
                    {
                        Console.Write($"({in_session.UserName})> ");
                    }
                    string option = Console.ReadLine();
                    if (option == "1" && !session)
                    {
                        UserAccount.RegisterUser();
                    }
                    else if (option == "2" && !session)
                    {
                        Console.Write("Enter Username: ");
                        string username = Console.ReadLine();
                        session = UserAccount.LoginUser(username);
                        if (session)
                        {
                            in_session = UserAccount.users[username];
                            Console.WriteLine("---------------------------------------");
                            Console.WriteLine($"You're logged in as '{username}'");
                            Console.WriteLine("Enter 'menu' to view your options :)");
                            Console.WriteLine("---------------------------------------");
                        }
                    }
                    else if (option == "3")
                    {
                        CalculatorConsole();
                    }
                    else if (option == "4" && session)
                    {
                        UserAccount user = in_session;
                        Console.WriteLine("===================================");
                        foreach (var item in user.History)
                        {
                            string date = item.Key;
                            Dictionary<string, string> values = item.Value;
                            string income = values["income"];
                            string deductions = values["deductions"];
                            string allowances = values["allowances"];
                            string paye = values["paye_amount"];

                            Console.WriteLine("--------------------------------------");
                            Console.WriteLine($"  Date: {date}");
                            Console.WriteLine("--------------------------------------");
                            Console.WriteLine($"  Gross Income\t|  {income}");
                            Console.WriteLine($"  Allowances\t|  {allowances}");
                            Console.WriteLine($"  Deductions\t|  {deductions}");
                            Console.WriteLine($"====== PAYE Tax Amount: {paye} ======");
                            Console.WriteLine("--------------------------------------");
                        }
                        
                    }
                    else if (option == "5" && session)
                    {
                        session = false;
                        in_session = null;
                        Console.WriteLine("Logging Out...");
                    }
                    else if (option == "menu")
                    {
                        break;
                    }
                }
            }
        }
    }
}