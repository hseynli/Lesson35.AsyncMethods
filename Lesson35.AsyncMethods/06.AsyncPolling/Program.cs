using System;
using System.Threading;

namespace AsynchronousProgramming
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Func<int, int, int> myDelegate = new Func<int, int, int>(Sum);

            IAsyncResult asyncResult = myDelegate.BeginInvoke(1, 2, null, null);

            Console.WriteLine("Asinxron metod işə düşdü. Main metodu işinə davam edir.");

            // Asinxron əməliyyat işini davam edənə kimi dövrü icra etmək.
            while (!asyncResult.IsCompleted)
            {
                Thread.Sleep(100);
                Console.Write(".");
            }

            // Asinxron əməliyyatdan nəticəni əldə etmək.
            int result = myDelegate.EndInvoke(asyncResult);

            Console.WriteLine("\nNəticə = " + result);

            // Delay
            Console.ReadKey();
        }

        // Ayrıca thread-da icra olunacaq metod.
        static int Sum(int a, int b)
        {
            Thread.Sleep(3000);
            return a + b;
        }
    }
}
