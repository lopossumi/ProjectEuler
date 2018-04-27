using Microsoft.VisualBasic.FileIO;
using System.IO;
using System.Reflection;

namespace ProjectEuler.Problems
{

    public class Euler081 : IEulerProblem
    {
        public string Result()
        {
            return run().ToString();
        }

        private static int run()
        {
            // Read matrix from file
            int[][] matrix = new int[80][];
            string filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Data\p081_matrix.txt");
            using (TextFieldParser csvParser = new TextFieldParser(filePath))
            {
                csvParser.SetDelimiters(new string[] { "," });
                csvParser.HasFieldsEnclosedInQuotes = false;

                for (int i = 0; i < 80; i++)
                {
                    int[] row = new int[80];
                    string[] rowString = csvParser.ReadFields();
                    for (int j = 0; j < 80; j++)
                    {
                        row[j] = int.Parse(rowString[j]);
                    }
                    matrix[i] = row;
                }
            }

            // Format dijkstra map
            int[][] path = new int[80][];
            for (int i = 0; i < 80; i++)
            {
                int[] row = new int[80];
                for (int j = 0; j < 80; j++)
                {
                    row[j] = int.MaxValue;
                }
                path[i] = row;
            }

            // Visited set
            bool[][] visited = new bool[80][];
            for (int i = 0; i < 80; i++)
            {
                bool[] row = new bool[80];
                for (int j = 0; j < 80; j++)
                {
                    row[j] = false;
                }
                visited[i] = row;
            }

            // Initial node
            //int x = 0;
            //int y = 0;
            path[0][0] = matrix[0][0];

            for (int y = 0; y < 79; y++)
            {
                for (int x = 0; x < 79; x++)
                {
                    // Check right neighbor
                    if (path[x + 1][y] > (path[x][y] + matrix[x + 1][y]))
                    {
                        path[x + 1][y] = (path[x][y] + matrix[x + 1][y]);
                    }
                    // Check bottom neighbor
                    if (path[x][y + 1] > (path[x][y] + matrix[x][y + 1]))
                    {
                        path[x][y + 1] = (path[x][y] + matrix[x][y + 1]);
                    }
                }
            }

            return path[79][78] + matrix[79][79];
        }
    }
}



