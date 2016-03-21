using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
namespace delegat
{
    /*Создать два класса «Вычислитель» и «Демонстратор», которые обмениваются между собой
     * сообщениями о наступивших событиях.
     * Вычислитель (при необходимости) случайным образом генерирует параметры, выполняет
     * вычисления, согласно варианту, и генерирует событие «Вычисление завершено». После генерации
     * события Вычислитель «отдыхает» некоторое время (время отдыха передаётся в конструкторе
     * Вычислителя) и выполняет следующее вычисление.
     * Это событие обрабатывает Демонстратор, выводя результаты вычисления на форму в удобном
     * для чтения виде.
     * Демонстратор по команде пользователя генерирует событие «Прекратить вычисления»,
     * которое обрабатывается Вычислителем.
     */
    public delegate void Show(string s);
    public delegate void CalculatorEventHandler(object sender, long x);
    public delegate void DemonstratorEventHandler(object sender);
    class Calculator
    {
        public long Number
        {
            get;
            set;
        }
        public int rest;
        bool NotActive
        {
            get;
            set;
        }
        private Demonstraror demonstrator;
        public Demonstraror Demonstrator
        {
            get { return demonstrator; }

        }
        public event CalculatorEventHandler CalculatorEvent;
        public Calculator( Show z)
        {
            Random rand = new Random();
            Number = rand.Next(0, 35);
            rest = 100;

            demonstrator = new Demonstraror(this, z);
            NotActive = false;

            CalculatorEvent += new CalculatorEventHandler(demonstrator.Show);
        }
        public Calculator(int y, Show z)
        {
            if (y <= 0)
            {
                throw new ArgumentException("Меньше нуля!");
            }
            NotActive = false;
            Random rand = new Random();
            Number = rand.Next(0, 35);
            rest = y;
            demonstrator = new Demonstraror(this,z);
            CalculatorEvent += new CalculatorEventHandler(demonstrator.Show);
        }
        public long Calculation(double num)
        {
            long x;
            if (num != 0)
                x = (long)(2 * (2 * num - 1) * Calculation(num - 1) / (num + 1));
            else
                x = 1;
            return x;
        }
        public void Calculation()
        {
            if (NotActive)
            {
                return;
            }
            long x = Calculation(Number);
            CalculatorEvent(this, x);
            Random rand = new Random();
            Number = rand.Next(0, 35);
        }
        public void Stop(object sender)
        {
            NotActive = true;
        }
    }
    class Demonstraror
    {
        private Calculator calculator;
        public Show pok;
        public Calculator Calculator
        {
            get { return calculator; }
            set { calculator = value; }
        }
        public Demonstraror(Calculator calk, Show z)
        {
            Calculator = calk;
            pok = z;
            DemonstratoeEvent += new DemonstratorEventHandler(calk.Stop);
        }
        public event DemonstratorEventHandler DemonstratoeEvent;
        public void Show(object sender, long x)
        {
            
            pok(String.Format(" C({0})={1} ", (sender as Calculator).Number, x));
        }
        
        public string Stop()
        {
            DemonstratoeEvent(this);
            return String.Format("Прекратить вычисление!");
        }
    }

}
