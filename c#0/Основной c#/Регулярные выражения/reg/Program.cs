using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
namespace reg
{
    /*Хороший» пароль должен иметь длину в 8 символов, содержать большие, маленькие 
              * буквы латинского алфавита, цифры, подчёркивание, причём должен быть включён хотя бы
              * один символ из каждой группы. Найти количество «хороших» паролей в текстовом файле.*/
    //In.txt
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string search = @"\b(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*_).{8}\b";
                
                string search2 =@"(?=.*[A-Z])(?=.*[a-z])(?=.*\d).{8,}";
                Console.WriteLine("Введите имя файла");
                StreamReader f = new StreamReader(Console.ReadLine());
                int n = 0;
                
                string input;
                while ((input = f.ReadLine()) != null)
                {
                    n = n+Regex.Matches(input, search).Count;
                    foreach (Match match1 in Regex.Matches(input, search))
                        Console.WriteLine(match1.Value);
                }
                Console.WriteLine("Число хороших паролей " + n);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}