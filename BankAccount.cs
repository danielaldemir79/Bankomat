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
        private decimal balance;
        
        public decimal Balance { get { return balance; } }
        public BankAccount(decimal yourBalance)
        {
            balance = yourBalance;
            

        }


    public decimal GetBalance()
        {
            return Balance;
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Beloppet måste vara större än noll.");
                return;
            }

            balance += amount;

            Console.WriteLine($"Du har satt in {amount} kr. Ditt nya saldo är {Balance} kr.");
        }
        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Beloppet måste vara större än noll.");
                return;
            }
            if (amount > balance)
            {
                Console.WriteLine("Otillräckligt saldo.");
                return;
            }
            balance -= amount;
            Console.WriteLine($"Du har tagit ut {amount} kr. Ditt nya saldo är {Balance} kr.");
            
        }
    
    
    }
}