using System;
using System.Threading;

namespace AsynchronousProgramming
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Əsas thread: Id {0}", Thread.CurrentThread.ManagedThreadId);

            Action myDelegate = new Action(Method);

            // Metodun asinxron çağırılması - Method (thread pooldan istifadə edərək).
            myDelegate.BeginInvoke(null, null); // Invoke() - sinxron çağırmaq. 

            for (int i = 0; i < 80; i++)
            {
                Thread.Sleep(100);
                Console.Write("1 ");
            }

            // Delay
            Console.ReadKey();
        }

        // Ayrıca thread-da icra olunacaq metod.
        static void Method()
        {
            Console.WriteLine("İkinci thread: Id {0}", Thread.CurrentThread.ManagedThreadId);

            for (int i = 0; i < 80; i++)
            {
                Thread.Sleep(100);
                Console.Write("2 ");
            }
        }
    }
}
