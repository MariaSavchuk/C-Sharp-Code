using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab11
{
   public abstract class STR
    {
        public string CHS;
        public ushort len;
        protected STR()
        {
            CHS = "";
            len = 0;
        }
        protected STR(string s)
        {
            CHS = s;
            len = (ushort)s.Length;
        }
        protected STR(char s)
        {
            CHS = s.ToString();
            len = 1;
        }
        protected ushort GetLen()
        {
            return len;
        }
        protected void Clear()
        {
            CHS = "";
            len = 0;
        }
    }
    class Komp : STR
    {
        public int real;
        public int imaginary;
        public Komp(string s):base(s)
        {
            try
            {
                int x = s.IndexOf("i");
                real = Int32.Parse(s.Substring(0, x));
                imaginary = Int32.Parse(s.Substring(x + 1, s.Length - x-1));
            }
            catch (Exception)
            {
                this.Clear();
                real=0;
                imaginary=0;
            }
        }
        public Komp(): this("0i0")
        {
        }
    }

}
