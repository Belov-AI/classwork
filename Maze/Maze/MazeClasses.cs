using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MazeLibrary
{
    public class Cell
    {
        public int Row;
        public int Column;
        public bool Wall;
    }

    public class Maze
    {
        public Cell[,] Board;
        
        public int Height
        {
            get
            {
                return Board.GetLength(0);
            }
        }
        
        public int Width
        {
            get
            {
                return Board.GetLength(1);
            }
        }

        const int defaultSize = 25;
        const int minSize = 3;
        const int maxSize = 79;

        public Maze(int width, int height)
        {
            if (width < minSize || width > maxSize || width % 2 == 0)
                width = defaultSize;

            if (height < minSize || height > maxSize || height % 2 == 0)
                height = defaultSize;

            Board = new Cell[height, width];

            for (var i = 0; i < Height; i++)
                for (var j = 0; j < Width; j++)
                    Board[i, j] = new Cell { Row = i, Column = j, Wall = true };


        }
    }
}
