using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RESProjekat;
using System.Threading;

namespace Writer1
{
    class Program
    {
        static void Main(string[] args)
        {
            Writer w = new Writer();

            string s;
            Console.WriteLine("Za izlaz pritisnite x");
            while (true)
            {
                Console.WriteLine("Unesite vrednost:");
                w.S = Console.ReadLine();
                s = w.S;

                ReplicatorSender.l.Add(s);

                if (s == "x")
                {
                    Console.Beep();
                    return;
                }
                Thread.Sleep(2000);

            }
        }
    }
}
