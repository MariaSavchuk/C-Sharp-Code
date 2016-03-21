using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Globalization;
using System.IO;
/* Реализовать класс поезд, содержащий следующие закрытые поля: название пункта назначения,
 * номер поезда (содержит буквы и цифры), время отправления.
 * Реализовать свойства для получения состояния объекта
 * Описать класс вокзал для получения массива поездов.
 * Обеспечить следующие возможности: вывод информации по номеру с помощью индекса,
 * вывод информации о поездах, отправляющихся после введённого с клавиатуры времени,
 * перегруженную операцию сравнения, выполняющую сравнение поездов по времени
 * вывод информации о поездах, отправляющихся в заданный пункт назначения
 * Информацию отсортировать по времени отправления.
 */
namespace TrainStation
{
    class Programm
    {
        static int Main()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US", false);
            try
            {
                //Console.ForegroundColor = ConsoleColor.Yellow;
                StreamReader f = new StreamReader("In.txt");
                int N = Int32.Parse(f.ReadLine());
                Console.WriteLine("Создали конструктором с параметрами");
                RailwayStation r = new RailwayStation(N+1);
                for (int i = 0; i < N; i++)
                {
                    string s = f.ReadLine();
                    int j = 0;
                    while (s[j] != ',')
                        j++;
                    int k = j;
                    j++;
                    while (s[j] != ',')
                        j++;
                    int l = j;
                    j = j + 2;
                    int y = Int32.Parse(s.Substring(s.Length - 6, 4));
                    int m = Int32.Parse(s.Substring(s.Length - 9, 2));
                    int d = Int32.Parse(s.Substring(s.Length - 12, 2));
                    int h = Int32.Parse(s.Substring(j, 2));
                    int min = Int32.Parse(s.Substring(j + 3, 2));
                    int x=Int32.Parse(s.Substring(s.Length - 1, 1));
                    r[i] = new Train(s.Substring(k + 2, l - k - 2), s.Substring(0, k), h, min, d, m, y,(Presence)x);
                    Console.WriteLine(r[i]);
                }
                Console.WriteLine("Создали коструктором без параметров");
                r[N] = new Train();
                Console.WriteLine(r[N]);
                Console.WriteLine("Введите пункт назначения");
                r.ShowByPointOfDestination(Console.ReadLine());
                Console.WriteLine("Введите номер поезда");
                Console.WriteLine(r[Console.ReadLine()]);
                Console.WriteLine("Введите время в формате HH:MM dd.mm.yyyy");
                r.ShowByTime(Console.ReadLine());
                Console.WriteLine("r[0]>r[1]");
                if (r[0] > r[2])
                    Console.WriteLine("Да");
                else
                    Console.WriteLine("Нет");

                Console.WriteLine("r[0]<r[1]");
                if (r[0] < r[2])
                    Console.WriteLine("Да");
                else
                    Console.WriteLine("Нет");
                Console.WriteLine("r[0]>=r[1]");
                if (r[0] >= r[2])
                    Console.WriteLine("Да");
                else
                    Console.WriteLine("Нет");
                Console.WriteLine("r[0]<=r[1]");
                if (r[0] <= r[2])
                    Console.WriteLine("Да");
                else
                    Console.WriteLine("Нет");
                Console.WriteLine("r[0]==r[1]");
                if (r[0] ==r[2])
                    Console.WriteLine("Да");
                else
                    Console.WriteLine("Нет");
                Console.WriteLine("r[0]!=r[1]");
                if (r[0] != r[2])
                    Console.WriteLine("Да");
                else
                    Console.WriteLine("Нет");
            }
            catch (FormatException x)
            {
                Console.WriteLine(x.Message);
            }
            catch (IOException e)
            {
                Console.WriteLine("Не удалось открыть файл. " + e.Message);
                return 0;
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            return 0;
        }
    }
}
