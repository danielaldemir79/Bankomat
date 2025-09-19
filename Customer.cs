using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat
{
    internal class Customer
    {
        public Person Person { get; }
        public BankAccount Account { get; }
        private int pinCode;
        public int PinCode
        {
            get => pinCode;
            set
            {
                if (value >= 1000 && value <= 9999)
                    pinCode = value;
                else
                    throw new ArgumentException("PIN-koden måste vara exakt 4 siffror.");
            }
        }

        public Customer(string name, string personnummer)
        {
            Person = new Person(name, personnummer);
            PinCode = 1234; // Tillfällig pinkod
            Account = new BankAccount(1000m); // Startar med 0 kr på kontot
        }
    }
}
