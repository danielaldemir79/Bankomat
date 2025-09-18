namespace Bankomat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            const int pinkod = 1234;
            const int antalFörsök = 3;

            Console.WriteLine("Välkommen till Bankomaten!");
            Console.WriteLine();

            bool inloggad = LoggaIn(pinkod, antalFörsök);
            
            if (!inloggad)
            {
                Console.WriteLine("Du har misslyckats med inloggningen. Programmet avslutas.");
                return;
            
            }
            
            Console.WriteLine();
            

            
            int val = 0;

            while (val != 4)
            {

                ShowMenu();
                val = GetInt();

                switch (val)
                {
                    case 1:
                        Console.WriteLine("Du har valt att sätta in pengar.");
                        break;

                    case 2:
                        Console.WriteLine("Du har valt att ta ut pengar.");
                        break;

                    case 3:
                        Console.WriteLine("Du har valt att visa saldo.");
                        break;

                    case 4:
                        Console.WriteLine("Du har valt att avsluta.");
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
            Console.WriteLine("4. Avsluta");
            Console.WriteLine();
        }

        static bool LoggaIn(int pinKod, int antalFörsök)
        {
            int försökKvar = antalFörsök;
            while (försökKvar > 0)
            {
                Console.WriteLine("Ange din pinkod: ");
                int angivenKod = GetInt();
                if (angivenKod == pinKod)
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


        public static int GetInt()
        {
            int helTal;

            while (!int.TryParse(Console.ReadLine(), out helTal))
            {
                Console.WriteLine("Du har angett ett felaktig format");
            }

            return helTal;

        }
    
    }
}
