using System;
using System.Threading;

namespace Zadanie_05
{
    public class ArraySearcher
    {
        private readonly int[] _array;
        private readonly int _startIndex;
        private readonly int _endIndex;

        public int LocalMax { get; private set; }
        public int LocalMin { get; private set; }

        public ArraySearcher(int[] array, int startIndex, int endIndex)
        {
            _array = array;
            _startIndex = startIndex;
            _endIndex = endIndex;

            LocalMax = int.MinValue;
            LocalMin = int.MaxValue;
        }

        public void Find()
        {
            for (int i = _startIndex; i < _endIndex; i++)
            {
                if (_array[i] > LocalMax) LocalMax = _array[i];
                if (_array[i] < LocalMin) LocalMin = _array[i];
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int arraySize = 10_000_000;
            int[] numbers = new int[arraySize];
            Random rand = new Random();

            Console.WriteLine("\nTablica 10.000.000 elementow");
            Console.WriteLine("Generowanie danych...");
            for (int i = 0; i < arraySize; i++)
            {
                numbers[i] = rand.Next(-10_000_000, 10_000_000);
            }



            int threadCount = Environment.ProcessorCount;
            Console.WriteLine($"\nWyszukiwanie przy użyciu {threadCount} wątków...");

            Thread[] threads = new Thread[threadCount];
            ArraySearcher[] searchers = new ArraySearcher[threadCount];

            int chunkSize = arraySize / threadCount;

            for (int i = 0; i < threadCount; i++)
            {
                int start = i * chunkSize;
                int end = (i == threadCount - 1) ? arraySize : start + chunkSize;

                searchers[i] = new ArraySearcher(numbers, start, end);

                threads[i] = new Thread(searchers[i].Find);
                threads[i].Start();
            }

            foreach (Thread t in threads)
            {
                t.Join();
            }

            int globalMax = int.MinValue;
            int globalMin = int.MaxValue;

            foreach (var searcher in searchers)
            {
                if (searcher.LocalMax > globalMax) globalMax = searcher.LocalMax;
                if (searcher.LocalMin < globalMin) globalMin = searcher.LocalMin;
            }

            Console.WriteLine("\n--- WYNIKI ---");
            Console.WriteLine($"Najmniejsza liczba: {globalMin}");
            Console.WriteLine($"Największa liczba:  {globalMax}");
        }
    }
}