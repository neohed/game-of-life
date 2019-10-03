using System;
using System.Collections.Generic;

/*
 * Use 2 lists - one for existing cells
 * and another for empty cells that receive neighbour counts
 * 
 * This will require a 2 step check when examining existing cells neighbourhoods
 * 1) check to see if that cell is occupied in the existing cell list
 * 2) else check if that cell has already been examined in the empty cell list
 * 
 * After that wotk there will be 2 operations
 * 1) remove cells from the existing cell list that have too many or too few neighbours
 * 2) in the empty cell list get all with exactly 3 neighbours and copy them to the existing cell list
 * 
 */
namespace ConwaysLifeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //string[] startConfiguration = {
            //                     "    *    ",
            //                     "    *    ",
            //                     "    *    ",
            //                     " *** *** ",
            //                     "    *    ",
            //                     "    *    ",
            //                     "    *    "
            //                 };

            //string[] startConfiguration = {
            //                     " ***** ***** ***** "
            //                 };

            string[] startConfiguration = {
                                 " ***** ***** ***** ",
                                 "                   ",
                                 "                   ",
                                 "                   ",
                                 "                   ",
                                 " ***** ***** ***** "
                             };

            List<Point> initialCellConfiguration = new List<Point>();

            int x, y = 0;
            foreach (string row in startConfiguration)
            {
                x = 0;
                foreach (char c in row)
                {
                    if (c == '*')
                    {
                        initialCellConfiguration.Add(new Point(x, y));
                    }

                    ++x;
                }

                ++y;
            }

            //foreach (KeyValuePair<ConwaysGameofLife.Point, ConwaysGameofLife.Cell> kvp in cells)
            //{
            //    Console.WriteLine("X: {0}, Y {1}, Count {2}", kvp.Key.X.ToString(), kvp.Key.Y.ToString(), kvp.Value.Neighbours.ToString());
            //}

            ConwaysGameofLife life = new ConwaysGameofLife(initialCellConfiguration);
            ConsoleKeyInfo keyPressed;

            int generationCount = 0;
            do
            {
                Console.Write("\nGeneration: {0}\n", (++generationCount).ToString());

                char[,] output = life.Draw();

                for (int yPos = 0; yPos < output.GetLength(1); ++yPos)
                {
                    for (int xPos = 0; xPos < output.GetLength(0); ++xPos)
                    {
                        Console.Write(output[xPos, yPos]);
                    }
                    Console.Write("\n");
                }

                life.RunGeneration();

                Console.WriteLine("\nHit Escape key to exit.\n");
                keyPressed = Console.ReadKey();
            } while (keyPressed.Key != ConsoleKey.Escape);
        }
    }

}
