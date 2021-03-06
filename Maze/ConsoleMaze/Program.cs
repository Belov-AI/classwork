﻿using System;
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

            Console.WriteLine();

            Console.WriteLine("Введите координаты начала пути через пробел");
            var start = Console.ReadLine().Split();
            var startCell = maze.Board[int.Parse(start[0]), int.Parse(start[1])];

            Console.WriteLine("Введите координаты конца пути через пробел");
            var end = Console.ReadLine().Split();
            var endCell = maze.Board[int.Parse(end[0]), int.Parse(end[1])];

            var path = maze.MakePath(startCell, endCell);

            Console.WriteLine();
            DisplayMaze(maze, path);

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

        static void DisplayMaze(Maze maze, Stack<Cell> path)
        {
            Console.Write("  ");
            for (var j = 0; j < maze.Width; j++)
                Console.Write(j % 10);
            Console.WriteLine();

            for (var i = 0; i < maze.Height; i++)
            {
                Console.Write($"{i,2}");

                for (var j = 0; j < maze.Width; j++)
                    if (maze.Board[i, j].Wall)
                        Console.Write((char)0x2588);
                    else if (path.Contains(maze.Board[i, j]))
                        Console.Write('*');
                    else
                        Console.Write(' ');

                Console.WriteLine();
            }
        }
    }
}
