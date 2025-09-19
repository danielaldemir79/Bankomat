namespace Bankomat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            const int antalFörsök = 3;

            var Customer1 = new Customer("Elin Aldemir", "19830729-7423"); // Skapar en kund med namn och personnummer


            Console.ForegroundColor = ConsoleColor.Green;   // Välkommen meny
            Console.WriteLine("******************************");
            Console.WriteLine("  *       BANKOMAT        *");
            Console.WriteLine($"         Välkommen");
            Console.WriteLine("******************************");

            bool inloggad = LoggaIn(Customer1, antalFörsök);    // Anropar inloggningsmetoden

            if (!inloggad) // Om inloggningen misslyckas
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Du har misslyckats med inloggningen. Programmet avslutas.");
                Console.ResetColor();
                return;

            }

            // Inloggningen lyckades
            Console.ForegroundColor= ConsoleColor.Blue;
            Console.WriteLine();    
            Console.WriteLine($"Välkommen {Customer1.Person.Name}, {Customer1.Person.Personnummer}");
            Console.ResetColor();
            Console.WriteLine();
            

            
            int val = 0;

            while (val != 5)  //    Avsluta programmet vid val 5
            {

                ShowMenu();
                val = GetInt();

                switch (val) // Hanterar menyvalen
                {
                    case 1:                 // Insättning. Anropar Deposit-metoden i BankAccount-klassen
                        Console.Clear();
                        Console.ForegroundColor= ConsoleColor.Green;
                        Console.WriteLine("INSÄTTNING");
                        Console.ResetColor();
                        Console.WriteLine();
                        Console.WriteLine($"Ditt saldo är {Customer1.Account.GetBalance():C2}");
                        Console.WriteLine();
                        Console.Write("Ange belopp att sätta in: ");
                        decimal deposit = GetDecimal();

                        Customer1.Account.Deposit(deposit);
                        break;

                    case 2:             // Uttag. Anropar Withdraw-metoden i BankAccount-klassen
                        Console.Clear();
                        Console.ForegroundColor= ConsoleColor.Green;
                        Console.WriteLine("UTTAG");
                        Console.ResetColor();
                        Console.WriteLine();
                        Console.WriteLine($"Ditt saldo är {Customer1.Account.GetBalance():C2}");
                        Console.WriteLine();
                        Console.Write("Ange belopp att ta ut: ");
                        decimal withdraw = GetDecimal();

                        Customer1.Account.Withdraw(withdraw);
                        break;

                    case 3:         // Visa saldo. Anropar GetBalance-metoden i BankAccount-klassen
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine($"Ditt saldo är {Customer1.Account.GetBalance():C2}");
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Tryck på valfri tangent för att fortsätta...");
                        Console.ResetColor();
                        Console.ReadKey();
                        break;

                    case 4:        // Ändra pinkod. Verifierar att pinkoden är exakt 4 siffror och att bekräftelsekoden matchar.
                        Console.Clear();
                        Console.WriteLine("Du har valt att ändra din pinkod.");

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Mata in ditt befintliga pinkod");
                        Console.ResetColor();
                        int currentPin = GetInt();              // Ändring får enbart ske vid inmatning aav aktuell pin först
                        if (currentPin != Customer1.PinCode)    // Felaktig pin hanteras här. Man får då inte ändra pin.
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Felaktig pinkod.");
                            Console.ResetColor();
                            Console.WriteLine();
                            Console.WriteLine("Tryckk på valfri tangent för att fortsätta...");
                            Console.ReadKey();
                            break;
                        }
                        Console.Write("Ange ny pinkod (4 siffror): "); // Ange ny pin.  
                        int newPin = GetInt();
                        
                        if (newPin.ToString().Length == 4) // Kollar att pinkoden är exakt 4 siffror lång
                        {
                            Console.WriteLine("Bekräfta din nya pinkod med att mata in den igen.");
                            int confirmPin = GetInt();

                            if (confirmPin == newPin) // Bekräftelsekoden matchar
                            {
                                Customer1.PinCode = newPin; // Ändrar pinkoden

                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Din pinkod har ändrats.");
                                Console.ResetColor();
                                Console.WriteLine();
                                Console.WriteLine("Tryckk på valfri tangent för att fortsätta...");
                                Console.ReadKey();
                                break;
                            }
                            else // Bekräftelsekoden matchar inte
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("De inmatade pinkoderna matchar inte.");
                                Console.ResetColor();
                                Console.WriteLine();
                                Console.WriteLine("Tryckk på valfri tangent för att fortsätta...");
                                Console.ReadKey();
                            }

                        }
                        else // Felaktig längd på pinkod
                        {
                            Console.ForegroundColor= ConsoleColor.Red;
                            Console.WriteLine("Pinkoden måste vara exakt 4 siffror lang.");
                            Console.ResetColor();
                            Console.WriteLine();
                            Console.WriteLine("Tryckk på valfri tangent för att fortsätta...");
                            Console.ReadKey();
                        }
                        break;


                         case 5: // Avsluta
                            Console.ForegroundColor= ConsoleColor.Yellow;
                            Console.WriteLine("Du är nu utloggad");
                            Console.WriteLine("Välkommen åter!");
                            Console.ResetColor();
                        break;

                         default: // Felaktigt val
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Du har angett felaktigt val");
                            Console.ResetColor();
                            break;



                }


            }


           

        }




        static void ShowMenu()  //  Visar menyn
        {
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("*****************************");
            Console.WriteLine("*         BANKOMAT         *");
            Console.WriteLine("*         LINKÖPING        *");
            Console.WriteLine("*****************************");
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


        public static int GetInt()  //  Hämtar heltalsvärde och hanterar felaktig inmatning
        {
            int helTal;

            while (!int.TryParse(Console.ReadLine(), out helTal))
            {
                Console.ForegroundColor= ConsoleColor.Red;
                Console.WriteLine("Du har angett ett felaktigt format");
                Console.ResetColor();
                Console.Write("Försök igen: ");
            }
            
            return helTal;

        }

        public static decimal GetDecimal()  //  Hämtar decimalvärde och hanterar felaktig inmatning
        {
            decimal tal;

            while (!decimal.TryParse(Console.ReadLine(), out tal))
            {
                Console.ForegroundColor= ConsoleColor.Red;
                Console.WriteLine("Du har angett ett felaktigt format");
                Console.ResetColor();
                Console.Write("Försök igen: ");
            }
            
            return tal;

        }

        public static bool LoggaIn(Customer customer, int antalFörsök)
        {
            int försökKvar = antalFörsök;
            while (försökKvar > 0) // Loopa tills antalet försök är slut. Skulle funka smidigare med en FOR loop men vi låter detta vara denna gång :)
            {
                Console.ForegroundColor= ConsoleColor.Yellow;
                Console.Write("Ange din pinkod: ");
                int angivenKod = GetInt();
                Console.ResetColor();
                if (angivenKod == customer.PinCode) // Koden är korrekt
                {
                    Console.ForegroundColor= ConsoleColor.Green;
                    Console.WriteLine();
                    Console.Clear();
                    Console.WriteLine("Inloggning lyckades!");
                    Console.ResetColor();
                    return true;
                }
                else
                {
                    försökKvar--;  //   Minskar antalet försök kvar
                    Console.WriteLine();
                    Console.ForegroundColor= ConsoleColor.Red;
                    
                    if (försökKvar != 0)  // Visar inte denan rad vid sista försöket för att undvika onödig information
                    {
                      Console.WriteLine($"Felaktig pinkod. Du har {försökKvar} försök kvar.");
                    }
                   
                    Console.ResetColor();
                }
            }

            return false;
        
        }

     }
}
