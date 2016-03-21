using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
namespace regulV
{
    class Program
    {
        /*Формат даты dd MMM yy содержит: номер дня без ведущего нуля, пробел,
         * трёхсимвольное английское обозначение месяца (прописными буквами), пробел, две
         * последние цифры года. В текстовом файле могут содержаться (как отдельные слова) записи
         * дат в таком формате. Найти максимальную дату, предполагая, что все они относятся к XX
         * столетию. Если таких слов нет, вывести соответствующее сообщение.*/
        //IN.txt
        static void Main(string[] args)
        {
            try
            {
                string search = @"\b(((([12]?\d|3[01])\s(JAN|MAR|MAY|JUL|AUG|OCT|DEC)|([12]?\d|30)\s(APR|JUN|SEP|NOV))\s\d\d)|(29\sFEB\s([02468][048]|[13579][26])|(1?\d|2[0-8])\sFEB\s\d\d))\b";
                string monthes = @"(?<JAN>JAN)(?<FEB>FEB)(?<MAR>MAR)(?<APR>APR)(?<MAY>MAY)(?<JUN>JUN)(?<JUL>JUL)(?<AUG>AUG)(?<SEP>SEP)(?<OCT>OCT)(?<NOV>NOV)(?<DEC>DEC)";
                string input;
                string maX = "";
                Console.WriteLine("Введите имя файла");
                StreamReader f = new StreamReader(Console.ReadLine());
                Regex MonthReg = new Regex(monthes);
                Console.WriteLine("Все найденные даты:");
                int year = 0;
                int month = 0;
                int day = 0;
                int Myear = 0;
                int Mmonth = 0;
                int Mday = 0;
                while ((input = f.ReadLine()) != null)
                {
                    foreach (Match match1 in Regex.Matches(input, search))
                    {
                        Console.WriteLine(match1.Value);
                        string[] s = Regex.Split(match1.Value, " ");
                        year = Int32.Parse(s[2]);
                        month = MonthReg.GroupNumberFromName(s[1]);
                        day = Int32.Parse(s[0]);
                        if (year > Myear)
                        {
                            maX = match1.Value;
                            Myear = year;
                            Mmonth = month;
                            Mday = day;
                        }
                        if (year == Myear)
                        {
                            if (month > Mmonth)
                            {
                                maX = match1.Value;
                                Myear = year;
                                Mmonth = month;
                                Mday = day;
                            }
                            if (month == Mmonth)
                            {
                                if (day > Mday)
                                {
                                    maX = match1.Value;
                                    Myear = year;
                                    Mmonth = month;
                                    Mday = day;
                                }
                            }
                        }
                    }
                }
                Console.WriteLine();
                if (maX =="")
                    Console.WriteLine("Нет таких слов");
                else
                    Console.WriteLine(maX);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}