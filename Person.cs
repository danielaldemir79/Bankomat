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
        public float Personnummer { get; }


        public Person(string name, float personnummer)
        {
            Name = name;
            Personnummer = personnummer;
        }
    }
}
