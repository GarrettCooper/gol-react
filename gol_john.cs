using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameOfLifeSession4
{
    class Program
    {
        static void Main(string[] args)
        {
            //grid with dead cells and live cells
            //start with 15x15
            int gridSize = 15;

            //option 1 - tell the grid how big it is when constructing
            Grid grid = new Grid(gridSize);

            //option 2 - construct empty, then set size
            //Grid grid = new Grid();
            //grid.size = gridSize;

            //loop forever (until you close the window)
            //print, then take a step in the game of life, then wait a moment
            while (true)
            {
                printGrid(grid);
                Thread.Sleep(1000);
                Console.Clear();
                grid.goNextGeneration();
            }
        }

        static void printGrid(Grid grid)
        {
            //be able to print the grid
            //print a newline
            char liveCell = '*';
            char deadCell = '.';
            //for each line
            for (int i = 0; i < grid.length(); i++)
            {
                //for each value
                for (int j = 0; j < grid.length(); j++)
                {
                    //Check if this position is alive
                    //and print accordingly
                    if (grid.isAliveAt(i, j))
                    {
                        Console.Write(liveCell);
                    }
                    else
                    {
                        Console.Write(deadCell);
                    }
                    //horizontal spacing
                    Console.Write(' ');
                }
                //newline at the end of a line
                Console.WriteLine();
            }
            //some extra space after an entire grid is printed
            Console.WriteLine();
        }
    }
}
