namespace Bankomat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            const int antalFörsök = 3;

            decimal balance = 1000m;

            var Customer1 = new Customer("Kalle", 1234567890);
            var minPerson = new Person("Kalle", 1234567890);
            var mittKonto = new BankAccount(balance);
         
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("****************************");
            Console.WriteLine("*         BANKOMAT       *");
            Console.WriteLine($"      Välkommen {minPerson.Name}!");
            Console.WriteLine("****************************");
            Console.ResetColor();
            Console.WriteLine();

            bool inloggad = LoggaIn(Customer1, antalFörsök);
            
            if (!inloggad)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Du har misslyckats med inloggningen. Programmet avslutas.");
                Console.ResetColor();
                return;

            }
          

                Console.WriteLine();
            

            
            int val = 0;

            while (val != 5)
            {

                ShowMenu();
                val = GetInt();

                switch (val)
                {
                    case 1:
                        Console.Clear();
                        Console.ForegroundColor= ConsoleColor.Green;
                        Console.WriteLine("INSÄTTNING");
                        Console.ResetColor();
                        Console.WriteLine();
                        Console.WriteLine($"Ditt saldo är {mittKonto.GetBalance()}");
                        Console.WriteLine();
                        Console.Write("Ange belopp att sätta in: ");
                        decimal deposit = GetDecimal();
                        mittKonto.Deposit(deposit);
                        break;

                    case 2:
                        Console.Clear();
                        Console.ForegroundColor= ConsoleColor.Green;
                        Console.WriteLine("UTTAG");
                        Console.ResetColor();
                        Console.WriteLine();
                        Console.WriteLine($"Ditt saldo är {mittKonto.GetBalance()}");
                        Console.WriteLine();
                        Console.Write("Ange belopp att ta ut: ");
                        decimal withdraw = GetDecimal();
                        mittKonto.Withdraw(withdraw);
                        break;

                    case 3:
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine($"Ditt saldo är {mittKonto.GetBalance()}");
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Tryck på valfri tangent för att fortsätta...");
                        Console.ResetColor();
                        Console.ReadKey();
                        break;

                    case 4: 
                        Console.Clear();
                        Console.WriteLine("Du har valt att ändra din pinkod.");
                        Console.Write("Ange ny pinkod (4 siffror): ");
                        int newPin = GetInt();
                        
                        if (newPin.ToString().Length == 4)
                        {
                            Customer1.PinCode = newPin;
                            Console.WriteLine();
                            Console.ForegroundColor= ConsoleColor.Green;
                            Console.WriteLine("Din pinkod har ändrats.");
                            Console.ResetColor();
                            Console.WriteLine();
                            Console.WriteLine("Tryckk på valfri tangent för att fortsätta...");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.ForegroundColor= ConsoleColor.Red;
                            Console.WriteLine("Pinkoden måste vara exakt 4 siffror lång.");
                            Console.ResetColor();
                            Console.WriteLine();
                            Console.WriteLine("Tryckk på valfri tangent för att fortsätta...");
                            Console.ReadKey();
                        }
                        break;
                    
                    case 5:
                        Console.WriteLine("Du är nu utloggad");
                        Console.WriteLine("Välkommen åter!");
                        break;

                    default:
                        Console.ForegroundColor= ConsoleColor.Red;
                        Console.WriteLine("Du har angett felaktigt val");
                        Console.ResetColor();
                        break;
                }
            }
           



        }

        
       
        static void ShowMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("****************************");
            Console.WriteLine("*         BANKOMAT         *");
            Console.WriteLine("*         LINKÖPING        *");
            Console.WriteLine("****************************");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("Välj ett av följande alternativ:");
            Console.WriteLine();
            Console.WriteLine("1. Sätt in pengar");
            Console.WriteLine("2. Ta ut pengar");
            Console.WriteLine("3. Visa saldo");
            Console.WriteLine("4. Ändra din pinkod");
            Console.WriteLine("5. Avsluta");
            Console.WriteLine();
        }



        public static int GetInt()
        {
            int helTal;

            while (!int.TryParse(Console.ReadLine(), out helTal))
            {
                Console.WriteLine("Du har angett ett felaktigt format");
            }

            return helTal;

        }

        public static decimal GetDecimal()
        {
            decimal tal;

            while (!decimal.TryParse(Console.ReadLine(), out tal))
            {
                Console.WriteLine("Du har angett ett felaktigt format");
            }

            return tal;

        }

        public static bool LoggaIn(Customer customer, int antalFörsök)
        {
            int försökKvar = antalFörsök;
            while (försökKvar > 0)
            {
                Console.Write("Ange din pinkod: ");
                int angivenKod = GetInt();
                if (angivenKod == customer.PinCode)
                {
                    Console.ForegroundColor= ConsoleColor.Green;
                    Console.WriteLine();
                    Console.WriteLine("Inloggning lyckades!");
                    Console.ResetColor();
                    return true;
                }
                else
                {
                    försökKvar--;
                    Console.WriteLine();
                    Console.ForegroundColor= ConsoleColor.Red;
                    Console.WriteLine($"Felaktig pinkod. Du har {försökKvar} försök kvar.");
                    Console.ResetColor();
                }
            }

            return false;
        
        }

     }
}
