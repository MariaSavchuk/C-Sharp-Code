using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            int[,] Table = new int[4, 4];
            int nullR=0;
            int nullC=0;
            string s = "00010203040506070809101112131415";
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    int x = rand.Next(s.Length-1);

                    if (x % 2 != 0)
                        if (x !=s.Length-1)
                            x++;
                        else
                            x--;
                    Table[i, j] = Int32.Parse(s.Substring(x, 2));
                    s = s.Remove(x, 2);
                    if (Table[i, j] == 0)
                    {
                        nullR = i;
                        nullC = j;
                    }
                }
            }
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    Console.WriteLine(Table[i, j]);
            Console.Write("R" + nullR + "C" + nullC);
        }

    }
}
