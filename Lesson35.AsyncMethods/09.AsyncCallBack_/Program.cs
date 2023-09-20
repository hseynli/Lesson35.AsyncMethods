using System;
using System.Threading;
using System.Runtime.Remoting.Messaging;

namespace AsynchronousProgramming
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Əsas thread: Id {0}", Thread.CurrentThread.ManagedThreadId);

            Func<int, int, int> func = new Func<int, int, int>(Sum);

            func.BeginInvoke(1, 2, CallBack, "a + b = {0}");

            Console.WriteLine("Əsas thread işini bitirdi.");

            // Delay
            Console.ReadKey();
        }

        // Ayrıca thread-da icra olunacaq metod.
        static int Sum(int a, int b)
        {
            // Thread.CurrentThread.IsBackground = false;

            Console.WriteLine("İkinci thread: Id {0}", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(3000);
            return a + b;
        }

        // CallBack metod
        static void CallBack(IAsyncResult asyncResult)
        {
            // İcra olunan asinxron əməliyyatın instance-nın alınması.
            AsyncResult ar = asyncResult as AsyncResult;
            Func<int, int, int> caller = (Func<int, int, int>)ar.AsyncDelegate;

            // Asinxron əməliyyatın nəticəsinin əldə edilməsi.
            int sum = caller.EndInvoke(asyncResult);

            string result = string.Format(asyncResult.AsyncState.ToString(), sum);
            Console.WriteLine("Asinxron əməliyyatın nəticəsi: " + result);
        }
    }
}
