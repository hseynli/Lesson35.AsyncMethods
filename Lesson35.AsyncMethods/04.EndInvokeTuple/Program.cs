using System;
using System.Threading;

namespace AsynchronousProgramming
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Func<int, int, (int, int)> myDelegate = new Func<int, int, (int, int)>(Sum);

            // İlk iki arqument Sum(1, 2) metodunun arqumentləridir.
            IAsyncResult asyncResult = myDelegate.BeginInvoke(1, 2, null, null);

            // Asinxron əməliyyatdan alınan nəticə.
            (int plus, int minus) = myDelegate.EndInvoke(asyncResult);

            Console.WriteLine("Addition = " + plus);
            Console.WriteLine("Subtraction = " + minus);

            // Delay
            Console.ReadKey();
        }

        static (int plus, int minus) Sum(int a, int b)
        {
            return (a + b, a - b);
        }
    }
}
