using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat
{
    internal class BankAccount
    {
        private decimal balance;  // Privat fält för kontosaldo
        public decimal Balance { get {return balance;} } // Publik egenskap för att läsa saldot
        public BankAccount(decimal yourBalance) // Konstruktor som tar ett startvärde för saldot
        {
            balance = yourBalance;

        }


    public decimal GetBalance() // Metod för att hämta saldot
        {
            return Balance;
           
        }

        
        
        public void Deposit(decimal amount) // Metod för att sätta in pengar
        {
            if (amount <= 0) // Kontrollera att beloppet är större än noll. Om inte, visa felmeddelande.
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Beloppet måste vara större än noll.");
                Console.ResetColor();

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Tryck på valfri tangent för att fortsätta...");
                Console.ResetColor();
                Console.ReadKey();
                Console.Clear();
                return;
            }

            balance += amount; // Lägg till beloppet till saldot om det är giltigt.

            Console.WriteLine();
            Console.WriteLine($"Du har satt in {amount:C2}. Ditt nya saldo är {Balance:C2}.");
            Console.WriteLine();
            Console.ForegroundColor= ConsoleColor.Green;
            Console.WriteLine("Tryck på valfri tangent för att fortsätta...");
            Console.ResetColor();
            Console.ReadKey();
            Console.Clear();
        }
       
        
        
        
        public void Withdraw(decimal amount) // Metod för att ta ut pengar
        {
            if (amount <= 0) // Kontrollera att beloppet är större än noll. Om inte, visa felmeddelande.
            {
               Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Beloppet måste vara större än noll.");
                Console.ResetColor();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Tryck på valfri tangent för att fortsätta...");
                Console.ResetColor();
                Console.ReadKey();
                Console.Clear();
                return;
            }
            if (amount > balance) // Kontrollera att det finns tillräckligt med saldo. Om inte, visa felmeddelande.
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Otillräckligt saldo.");
                Console.ResetColor();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Tryck på valfri tangent för att fortsätta...");
                Console.ResetColor();
                Console.ReadKey();
                Console.Clear();
                return;
            }
            balance -= amount; // Dra av beloppet från saldot om det är giltigt.
            Console.WriteLine($"Du har tagit ut {amount:C2}. Ditt nya saldo är {Balance:C2}.");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Tryck på valfri tangent för att fortsätta...");
            Console.ResetColor();
            Console.ReadKey();
            Console.Clear();

        }
    
    
    }
}