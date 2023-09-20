using System;
using System.Threading;

namespace AsynchronousProgramming
{
    class Program
    {
        // Ayrıca thread-da işə düşəcək metod.
        static int Sum(int a, int b)
        {
            //Thread.CurrentThread.IsBackground = false;

            Console.WriteLine("İkinci thread: Id {0}", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(3000);
            return a + b;
        }

        // CallBack metod.
        static void CallBack(IAsyncResult asyncResult)
        {            
            Func<int, int, int> caller = (asyncResult.AsyncState as Func<int, int, int>);

            // Asinxron əməliyyatın nəticəsinin əldə edilməsi.
            int sum = caller.EndInvoke(asyncResult);

            Console.WriteLine("a + b = {0}", sum);
        }

        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Əsas thread: Id {0}", Thread.CurrentThread.ManagedThreadId);

            Func<int, int, int> func = new Func<int, int, int>(Sum);

            func.BeginInvoke(1, 2, CallBack, func);

            Console.WriteLine("Əsas thread işini bitirdi.");

            // Delay
            Console.ReadKey();
        }
    }
}
