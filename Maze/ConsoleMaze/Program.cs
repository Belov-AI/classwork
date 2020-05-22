using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeLibrary;

namespace ConsoleMaze
{
    class Program
    {
        static void Main()
        {
            var maze = new Maze(35, 25);
            DisplayMaze(maze);

            Console.ReadKey();
        }

        static void DisplayMaze(Maze maze)
        {
            Console.Write("  ");
            for (var j = 0; j < maze.Width; j++)
                Console.Write(j % 10);
            Console.WriteLine();

            for(var i = 0; i < maze.Height; i++)
            {
                Console.Write($"{i,2}");

                for (var j = 0; j < maze.Width; j++)
                    if (maze.Board[i, j].Wall)
                        Console.Write((char)0x2588);
                    else
                        Console.Write(' ');

                Console.WriteLine();
            }
                
        }
    }
}
