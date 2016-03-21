using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
namespace papa_mama
{
    class Program
    {
        class Output
        {
            string line;
            int repetitions;
            int interval;
            public static int messageAmount=0;
            public static object lo = new object();
            public Output(string _line, int _repetitions, int _interval)
            {
                line = _line;
                repetitions = _repetitions;
                interval = _interval;
            }
            public void OutFunction()
            {
                for (int i = 0; (i < repetitions)&&(messageAmount>0); i++)
                {
                    Thread.Sleep(interval);
                    lock (lo)
                    {
                        Console.WriteLine(line);
                        messageAmount--;
                    }
                }
            }

        }
        static void Main(string[] args)
        {
            int num=4;
            Output[]InfoObjects=new Output[num];
            Thread[]Threads=new Thread[num];
            Output.messageAmount = 30;
            for (int i = 0; i < num; i++)
            {
                InfoObjects[i] = new Output("Messege" + (i + 1), 5 + 2* i, (int)(100+100*Math.Pow(i,3)));
                Threads[i] = new Thread(InfoObjects[i].OutFunction);
            }
            for (int i = 0; i < num; i++)
            {
                Threads[i].Start();
            }
        }
    }
}
