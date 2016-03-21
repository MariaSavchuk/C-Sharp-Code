using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainStation
{
    public enum Presence {Move,Here,Leave};
    public struct Time
    {
        public int time;
        public int day;
        public int month;
        public int year;
        public Time(int t, int d, int m, int y)
        {
            time = t;
            day = d;
            month = m;
            year = y;
        }
        public Time(Time y)
        {
            time = y.time;
            day = y.day;
            month = y.month;
            year = y.year;
        }
    }
    //структура время
    public class Train:IComparable
    {
        private string PointOfDestination;
        private string Number;
        private Time Departure;
        static int ID = 0;
        private Presence Condition
        {
            get;
            set;
        }
        public string GetNumber()
        {
            return Number;
        }
        public string GetPointOfDestination()
        {
            return PointOfDestination;
        }
        public Train(string p, string n, int h,int min, int d, int m, int y, Presence t)
        {
            ID++;
            Condition = t;
            PointOfDestination = p;
            Number = n;
            if ((y < 2015)||(m > 12) || (m < 1)||(d > 31) || (d < 0)||(h >= 24) || (min >= 60) || (min < 0))
                throw new FormatException("Неправильный формат времени");
            Departure = new Time(h*60+min, d, m, y);
        }
        public Train()
        {
            ID++;
            PointOfDestination = "Brest";
            Number = ID.ToString();
            Condition = 0;
            Departure = new Time(0, 5, 6, 2015);

        }
        public Train(Train train)
        {
            ID++;
            PointOfDestination = train.PointOfDestination;
            Number = train.Number;
            Condition = train.Condition;
            Departure = new Time(train.Departure);
        }
        //конструктор
        public override string ToString()
        {
            string train = "Номер: " + Number + " Место назначения: " + PointOfDestination + String.Format(" Время отправления: {0}:{1} {2}.{3}.{4}",
                Departure.time / 60, Departure.time - 60 * (Departure.time / 60), Departure.day, Departure.month, Departure.year);
            switch (Condition)
            {
                case Presence.Move: train +=" По пути на станцию"; break;
                case Presence.Here: train +=" На станции"; break;
                case Presence.Leave: train += " Отбыл"; break;

            }
            return train;
        }
        // демонстрация поезда
        public static bool operator <(Train t1, Train t2)
        {
            if (t1.Departure.year < t2.Departure.year)
                return true;
            if (t1.Departure.year == t2.Departure.year)
            {
                if (t1.Departure.month < t2.Departure.month)
                    return true;
                if (t1.Departure.month == t2.Departure.month)
                {
                    if (t1.Departure.day < t2.Departure.day)
                        return true;
                    if (t1.Departure.day == t2.Departure.day)
                        if (t1.Departure.time < t2.Departure.time)
                            return true;
                }
            }
            return false;
        }
        public static bool operator >=(Train t1, Train t2)
        {
            return (!(t1 < t2));
        }
        public static bool operator <=(Train t1, Train t2)
        {
            return (!(t1 > t2));
        }
        public static bool operator ==(Train t1, Train t2)
        {
            return (!(t1 < t2) && !(t2 < t1));
        }
        public static bool operator >(Train t1, Train t2)
        {
            return (t2 < t1);
        }
        public static bool operator !=(Train t1, Train t2)
        {
            return (!(t1 == t2));
        }
        public override bool Equals(object obj)
        {
            if (!(obj is Train))
                throw new ArgumentException("Аргумент не Train");
            return ((Departure.year == (obj as Train).Departure.year) && (Departure.month == (obj as Train).Departure.month) && (Departure.day == (obj as Train).Departure.day) && (Departure.time == (obj as Train).Departure.time));
        }
        public override int GetHashCode()
        {
            return Departure.GetHashCode();
        }
        public int CompareTo(object obj)
        {
            if (!(obj is Train))
                throw new ArgumentException("Аргумент не Train");
            if (this < (Train)obj)
                return -1;
            if (this > (Train)obj)
                return 1;
            return 0;
        }
        //перегрузка операций сравнения
    }
    //класс поезд
    public class RailwayStation
    {
        private Train[] Trains;
        private int N
        {
            get;
            set;
        }
        public RailwayStation(int n)
        {
            if (n < 1)
                throw new ArgumentException("Число элементов не меньше 1");
            Trains = new Train[n];
            N = n;
        }
        //конструктор
        public int GetTrain(string t)
        {
            for (int i = 0; i < N; i++)
                if (Trains[i].GetNumber()==t)
                    return i;
            throw new ArgumentException(String.Format("Нет такого: " + t));
        }
        //найти по номеру
        public Train this[string n]
        {
            get
            {
                return Trains[GetTrain(n)];
            }
            set
            {
                Trains[GetTrain(n)] = value;
            }
        }
        public Train this[int n]
        {
            get
            {
                if ((n >= 0) && (n < N))
                {
                    return Trains[n];
                }
                throw new ArgumentException(String.Format("Неверный индекс " + n));
            }
            set
            {
                if ((n >= 0) && (n < N))
                    Trains[n] = value;
                else
                    throw new ArgumentException(String.Format("Неверный индекс " + n));
            }
        }
        //индексатор
        public void ShowByTime(string time_str)
        {
            if (time_str == null)
                throw new ArgumentNullException();
            if (time_str.Length != 16)
                throw new FormatException("!Неправильный формат времени");
            int y = Int32.Parse(time_str.Substring(12, 4));
            if (y < 2015)
                throw new FormatException("Неправильный формат времени");
            int m = Int32.Parse(time_str.Substring(9, 2));
            if ((m > 12) || (m < 1))
                throw new FormatException("Неправильный формат времени");
            int d = Int32.Parse(time_str.Substring(6, 2));
            if ((d > 31) || (d < 0))
                throw new FormatException("Неправильный формат времени");
            int h = Int32.Parse(time_str.Substring(0, 2));
            int min = Int32.Parse(time_str.Substring(3, 2));
            if ((h >= 24) || (min >= 60) || (min < 0))
                throw new FormatException("Неправильный формат времени");
            Train x = new Train("d", "r", h, min, d, m, y,0);
            int l = 0;
            Train[] bufTrains = new Train[N];
            for (int i = 0; i < N; i++)
                bufTrains[i] = new Train(Trains[i]);
            Array.Sort(bufTrains);
            for (int i = 0; i < N; i++)
            {
                if (bufTrains[i] >= x)
                {
                    l++;
                    Console.WriteLine(bufTrains[i]);
                }
            }
            if (l == 0)
                Console.WriteLine("Нет таких поездов");
        }
        //вывод всех после конкретного времени
        public void ShowByPointOfDestination(string s)
        {
            int z=0;
            Train []bufTrains=new Train[N];
            for(int i=0;i<N;i++)
                bufTrains[i] = new Train(Trains[i]);
            Array.Sort(bufTrains);
            for (int i = 0; i < N; i++)
            {
                if (bufTrains[i].GetPointOfDestination() == s)
                {
                    Console.WriteLine(bufTrains[i]);
                    z++;
                }
            }
            if (z == 0)
                Console.WriteLine("Нет таких");
        }
        //все с заданным пунктом назначения
    }
}
