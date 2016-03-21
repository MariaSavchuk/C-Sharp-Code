using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/*Класс, содержащий представления поля для пятнашек*/
namespace Tag
{
    class Tab
    {
        public int[,] Table;
        private int[,] RestartGame;
        public int nullR;
        public int nullC;
        public int col;
        Random rand = new Random();
        public Tab()
        {
            Table = new int[4, 4];
            RestartGame = new int[4, 4];
            nullC = 0;
            nullR = 0;
            col = 0;
            NewGame();
        }
        public void NewGame()
        {
            do
            {
                Random rand = new Random();
                string s = "00010203040506070809101112131415";
                col = 0;
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        int x = rand.Next(s.Length - 1);
                        if (x % 2 != 0)
                            if (x != s.Length - 1)
                                x++;
                            else
                                x--;
                        Table[i, j] = Int32.Parse(s.Substring(x, 2));
                        RestartGame[i,j]=Table[i,j];
                        s = s.Remove(x, 2);
                        if (Table[i, j] == 0)
                        {
                            nullR = i;
                            nullC = j;
                        }
                    }
                }
            } while (Yes());
        }
        public bool Yes()
        {
            int k = 1;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                    if ((Table[i, j] != k) && ((i != 3) || (j != 3)) && ((i != 3) || (j != 1))&&((i != 3) || (j != 2)))
                        return false;
                    else
                    {
                        if (Table[3, 3] != 0)
                            return false;
                        k++;
                    }
            }
            return true;
        }
        public void Restart()
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                {
                    if (RestartGame[i, j] == 0)
                    {
                        nullR = i; nullC = j;
                    }
                    Table[i, j] = RestartGame[i, j];
                }
            col = 0;
        }
        public void Change(int i, int j)
        {
            if (Math.Abs(i - nullR)+Math.Abs(j - nullC)==1)
            {
                col++;
                int y = Table[i, j];
                Table[i, j] = 0;
                Table[nullR, nullC] = y;
                nullR = i;
                nullC = j;
            }

        }
    }
}