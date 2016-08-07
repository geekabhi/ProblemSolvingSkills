using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameofLifeConway
{
    public static class Matrix
    {
        public static void PrintMatrixOnConsle(string[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    Console.Write(matrix[i][j]);

                }
                Console.WriteLine();

            }
        }

        internal static string[][] LoadMatrix(string[][] matrix, string[] args)
        {


            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    foreach (string item in args)
                    {
                        string[] cordinates = item.Split(',');
                        if (i == int.Parse(cordinates[0]) - 1 && j == int.Parse(cordinates[1]) - 1)
                        {
                            matrix[i][j] = cdtMatrix.c_LifeCharacter;
                        }
                    }

                }
            }

            return matrix;
        }


        internal static string[][] IntializeSquareSizeMatrix(int size)
        {
            string[][] matrix = new string[size][];            

            for (int i = 0; i < size; i++)
            {
                matrix[i] = new string[size];

            }

            return matrix;

        }

        public static string[][] FillDeadCellInMatrix(string[][] matrix)
        {

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    matrix[i][j] = cdtMatrix.c_DeadCharacter;
                }
            }

            return matrix;
        }

        public static string[][] GameofLife(string[][] matrix)
        {
            string[][] tempMatrix = new string[matrix.Length][];

            tempMatrix = CopyMatrix(matrix);

            short neighbourCount = 0;


            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {

                    neighbourCount = GetTheNeighbourCount(matrix, i, j);

                    if ( matrix[i][j].Equals(cdtMatrix.c_LifeCharacter) )
                    {
                        if (neighbourCount < 2)
                        {
                            tempMatrix[i][j] = cdtMatrix.c_DeadCharacter;
                        }

                        if (neighbourCount > 3)
                        {
                            tempMatrix[i][j] = cdtMatrix.c_DeadCharacter;
                        }

                        if (neighbourCount == 2 || neighbourCount == 3)
                        {
                            tempMatrix[i][j] = cdtMatrix.c_LifeCharacter;
                        }
                    }

                    if (matrix[i][j].Equals(cdtMatrix.c_DeadCharacter))
                    {
                        if (neighbourCount == 3)
                        {
                            tempMatrix[i][j] = cdtMatrix.c_LifeCharacter;
                        }

                    }


                }
            }

            return tempMatrix;

        }

        private static string[][] CopyMatrix(string[][] matrix)
        {
            string[][] temp = new string[matrix.Length][];

            temp = IntializeSquareSizeMatrix(matrix.Length);

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {                    
                    temp[i][j] = matrix[i][j];
                }
            }

            return temp;
        }

        public static short GetTheNeighbourCount(string[][] matrix, int i, int j)
        {
            short count = 0;



            // X - - -
            // - - - -
            // - - - -
            // - - - -
            if (i == 0 && j == 0)
            {
                if (matrix[i + 1][j].Equals(cdtMatrix.c_LifeCharacter)) count++;
                if (matrix[i][j + 1].Equals(cdtMatrix.c_LifeCharacter)) count++;
                if (matrix[i + 1][j + 1].Equals(cdtMatrix.c_LifeCharacter)) count++;


            }
            // - X X -
            // - - - -
            // - - - -
            // - - - -
            if (i == 0 && (j > 0 && j < (matrix[i].Length - 1)))
            {
                if (matrix[i][j - 1].Equals(cdtMatrix.c_LifeCharacter)) count++;
                if (matrix[i][j + 1].Equals(cdtMatrix.c_LifeCharacter)) count++;
                if (matrix[i + 1][j - 1].Equals(cdtMatrix.c_LifeCharacter)) count++;
                if (matrix[i + 1][j + 1].Equals(cdtMatrix.c_LifeCharacter)) count++;
                if (matrix[i + 1][j].Equals(cdtMatrix.c_LifeCharacter)) count++;

            }
            // - - - X
            // - - - -
            // - - - -
            // - - - -
            if (i == 0 && j == (matrix[i].Length - 1))
            {
                if (matrix[i + 1][j].Equals(cdtMatrix.c_LifeCharacter)) count++;
                if (matrix[i][j - 1].Equals(cdtMatrix.c_LifeCharacter)) count++;
                if (matrix[i + 1][j - 1].Equals(cdtMatrix.c_LifeCharacter)) count++;


            }
            // - - - -
            // X - - -
            // X - - -
            // - - - -
            if ((i > 0 && i < (matrix.Length - 1)) && j == 0 )
            {
                if (matrix[i-1][j].Equals(cdtMatrix.c_LifeCharacter)) count++;
                if (matrix[i-1][j + 1].Equals(cdtMatrix.c_LifeCharacter)) count++;
                if (matrix[i][j + 1].Equals(cdtMatrix.c_LifeCharacter)) count++;
                if (matrix[i + 1][j + 1].Equals(cdtMatrix.c_LifeCharacter)) count++;
                if (matrix[i + 1][j].Equals(cdtMatrix.c_LifeCharacter)) count++;

            }
            // - - - -
            // - - - -
            // - - - -
            // X - - -
            if (i == (matrix.Length - 1) && j == 0 )
            {
                if (matrix[i-1][j].Equals(cdtMatrix.c_LifeCharacter)) count++;
                if (matrix[i-1][j+1].Equals(cdtMatrix.c_LifeCharacter)) count++;
                if (matrix[i][j+1].Equals(cdtMatrix.c_LifeCharacter)) count++;


            }

            // - - - -
            // - - - -
            // - - - -
            // - X X -
            if (i == matrix.Length - 1 && (j > 0 && j < (matrix[i].Length - 1)))
            {
                if (matrix[i - 1][j - 1].Equals(cdtMatrix.c_LifeCharacter)) count++;
                if (matrix[i - 1][j].Equals(cdtMatrix.c_LifeCharacter)) count++;
                if (matrix[i - 1][j + 1].Equals(cdtMatrix.c_LifeCharacter)) count++;
                if (matrix[i][j + 1].Equals(cdtMatrix.c_LifeCharacter)) count++;
                if (matrix[i][j - 1].Equals(cdtMatrix.c_LifeCharacter)) count++;
            }

            // - - - -
            // - - - X
            // - - - X
            // - - - -
            if (j == matrix[i].Length - 1 && (i > 0 && i < (matrix.Length - 1)))
            {
                if (matrix[i - 1][j].Equals(cdtMatrix.c_LifeCharacter)) count++;
                if (matrix[i - 1][j - 1].Equals(cdtMatrix.c_LifeCharacter)) count++;
                if (matrix[i][j - 1].Equals(cdtMatrix.c_LifeCharacter)) count++;
                if (matrix[i + 1][j - 1].Equals(cdtMatrix.c_LifeCharacter)) count++;
                if (matrix[i + 1][j].Equals(cdtMatrix.c_LifeCharacter)) count++;
            }

            // - - - -
            // - - - -
            // - - - -
            // - - - X
            if (i == matrix.Length - 1 && j == matrix[matrix.Length - 1].Length - 1)
            {
                if (matrix[i - 1][j].Equals(cdtMatrix.c_LifeCharacter)) count++;
                if (matrix[i][j - 1].Equals(cdtMatrix.c_LifeCharacter)) count++;
                if (matrix[i - 1][j - 1].Equals(cdtMatrix.c_LifeCharacter)) count++;
            }

            // - - - -
            // - X - -
            // - - - -
            // - - - -
            if (i != 0 && j != 0 && i != matrix.Length - 1 && j != matrix[matrix.Length - 1].Length - 1)
            {
                if (matrix[i-1][j-1].Equals(cdtMatrix.c_LifeCharacter)) count++;
                if (matrix[i-1][j].Equals(cdtMatrix.c_LifeCharacter)) count++;
                if (matrix[i-1][j+1].Equals(cdtMatrix.c_LifeCharacter)) count++;
                if (matrix[i][j-1].Equals(cdtMatrix.c_LifeCharacter)) count++;
                if (matrix[i][j+1].Equals(cdtMatrix.c_LifeCharacter)) count++;
                if (matrix[i+1][j-1].Equals(cdtMatrix.c_LifeCharacter)) count++;
                if (matrix[i+1][j].Equals(cdtMatrix.c_LifeCharacter)) count++;
                if (matrix[i+1][j+1].Equals(cdtMatrix.c_LifeCharacter)) count++;
            }



            return count;

        }

    }
}