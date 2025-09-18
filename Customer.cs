using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat
{
    internal class Customer
    {
        public string Name { get; }
        public int Personnummer { get; }
       
        private int pinCode;
        public int PinCode
        {
            get { return pinCode; }
            set
            {
                // Kontrollera att PIN är exakt 4 siffror
                if (value >= 1000 && value <= 9999)
                    pinCode = value;
                else
                    throw new ArgumentException("PIN-koden måste vara exakt 4 siffror.");
            }
        }


        public Customer(string name, int personummer)
        {
            Name = name;
            Personnummer = personummer;
            PinCode = 1234; // Default PIN code, can be changed later
        }

       
        
    }
}
