namespace Bankomat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            const int pinkod = 1234;
            const int antalFörsök = 3;

            bool inloggad = LoggaIn(pinkod, antalFörsök);
            
            if (!inloggad)
            {
                Console.WriteLine("Du har misslyckats med inloggningen. Programmet avslutas.");
                return;
            
            }
            
            Console.WriteLine();
            Console.WriteLine("Välkommen till Bankomaten!");

        
        
        
        
        
        
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
                    Console.WriteLine("Inloggning lyckades!");
                    return true;
                }
                else
                {
                    försökKvar--;
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
