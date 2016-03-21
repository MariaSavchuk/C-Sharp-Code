using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Threading;
namespace Массивы
{/*
  * Вычислить
  * 1) Количество отрицательных элементов массива
  * 2) Сумму модулей элементов массива, расположенных после минимального по модулю элемента
  * 3) Заменить отрицательные элементы их квадратами и упорядочить по возрастанию
  */
    class Program
    {
        static int Main()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US", false);
            int N,i,h=0,y=0;
            double s=0,min,f=0;
            Console.WriteLine("Введите размерность");
            N=Int32.Parse(Console.ReadLine());
            if (N < 2)
            {
                Console.WriteLine("Неверная размерность");
                return 0;
            }
            double [] m = new double[N];
            Console.WriteLine("Введите массив");
            for(i=0;i<N;i++)
            {
               m[i]=Double.Parse(Console.ReadLine());
            }
            min = Math.Abs(m[i=N-1]);
            for (i = N-1; i >= 0; i--)
            {
                if (m[i] < 0)
                    h++;
                if (Math.Abs(m[i]) <=min)
                {
                    min = Math.Abs(m[i]);
                    y = i;
                }
            }
            for (i = 0; i < N; i++)
            {
                if (i > y)
                {
                    s = s + Math.Abs(m[i]);
                }
                if (m[i] < 0)
                    m[i] = m[i] * m[i];
            }
            Console.WriteLine("Количество отрицательных {0}", h);
            Console.WriteLine("Сумма {0}", s);
            for (int j = 0; j < N; j++)
            {
                for (i = 0; i < N -j- 1; i++)
                {
                    if (m[i] > m[i+1])
                    {
                        s = m[i + 1];
                        m[i + 1] = m[i];
                        m[i] = s;
                    }
                }
            }
            Console.WriteLine(" Преобразованный массив");
            for (i = 0; i < N; i++)
                Console.WriteLine(" {0}", m[i]);

                return 0;
        }
    }
}
