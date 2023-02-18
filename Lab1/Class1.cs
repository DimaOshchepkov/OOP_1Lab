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

        public int x0;
        public int y0;

        public Game(int size)
        {
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

        public void ShiftRandom()
        {
            int x = x0, y = y0;

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

        public void Shift(int position)
        {
            PositionToCoordinates(position, out int x, out int y);
            if (Math.Abs(x0 - x) + Math.Abs(y0 - y) == 1)
            {
                field[x0, y0] = field[x, y];
                field[x, y] = 0;
                x0 = x;
                y0 = y;
            }
            
        }

    }
}
