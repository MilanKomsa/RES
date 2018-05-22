using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RESProjekat
{
    public class Writer
    {
        private List<Tuple<Code.CodeSpisak,int>> tempLista;
        private Code.CodeSpisak code;
        private int value;
        public static Object thisLock = new Object();
        public Writer()
        {
            tempLista = new List<Tuple<RESProjekat.Code.CodeSpisak, int>>();

        }

        public int Value { get => value; set => this.value = value; }
        internal Code.CodeSpisak Code { get => code; set => code = value; }
        internal List<Tuple<Code.CodeSpisak, int>> TempLista { get => tempLista; set => tempLista = value; }

        public void Prosledi()
        {
            while (true)
            {
                lock (thisLock)
                {
                    foreach (var s in tempLista)
                    {
                        ReplicatorSender.l.Add(s);
                        //tempLista.Remove(s);
                    }
                    tempLista.Clear();
                    Thread.Sleep(2000);
                }
            }
        }
    }
}
