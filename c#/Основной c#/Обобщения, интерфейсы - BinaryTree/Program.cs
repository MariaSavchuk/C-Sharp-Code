using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BT_generic
{
    class WriteInfo <T> : IVisit <T>
    {
        public void visit(T data)
        {
            Console.Write("{0} ", data.ToString()); 
        }
    }
    
    
    class Program
    {
        static void Main()
        {

            DisThree <int>tr = new DisThree<int>();
            tr.Insert(43);
            tr.Insert(40);
            tr.Insert(143);
            tr.Insert(15);
            tr.Insert(41);
            tr.Insert(100);
            tr.Insert(745);
            tr.Insert(14);
            tr.Insert(13);
            tr.Insert(12);
            Console.WriteLine(tr.Disbalance());
            tr.SortedRTreeWalk(new WriteInfo <int>());
            Console.WriteLine();
        }
    }
}
