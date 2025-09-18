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

        public Customer(string name, float personnummer)
        {
            Person = new Person(name, personnummer);
            Account = new BankAccount(1000m);
            PinCode = 1234; // Hårdkodad PIN
        }
    }
}
