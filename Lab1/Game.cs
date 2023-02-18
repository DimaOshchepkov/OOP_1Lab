using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class Game
    {
        private int[,] field;
        private int sizeField;

        Random r;

        private int x0 { get; set; }
        private int y0 { get; set; }

        public int CountMove { get;  private set; }

        public Game(int size)
        {
            CountMove = 0;
            field = new int[size, size];
            sizeField = size;
            
            r = new Random();
        }
        private int CoordinatesToPosition(int x, int y)
        {
            return x + y * sizeField;
        }

        private void PositionToCoordinates(int position, out int x, out int y)
        {
            x = position % sizeField;
            y = position / sizeField;
        }

        public void Start()
        {
            CountMove = 0;
            x0 = sizeField - 1;
            y0 = sizeField - 1;
            for (int i = 0; i < sizeField; i++)
            {
                for (int j = 0; j < sizeField; j++)
                    field[i,j] = CoordinatesToPosition(i, j) + 1;
            }
            field[x0, y0] = 0;
        }

        public int GetNumber(int position)
        {
            int x, y;
            PositionToCoordinates(position, out x, out y);
            return field[x, y];
        }

        public void ShiftRandom(int countRandomSwaps)
        {
            int x = x0, y = y0;
            for (int i = 0; i < countRandomSwaps; i++)
            {
                switch (r.Next(0, 4))
                {
                    case 0:
                        if (x >= 1)
                            x--;
                        break;
                    case 1:
                        if (x < sizeField - 1)
                            x++;
                        break;
                    case 2:
                        if (y >= 1)
                            y--;
                        break;
                    case 3:
                        if (y < sizeField - 1)
                            y++;
                        break;
                }
                Shift(CoordinatesToPosition(x, y));
            }
            CountMove = 0;
        }

        public void Shift(int position)
        {
            
            PositionToCoordinates(position, out int x, out int y);
            if (Math.Abs(x0 - x) + Math.Abs(y0 - y) == 1)
            {
                CountMove++;
                field[x0, y0] = field[x, y];
                field[x, y] = 0;
                x0 = x;
                y0 = y;
            }
            
        }

        public bool Check()
        {
            if (x0 != sizeField - 1 || y0 != sizeField - 1)
                return false;

            for (int x = 0; x < sizeField; x++)
                for (int y = 0; y < sizeField; y++)
                    if (field[x, y] != CoordinatesToPosition(x, y) + 1 && x*y != (sizeField - 1)* (sizeField - 1))
                        return false;
            return true;
        }
    }
}
