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

        public int Weight;
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

        private int attemptsNumber = 10;

        private Direction[] directions = new[] {
            new Direction(1,0), new Direction(-1,0),
            new Direction(0,1), new Direction(0,-1)};
    

        public Maze(int width, int height)
        {
            if (width < minSize || width > maxSize || width % 2 == 0)
                width = defaultSize;

            if (height < minSize || height > maxSize || height % 2 == 0)
                height = defaultSize;

            Board = new Cell[height, width];

            for (var i = 0; i < Height; i++)
                for (var j = 0; j < Width; j++)
                    Board[i, j] = new Cell { Row = i, Column = j, Wall = true, Weight = int.MaxValue };

            var moves = new Stack<Cell>();

            var rnd = new Random();

            var currentCell = Board[rnd.Next((Height - 1) / 2) * 2 + 1,
                rnd.Next((Width - 1) / 2) * 2 + 1];
            currentCell.Wall = false;

            moves.Push(currentCell);

            bool deadend;

             

            while(moves.Count > 0)
            {
                deadend = true;

                for(var k = 0; k < attemptsNumber; k++)
                {
                    var dir = directions[rnd.Next(4)];

                    if(CanMove(currentCell, dir))
                    {
                        for(var i = 0; i<2; i++)
                        {
                            var newRaw = currentCell.Row + dir.RawOffset;
                            var newColumn = currentCell.Column + dir.ColumnOffset;
                            currentCell = Board[newRaw, newColumn];
                            currentCell.Wall = false;
                        }

                        deadend = false;
                        moves.Push(currentCell);
                        break;
                    }
                }

                if (deadend)
                {
                    currentCell = moves.Pop();
                }
            }


        }

        public Stack<Cell> MakePath(Cell start, Cell end)
        {
            var path = new Stack<Cell>();

            if (!start.Wall && !end.Wall && start != end)
            {
                MakeWave(start);

                var current = end;
                path.Push(current);

                do
                {
                    foreach(var dir in directions)
                    {
                        var next = Board[current.Row + dir.RawOffset,
                            current.Column + dir.ColumnOffset];
                        if(!next.Wall && next.Weight < current.Weight)
                        {
                            current = next;
                            break;
                        }
;                    }

                    path.Push(current);

                } while (current != start);

                foreach (var cell in Board)
                    cell.Weight = int.MaxValue;
            }

            return path;
        }

        private bool CanMove(Cell c, Direction d)
        {
            int newRaw = c.Row + d.RawOffset * 2;
            int newColumn = c.Column + d.ColumnOffset * 2;

            if (newRaw < 0 || newRaw >= Height ||
                newColumn < 0 || newColumn >= Width)
                return false;

            return Board[newRaw, newColumn].Wall;
        }

        private void MakeWave(Cell c)
        {
            if (c.Wall)
                return;

            var cells = new Queue<Cell>();

            c.Weight = 0;
            cells.Enqueue(c);

            while(cells.Count > 0)
            {
                var currenCell = cells.Dequeue();

                foreach(var d in directions)
                {
                    var newRaw = currenCell.Row + d.RawOffset;
                    var newColumn = currenCell.Column + d.ColumnOffset;
                    if (!Board[newRaw, newColumn].Wall)
                    {
                        var neighbour = Board[newRaw, newColumn];
                        var weight = currenCell.Weight + 1;
                        if(neighbour.Weight > weight)
                        {
                            neighbour.Weight = weight;
                            cells.Enqueue(neighbour);
                        }
                    }
                }
                    
            }


        }
    }

    public class Direction
    {
        public int ColumnOffset;
        public int RawOffset;

        public Direction(int x, int y)
        {
            ColumnOffset = x;
            RawOffset = y;
        }
    }
}
