using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
namespace Target
{
    public delegate void Show(string s);
    public delegate void Shoot(int x,int y);
    public delegate void CalculatorEventHandler(object sender, long x);
    public delegate void DemonstratorEventHandler(object sender);
    public class Calculator
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
            set { demonstrator = value; }
        }
        public event CalculatorEventHandler CalculatorEvent;
        public Calculator(int y, Demonstraror d)
        {
            NotActive = false;
            Random rand = new Random();
            Number = rand.Next(0, 35);
            rest = y;
            Demonstrator = d;
            CalculatorEvent += new CalculatorEventHandler(Demonstrator.Show);
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
            while (!NotActive)
            {
                long x = Calculation(Number);
                CalculatorEvent(this, x);
                Thread.Sleep(rest);
                Random rand = new Random();
                Number = rand.Next(0, 35);
            }
        }
        public void Stop(object sender)
        {
            NotActive = true;
        }
    }
    public class Demonstraror
    {
        private Calculator calculator;
        public Show demonstrate;
        public Shoot preformShoot;
        public int wait;
        public int size;
        public int maxX;
        public bool Active = true;
        public Calculator Calculator
        {
            get { return calculator; }
            set { 
                calculator = value;
                DemonstratorEvent += new DemonstratorEventHandler(calculator.Stop);
            }
        }
        public Demonstraror(Show demonstrate, Shoot preformShoot, int time, int rad, int X)
        {
            if ((time <= 0)||(rad>80)||(X>200)||(rad<20)||(X<20))
                throw new ArgumentException("Не верно введены данные");
            wait = time;
            size = rad;
            maxX = X;
            this.demonstrate = demonstrate;
            this.preformShoot = preformShoot;
        }
        public event DemonstratorEventHandler DemonstratorEvent;
        public void Show(object sender, long x)
        {
            demonstrate(String.Format(" C({0})={1} ", (sender as Calculator).Number, x));
        }
        public void Shoot()
        {
            while (Active)
            {
                Random rand = new Random();
                int x = rand.Next(-maxX, maxX);
                int y = rand.Next(-maxX, maxX);
                preformShoot(x, y);
                Thread.Sleep(wait);
            }
        }
        public string Stop()
        {
            DemonstratorEvent(this);
            return String.Format("Прекратить вычисление!");

        }
    }
}
