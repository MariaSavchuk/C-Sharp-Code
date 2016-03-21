using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace l1
{
    /*Реализовать базовый класс строка и производный комплексное число(два поля, разделённые i,
     * +- находятся только в первой позиции каждого из чисел, конструкторы без парамнетров, с параметрами)
     * организация сравнения (на равенство - Equals)
     * сложение
     * умножение
     * использование коллекции
     */
    class STR : IComparable
    {
        
        protected string _CHS;
        protected ushort len;
        public STR()
        {
            _CHS = "";
            len = 0;
        }
        public string CHS
        {
            get
            {
                return _CHS;
            }
            protected set
            {
                _CHS = value;
            }
        }
        public STR(string s)
        {
            _CHS = s;
            len = (ushort)s.Length;
        }
        public STR(char s)
        {
            _CHS = s.ToString();
            len = 1;
        }
        public ushort GetLen()
        {
            return len;
        }
        public virtual void Clear()
        {
            _CHS = "";
            len = 0;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                throw new NullReferenceException();
            if (!(obj is STR))
                throw new ArgumentException();
            return (obj as STR).CHS == CHS;
        }

        public override int GetHashCode()
        {
            return CHS.GetHashCode();
        }
        public override string ToString()
        {
            return CHS;
        }
        public virtual int CompareTo(object obj)
        {
            if (obj == null)
                throw new NullReferenceException();
            if (!(obj is STR))
                throw new ArgumentException("Не STR");
            return CHS.CompareTo((obj as STR).CHS);
        }

    }
    class Komp : STR
    {
        public int real;
        public int imaginary;
        public Komp(string s)
            : base(s)
        {
            try
            {

                int x = s.IndexOf("i");
                real = Int32.Parse(s.Substring(0, x));
                imaginary = Int32.Parse(s.Substring(x + 1, s.Length - x - 1));
            }
            catch (Exception)
            {
                this.Clear();
                _CHS = "0i0";
                real = 0;
                imaginary = 0;
            }
        }
        public Komp()
            : this("0i0")
        { }
        public Komp(int x, int y)
        {
            _CHS = x.ToString() + "i" + y.ToString();
            real = x;
            imaginary = y;
            len = (ushort)CHS.Length;
        }
        public static Komp operator +(Komp k1, Komp k2)
        {
            return new Komp(k1.real + k2.real, k1.imaginary + k2.imaginary);
        }
        public static Komp operator *(Komp k1, Komp k2)
        {
            return new Komp(k1.real * k2.real - k1.imaginary * k2.imaginary, k1.real * k2.imaginary + k1.imaginary * k2.real);
        }
        /*public static bool operator ==(Komp k1, Komp k2)
        {
            return (k1.real == k2.real) && (k1.imaginary == k2.imaginary);
        }
        public static bool operator !=(Komp k1, Komp k2)
        {
            return !(k1 == k2);
        }
         */
        public override bool Equals(object obj)
        {
            if (obj == null)
                throw new NullReferenceException();
            if (obj is Komp)
            {
                return ((obj as Komp).real == real) && ((obj as Komp).imaginary == imaginary);
            }
            if (obj is STR)
                return CHS.Equals((obj as STR).CHS);
            throw new ArgumentException("Не Komp,не STR");
        }
        public override int GetHashCode()
        {
            string s1 = real.ToString() + "i" + imaginary.ToString();
            return s1.GetHashCode();
        }
        public override void Clear()
        {
            base.Clear();
            real = 0;
            imaginary = 0;

        }
        public override int CompareTo(object obj)
        {
            if (obj == null)
                throw new NullReferenceException();

            if (obj is Komp)
            {
                double m1 = Math.Sqrt(real * real + imaginary * imaginary);
                double m2 = Math.Sqrt((obj as Komp).real * (obj as Komp).real + (obj as Komp).imaginary * (obj as Komp).imaginary);
                return m1.CompareTo(m2);
            }
            if (obj is STR)
                return CHS.CompareTo((obj as STR).CHS);

            throw new ArgumentException("Не STR, не Komp");
        }
    }
}

