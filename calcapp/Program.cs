namespace calcapp
{
    public class Program
    {
        public static void Addition()
        {
            Console.WriteLine("enter your first operand");
            string a=Console.ReadLine();
            double b=double.Parse(a);
            Console.WriteLine("enter your second operand");
            string c=Console.ReadLine();
            double d=double.Parse(c);
            double e = b + d;
            Console.WriteLine("result of {0} + {1} = {2} ", b, d,e);
            Console.WriteLine("");
            Console.WriteLine("Would You Like To..");
            Console.WriteLine("1.Return To Main Menu");
            Console.WriteLine("2.Exit Our App");
            string f=Console.ReadLine();
            double g=double.Parse(f);
            if (g == 1)
            {   
                Console.Clear();
                Main(null);
            }
            else if(g == 2)
            {
                Environment.Exit(0);
            }
        }
        public static void Subtraction()
        {
            Console.WriteLine("enter your first operand ..( Number To Be Subtracted )");
            string a = Console.ReadLine();
            double b = double.Parse(a);
            Console.WriteLine("enter your second operand .. ( Subtractor )");
            string c = Console.ReadLine();
            double d = double.Parse(c);
            double e = b - d;
            Console.WriteLine("result of {0} - {1} = {2} ", b, d, e);
            Console.WriteLine("");
            Console.WriteLine("Would You Like To..");
            Console.WriteLine("1.Return To Main Menu");
            Console.WriteLine("2.Exit Our App");
            string f = Console.ReadLine();
            double g = double.Parse(f);
            if (g == 1)
            {
                Console.Clear();
                Main(null);
            }
            else if (g == 2)
            {
                Environment.Exit(0);
            }
        }
        public static void Multiplication()
        {
            Console.WriteLine("enter your first operand");
            string a = Console.ReadLine();
            double b = double.Parse(a);
            Console.WriteLine("enter your second operand");
            string c = Console.ReadLine();
            double d = double.Parse(c);
            double e = b * d;
            Console.WriteLine("result of {0} * {1} = {2} ", b, d, e);
            Console.WriteLine("");
            Console.WriteLine("Would You Like To..");
            Console.WriteLine("1.Return To Main Menu");
            Console.WriteLine("2.Exit Our App");
            string f = Console.ReadLine();
            double g = double.Parse(f);
            if (g == 1)
            {
                Console.Clear();
                Main(null);
            }
            else if (g == 2)
            {
                Environment.Exit(0);
            }
        }
        public static void Division()
        {
            Console.WriteLine("enter your first operand..( Number To Be Divided )");
            string a = Console.ReadLine();
            double b = double.Parse(a);
            Console.WriteLine("enter your second operand..( Divider )");
            string c = Console.ReadLine();
            double d = double.Parse(c);
            double e = b / d;
            if (d != 0)
            {
                Console.WriteLine("result of {0} / {1} = {2} ", b, d, e);
                Console.WriteLine("");
            }
            else {
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine(" ERROR!!  DIVISION BY 0 IMPOSSIBLE"); }
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Would You Like To..");
            Console.WriteLine("1.Return To Main Menu");
            Console.WriteLine("2.Exit Our App");
            string f = Console.ReadLine();
            double g = double.Parse(f);
            if (g == 1)
            {
                Console.Clear();
                Main(null);
            }
            else if (g == 2)
            {
                Environment.Exit(0);
            }
        }
        public static void Main(string[] args)
        {
            Console.WriteLine("");
            Console.WriteLine("                 ******************        ");
            Console.WriteLine("WELCOME TO OUR CONSOLE CALCULATOR...");
            Console.WriteLine("");
            Console.WriteLine("1.ADDITION");
            Console.WriteLine("2.SUBTRACTION");
            Console.WriteLine("3.MULTIPLICATION");
            Console.WriteLine("4.DIVISION");
            Console.WriteLine("");
            Console.WriteLine("     **PRESS 0 TO EXIT APP**    ");
            Console.WriteLine("");
            Console.WriteLine("pick your choice..(Choose 1 To 4 Respectively)");
            string Pick = Console.ReadLine();
            double Picked = double.Parse(Pick);
            if (!(Picked < 0 || Picked > 4))
            {
                if (Picked == 1)
                {
                    Console.Clear();
                    Addition();
                }
                else if (Picked == 2)
                {
                    Console.Clear();
                    Subtraction();
                }
                else if (Picked == 3)
                {
                    Console.Clear();
                    Multiplication();
                }
                else if (Picked == 4)
                {
                    Console.Clear();
                    Division();
                }
                else if (Picked == 0)
                {
                    Environment.Exit(0);
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("********************ENTER A VALUE BETWEEN 1 AND 4 *****************");
                Main(null);
            }
        }
    }
}