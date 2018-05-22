using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RESProjekat
{
    public class Program
    {
        
        static void Main(string[] args)
        {

            string s = "as";
            while (s != "2")
            {
                Console.WriteLine("Meni: ");
                Console.WriteLine("1. Otvori Writer");
                Console.WriteLine("2. Izadji!");

                s = Console.ReadLine();
                switch (s)
                {
                    case "1":
                        Writer w = new Writer();
                        OtvaranjeWritera(w);
                        Thread t = new Thread(w.Prosledi);
                        t.Start();
                        break;
                    case "2":
                       continue;
                }
                lock (Writer.thisLock)
                {
                    foreach (var k in ReplicatorSender.l)
                    {
                        Console.WriteLine(k.Item1.ToString());
                    }
                    Console.ReadLine();
                }
            }

        }

        public static void OtvaranjeWritera(Writer w)
        {

            string q = "";




            while (true)
            {
                Console.WriteLine("Izaberi code: \n");
                Console.WriteLine("1. CODE_ANALOG\n");
                Console.WriteLine("2. CODE_DIGITAL\n");
                Console.WriteLine("3. CODE_CUSTOM\n");
                Console.WriteLine("4. CODE_LIMITSET\n");
                Console.WriteLine("5. CODE_SINGLENOE\n");
                Console.WriteLine("6. CODE_MULTIPLENODE\n");
                Console.WriteLine("7. CODE_CONSUMER\n");
                Console.WriteLine("8. CODE_SOURCE\n");
                Console.WriteLine("Za izlaz pritisni x");
                q = Console.ReadLine();

                switch (q)
                {
                    case "1":
                        w.Code = Code.CodeSpisak.CODE_ANALOG;
                        break;
                    case "2":
                        w.Code = Code.CodeSpisak.CODE_DIGITAL;
                        break;
                    case "3":
                        w.Code = Code.CodeSpisak.CODE_CUSTOM;
                        break;
                    case "4":
                        w.Code = Code.CodeSpisak.CODE_LIMITSET;
                        break;
                    case "5":
                        w.Code = Code.CodeSpisak.CODE_SINGLENOE;
                        break;
                    case "6":
                        w.Code = Code.CodeSpisak.CODE_MULTIPLENODE;
                        break;
                    case "7":
                        w.Code = Code.CodeSpisak.CODE_CONSUMER;
                        break;
                    case "8":
                        w.Code = Code.CodeSpisak.CODE_SOURCE;
                        break;
                    case "x":
                        break;
                    default:
                        break;
                }
                if (q == "x")
                {
                    break;
                }
                Console.Clear();
                Console.WriteLine("Za izlaz pritisni x");
                Console.Write("Unesite vrednost(celobrojni broj): ");

                string f = Console.ReadLine();

                if (f == "x")
                {
                    break;
                }

                Int32.TryParse(f, out int i);
                w.Value = i;
                Tuple<Code.CodeSpisak, int> t = new Tuple<Code.CodeSpisak, int>(w.Code, w.Value);
                w.TempLista.Add(t);

                Console.Clear();
            }


        }
    }
}
