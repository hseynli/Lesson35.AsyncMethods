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

            // İlk iki arqument Sum(1, 2) metodunun arqumentləridir.
            IAsyncResult asyncResult = myDelegate.BeginInvoke(1, 2, null, null);

            // Asinxron əməliyyatdan alınan nəticə.
            int result = myDelegate.EndInvoke(asyncResult);

            Console.WriteLine("Nəticə = " + result);

            // Delay
            Console.ReadKey();
        }

        static int Sum(int a, int b)
        {
            Thread.Sleep(2000);
            return a + b;
        }
    }
}
