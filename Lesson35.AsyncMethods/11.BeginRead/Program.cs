using System;
using System.IO;

namespace AsynchronousProgramming
{
    class Program
    {
        static void Main()
        {
            Stream stream = new FileStream("file.txt", FileMode.Open, FileAccess.Read);

            byte[] array = new byte[stream.Length];

            // file.txt faylından bütün baytları oxuyan sinxron metod.
            //stream.Read(array, 0, array.Length);

            // Faylın baytlarını oxuyan asinxron metod.
            IAsyncResult asyncResult = stream.BeginRead(array, 0, array.Length, null, null);

            Console.WriteLine("Faylın oxunması...");

            // Faylın oxunmasını gözləmək.
            stream.EndRead(asyncResult);

            foreach (byte item in array)
                Console.Write(item + " ");

            stream.Close();

            // Delay
            Console.ReadKey();
        }
    }
}
