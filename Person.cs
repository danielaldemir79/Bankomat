using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat
{
    internal class Person
    {
        public string Name { get; }
        public int Personnummer { get; }
        public Person(string name, int personummer)
        {
            Name = name;
            Personnummer = personummer;
        }
    }
}
