using System;
using System.Collections;
using System.Collections.Generic;

namespace Zadanie_07
{
    public class NumberRange : IEnumerable<int>
    {
        private readonly int _start;
        private readonly int _end;

        public NumberRange(int start, int end)
        {
            _start = start;
            _end = end;
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = _start; i <= _end; i++)
            {
                yield return i;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    class Program
    {
        static void Main()
        {
            // Tworzymy nasz własny obiekt - zakres liczb od 1 do 25
            NumberRange range = new NumberRange(1, 25);

            Console.WriteLine("Liczby z podanego zakresu:");
            Console.WriteLine("-------------------------");

            foreach (int number in range)
            {
                Console.WriteLine($"Liczba: {number}");
            }
        }
    }
}