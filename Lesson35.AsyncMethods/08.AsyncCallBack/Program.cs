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

            Action action = new Action(Method);

            // Asinxron əməliyyat işini bitirdikdən sonra icra olunacaq metod.
            AsyncCallback callback = new AsyncCallback(CallBack);

            // Arqumentlər: 
            // 1. Asinxron əməliyyat işini bitirdikdən sonra icra olunmalı olan call back metod.
            // 2. CallBack metod işə düşdükdən sonra ona ötürə biləcəyimiz obyekt.
            action.BeginInvoke(callback, "Hello world!");

            Console.WriteLine("Əsas thread işinə davam edir.");

            // Delay
            Console.ReadKey();
        }

        // Ayrıca thread-da işləyəcək metod.
        static void Method()
        {
            Console.WriteLine("\nİkinci thread: Id {0}", Thread.CurrentThread.ManagedThreadId);

            for (int i = 0; i < 80; i++)
            {
                Thread.Sleep(20);
                Console.Write(".");
            }

            Console.WriteLine("İkinci thread işini bitirdi.\n");
        }

        // Asinxron əməliyyat işini bitirdikdən sonra işə düşəcək Callback metod.
        static void CallBack(IAsyncResult asyncResult)
        {
            Console.WriteLine("Callback metod. Thread Id {0}", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Asinxron əməliyyatla bağlı olan informasiya - " + asyncResult.AsyncState);
        }
    }
}
