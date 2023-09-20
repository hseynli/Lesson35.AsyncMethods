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
            Console.WriteLine("Main metodu asinxron metodun işini bitirməsini gözləyir.");

            Console.WriteLine(asyncResult.AsyncWaitHandle.GetType()); // Sinxronizasiya obyekti hansı tipdədir?            
            asyncResult.AsyncWaitHandle.WaitOne(); // Əsas thread-in işini saxlamaq.

            Console.WriteLine("Asinron metod işə düşdü. Main metodu işinə davam edir.");

            // Asinxron əməliyyatdan nəticəni əldə etmək.
            int result = myDelegate.EndInvoke(asyncResult);
            Console.WriteLine("Nəticə = " + result);

            // Delay
            Console.ReadKey();
        }

        // Метод для выполнения в отдельном потоке.
        static int Sum(int a, int b)
        {
            Thread.Sleep(3000);
            return a + b;
        }
    }
}
