using System;

namespace GameOfLifeSession4
{
    //public class Human
    //{
    //    public Human()
    //    {

    //    }

    //    public string say(string sentence)
    //    {
    //        return sentence;
    //    }
    //}

    //Human jean = new Human();

    public class Grid
    {
        // internal variable that holds the length of
        // one side of the square
        int size;
        private int[,] data;

        // constructor. Takes an argument, gridSize, which
        // is the length of one size of the square
        public Grid(int gridSize)
        {
            size = gridSize;

            // set up my data
            // first set everything to 0 (which means dead)
            data = new int[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    data[i, j] = 0;
                }
            }

            // set some cells to be 1 (which means alive)
            setCellAlive(2, 3);
            setCellAlive(2, 4);
            setCellAlive(2, 5);
            setCellAlive(-2, 1);
        }

        private void setCellAlive(int x, int y)
        {
            // make sure the cell is in the bounds of the grid
            if (x < size && x >= 0 &&
                y < size && y >= 0)
            {
                // and if it is, set it alive
                data[x, y] = 1;
            }
            // otherwise, we won't set anything
        }

        // grid has to refresh & change
        public void goNextGeneration()
        {
            // for each cell, this will hold the number of live neighbors
            int neighbors;

            // create a new generation
            int[,] newGeneration = new int[size, size];

            // look at each cell in the old generation
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    neighbors = 0;
                    // count the cell's live neighbors
                    // the cell is at data[i, j]
                    // for each neighbor, add 0 or 1 depending on whether
                    // it's alive or dead
                    neighbors += lifeCount(i + 1, j - 1);
                    neighbors += lifeCount(i + 1, j);
                    neighbors += lifeCount(i + 1, j + 1);
                    neighbors += lifeCount(i, j - 1);
                    neighbors += lifeCount(i, j + 1);
                    neighbors += lifeCount(i - 1, j - 1);
                    neighbors += lifeCount(i - 1, j);
                    neighbors += lifeCount(i - 1, j + 1);

                    // if the cell's dead
                    if (data[i, j] == 0)
                    {
                        if (neighbors == 3)
                        {
                            // and has three live surrounding cells, it comes alive in the new generation
                            newGeneration[i, j] = 1;
                        } else
                        { // otherwise it's dead in the new generation
                            newGeneration[i, j] = 0;
                        }
                    }
                    else // if the cell's alive
                    {
                        // it survives (in the new gen) with 2 or 3 surrounding live cells
                        if (neighbors == 2 || neighbors == 3)
                        {
                            newGeneration[i, j] = 1;
                        } else
                        {
                            // otherwise it dies (in the new gen)
                            newGeneration[i, j] = 0;
                        }
                    }
                }
            }
            // new generation becomes the current generation
            data = newGeneration;
        }

        // function that returns a number
        // - 0 for dead and 1 for alive
        // - given a position
        // if you give it an illegal position, it returns 0
        private int lifeCount(int x, int y)
        {
            if (isAliveAt(x, y))
            {
                return 1;
            } else
            {
                return 0;
            }
        }

        // function that tells whether the cell is alive or
        // dead at the given position
        // if you give it an illegal position, it returns false
        public bool isAliveAt(int x, int y)
        {
            //check to make sure cell is in a legal position
            if (x < 0 || x >= size ||
                y < 0 || y >= size)
            {
                return false;
            }
            // access internal grid to check whether alive or dead
            if (data[x, y] == 1)
            {
                return true;
            } else
            {
                return false;
            }
            //return (data[x, y] == 1);
        }

        // function that tells the length of one side of the
        // square
        public int length()
        {
            return size;
        }
    }
}
