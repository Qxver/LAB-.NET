using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Generic;

namespace Zadanie_04
{
    public static class PersonRepository
    {
        public static List<Person> People = new List<Person>();

        public static void Add(Person person)
        {
            People.Add(person);
        }
    }
}
