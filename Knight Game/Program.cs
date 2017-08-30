using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Knight
{
    public Knight(int row, int col, int hits)
    {
        this.Row = row;
        this.Col = col;
        this.Hits = hits;

    }

    public int Row { get; }
    public int Col { get; }
    public int Hits { get; }

}
    public class Program
    {
        public static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[][] matrix = new char[size][];
            int removedKnights = 0;
            List<Knight> knights = new List<Knight>();

            ReadMatrix(size, matrix);
            CalculateHits(size, matrix, knights);

            //bool hasDanger = true;

            while (true)
            {
                if (knights.Count == 0) { break; }

                var maxHit = knights.Select(k => k.Hits).Max();

                var knithsWithMaxHits = knights.GroupBy(k => new { k.Hits, k.Row, k.Col }).Where(g => g.Key.Hits.Equals(maxHit)).Select(g => new { Hits = g.Key.Hits, Row = g.Key.Row, Col = g.Key.Col });


                foreach (var knight in knithsWithMaxHits)
                {
                    matrix[knight.Row][knight.Col] = '0';
                    removedKnights++;
                    knights.Clear();
                    CalculateHits(size, matrix, knights);
                    break;
                }


                //CalculateHits(size, matrix, knights);
            }

            Console.WriteLine(removedKnights);
        }

        private static void CalculateHits(int size, char[][] matrix, List<Knight> knights)
        {

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'K')
                    {
                        int hits = 0;
                        hits += TryVerticalHits(size, matrix, row, col);
                        hits += TryHorizontalHits(size, matrix, row, col);

                        if (hits != 0)
                        { knights.Add(new Knight(row, col, hits)); }
                    }

                }
            }
        }

        private static int TryHorizontalHits(int size, char[][] matrix, int row, int col)
        {

            int currentHits = 0;
            int rowPlusOne = row + 1;
            int rowMinusOne = row - 1;
            int colPlusTwo = col + 2;
            int colMinusTwo = col - 2;

            if (rowPlusOne < size)
            {
                if (colPlusTwo < size)
                { if (matrix[rowPlusOne][colPlusTwo] == 'K') { currentHits++; } }

                if (colMinusTwo >= 0)
                { if (matrix[rowPlusOne][colMinusTwo] == 'K') { currentHits++; } }
            }

            if (rowMinusOne >= 0)
            {
                if (colPlusTwo < size)
                { if (matrix[rowMinusOne][colPlusTwo] == 'K') { currentHits++; } }

                if (colMinusTwo >= 0)
                { if (matrix[rowMinusOne][colMinusTwo] == 'K') { currentHits++; } }
            }

            return currentHits;
        }

        private static int TryVerticalHits(int size, char[][] matrix, int row, int col)
        {
            int currentHits = 0;
            int rowPlusTwo = row + 2;
            int rowMinusTwo = row - 2;
            int colPlusOne = col + 1;
            int colMinusOne = col - 1;

            if (rowPlusTwo < size)
            {
                if (colMinusOne >= 0)
                { if (matrix[rowPlusTwo][colMinusOne] == 'K') { currentHits++; } }

                if (colPlusOne < size)
                { if (matrix[rowPlusTwo][colPlusOne] == 'K') { currentHits++; } }
            }

            if (rowMinusTwo >= 0)
            {
                if (colMinusOne >= 0)
                { if (matrix[rowMinusTwo][colMinusOne] == 'K') { currentHits++; } }

                if (colPlusOne < size)
                { if (matrix[rowMinusTwo][colPlusOne] == 'K') { currentHits++; } }
            }

            return currentHits;
        }

        private static void ReadMatrix(int size, char[][] matrix)
        {
            for (int i = 0; i < size; i++)
            {
                string input = Console.ReadLine();
                matrix[i] = new char[size];
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    matrix[i][j] = input[j];
                }
            }
        }
    }


