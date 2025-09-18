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
         

            Console.WriteLine($"Välkommen {minPerson.Name} till Bankomaten!");
            Console.WriteLine();

            bool inloggad = LoggaIn(Customer1, antalFörsök);
            
            if (!inloggad)
            {
                Console.WriteLine("Du har misslyckats med inloggningen. Programmet avslutas.");
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
                        Console.WriteLine("Du har valt att sätta in pengar.");
                        Console.WriteLine($"Ditt saldo är {mittKonto.GetBalance()}");
                        Console.WriteLine();
                        Console.Write("Ange belopp att sätta in: ");
                        decimal deposit = GetDouble();
                        mittKonto.Deposit(deposit);
                        break;

                    case 2:
                        Console.WriteLine("Du har valt att ta ut pengar.");
                        Console.WriteLine($"Ditt saldo är {mittKonto.GetBalance()}");
                        Console.WriteLine();
                        Console.Write("Ange belopp att ta ut: ");
                        decimal withdraw = GetDouble();
                        mittKonto.Withdraw(withdraw);
                        break;

                    case 3:
                        Console.WriteLine("Du har valt att visa saldo.");
                        Console.WriteLine($"Ditt saldo är {mittKonto.GetBalance()}");
                        break;

                    case 4: 
                        Console.WriteLine("Du har valt att ändra din pinkod.");
                        Console.Write("Ange ny pinkod (4 siffror): ");
                        int newPin = GetInt();
                        
                        if (newPin.ToString().Length == 4)
                        {
                            Customer1.PinCode = newPin;
                            Console.WriteLine("Din pinkod har ändrats.");
                        }
                        else
                        {
                            Console.WriteLine("Pinkoden måste vara exakt 4 siffror lång.");
                        }
                        break;
                    
                    case 5:
                        Console.WriteLine("Du har valt att avsluta.");
                        Console.WriteLine("Välkommen åter!");
                        break;

                    default:
                        Console.WriteLine("Du har angett felaktigt val");
                        break;
                }
            }
           



        }

        
       
        static void ShowMenu()
        {
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

        public static int GetDouble()
        {
            int tal;

            while (!int.TryParse(Console.ReadLine(), out tal))
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
                Console.WriteLine("Ange din pinkod: ");
                int angivenKod = GetInt();
                if (angivenKod == customer.PinCode)
                {
                    Console.WriteLine();
                    Console.WriteLine("Inloggning lyckades!");
                    return true;
                }
                else
                {
                    försökKvar--;
                    Console.WriteLine();
                    Console.WriteLine($"Felaktig pinkod. Du har {försökKvar} försök kvar.");
                }
            }

            return false;
        
        }

     }
}
