using System;
using System.Threading;

// Asinxron şablonda default olaraq IsBackground = true (Əsas thread işini bitirdikdə ikinci thread da işini bitirəcəkdir).
// IsBackground = false (Əsas thread ikinci thread-in işini bitirməsini gözləyir).

namespace AsynchronousProgramming
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Əsas thread işə başladı.");

            Action work = new Action(Procedure);
            work.BeginInvoke(new AsyncCallback(CallBack), work);

            Thread.Sleep(1000);
            Console.WriteLine("\nƏsas thread işini bitirdi.\n");
        }

        static void Procedure()
        {
            //Thread.CurrentThread.IsBackground = false; // Şərhə salmaq.

            Console.WriteLine("İkinci thread işə başladı.");

            for (int i = 0; i < 240; i++)
            {
                Thread.Sleep(20);
                Console.Write(".");
            }

            Console.WriteLine("\n İkinci thread işini bitirdi.");
        }

        static void CallBack(IAsyncResult asyncResult)
        {
            Action work = asyncResult.AsyncState as Action;

            if (work != null)
                work.EndInvoke(asyncResult);
        }
    }
}
