using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MazeLibrary;

namespace CrazyMaze
{
    public partial class Form1 : Form
    {
        enum Status { WaitingForStart, WaitingForEnd, Final}

        int mazeWidth = 79, mazeHeight = 79;
        Maze maze;
        Status status;
        Cell cellStart, cellEnd;

        int cellSizeInPixels = 10;

        public Form1()
        {
            InitializeComponent();

            maze = new Maze(mazeWidth, mazeHeight);
            ClientSize = new System.Drawing.Size(
                maze.Width * cellSizeInPixels, maze.Height * cellSizeInPixels);

            status = Status.WaitingForStart;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            var g = CreateGraphics();
            DrawMaze(g);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(status == Status.Final && e.KeyCode == Keys.Escape)
            {
                var g = CreateGraphics();
                g.Clear(BackColor);
                DrawMaze(g);
                status = Status.WaitingForStart;
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            var column = e.Location.X / cellSizeInPixels;
            var raw = e.Location.Y / cellSizeInPixels;

            if(status != Status.Final)
            {
                var g = CreateGraphics();

                if(!maze.Board[raw, column].Wall)
                {
                    g.FillRectangle(Brushes.Red,
                        column * cellSizeInPixels, raw * cellSizeInPixels,
                        cellSizeInPixels, cellSizeInPixels);

                    if(status == Status.WaitingForStart)
                    {
                        cellStart = maze.Board[raw, column];
                        status = Status.WaitingForEnd;
                    }
                    else
                    {
                        cellEnd = maze.Board[raw, column];
                        status = Status.Final;

                        var path = maze.MakePath(cellStart, cellEnd);

                        while(path.Count > 0)
                        {
                            var current = path.Pop();
                            g.FillRectangle(Brushes.Red,
                                current.Column * cellSizeInPixels,
                                current.Row * cellSizeInPixels,
                                cellSizeInPixels, cellSizeInPixels);
                        }

                    }
                }
            }
        }

        private void DrawMaze(Graphics g)
        {
            foreach (var cell in maze.Board)
                if (cell.Wall)
                    g.FillRectangle(Brushes.Black,
                        cell.Column * cellSizeInPixels, cell.Row * cellSizeInPixels,
                        cellSizeInPixels, cellSizeInPixels);
        }
    }
}
