using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Threading;
//Рассчёт Math.Log((1 + x) / (1 - x)) с помощью ряда Тейлора
namespace ConsoleApplication1
{

    class Program
    {
        static int Main()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US", false);
            double x, y, z = 0, S = 0, l = 0, m = 1;
            int i;
            Console.WriteLine("Введите аргумент");
            x = Double.Parse(Console.ReadLine());
            Console.WriteLine("Введите точность");
            y = Double.Parse(Console.ReadLine());
            if((x>=1)||(x<=-1)||(y>=1)||(y<=0))
            {
                Console.WriteLine("Неправильная точность или аргумент");
                return 0;
            }
            z = 1;
            while (z > y)
            {
                S = x;
                for (i = 1; i < 2*m-1; i++)
                {
                    S = S * x;
                }
                S = l+2 * S / (2 * m - 1);
                if ((z = S - l) < 0)
                {
                    z = -z;
                }
                l = S;
                m++;
            }
            Console.WriteLine("ln((1+x)/(1-x)={0}",S);
            Console.WriteLine("Работа функции "+Math.Log((1 + x) / (1 - x)));
            return 0;
        }
    }
}
