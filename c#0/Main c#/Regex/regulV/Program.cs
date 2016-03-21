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
         * столетию. Если таких слов нет, вывести соответствующее сообщение.
         */
        //IN.txt
        static void Main(string[] args)
        {
            try
            {
                string search = @"\b(((([12]?\d|3[01])\s(JAN|MAR|MAY|JUL|AUG|OCT|DEC)|([12]?\d|30)\s(APR|JUN|SEP|NOV)|(1?\d|2[0-8])\sFEB)\s\d\d)|(29\sFEB\s([02468][048]|[13579][26])))\b";
                string input;
                string rep = @"\w{3}";
                string pattern = @"(\d?\d)\s(\w{3})\s(\d{2})";
                string monthes = @"(?<JAN>JAN)(?<FEB>FEB)(?<MAR>MAR)(?<APR>APR)(?<MAY>MAY)(?<JUN>JUN)(?<JUL>JUL)(?<AUG>AUG)(?<SEP>SEP)(?<OCT>OCT)(?<NOV>NOV)(?<DEC>DEC)";
                string max = "00 00 00";
                string maX = "";
                Console.WriteLine("Введите имя файла");
                StreamReader f = new StreamReader(Console.ReadLine());
                Regex MonthReg = new Regex(monthes);
                Console.WriteLine("Все найденные даты:");
                while ((input = f.ReadLine()) != null)
                {
                    foreach (Match match1 in Regex.Matches(input, search))
                    {
                        int x = MonthReg.GroupNumberFromName(Regex.Match(match1.Value, rep).Value);
                        string change = String.Format(@"$3 {0} $1", x + 10);
                        string buf = Regex.Replace(match1.Value, pattern, change);
                        Console.WriteLine(match1.Value);
                        if (String.Compare(max, buf) < 0)
                        {
                            maX = match1.Value;
                            max = buf;
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