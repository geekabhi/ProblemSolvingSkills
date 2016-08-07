using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameofLifeConway
{
    class Program
    {
        static void Main(string[] args)
        {
            if (int.Parse(args[0]) < 2)
            {
                Console.WriteLine("No Game of life");
                Console.ReadLine();
                return;
            }


            //cdtMatrix objmatrix;

            string[][] matrix;

            matrix = Matrix.IntializeSquareSizeMatrix( int.Parse(args[0]));
            matrix = Matrix.FillDeadCellInMatrix(matrix);

            string[] populateInput = args.Skip(1).ToArray();

            matrix = Matrix.LoadMatrix(matrix, populateInput);

            
            Console.ForegroundColor = ConsoleColor.Yellow;

            Matrix.PrintMatrixOnConsle(matrix);

            string[][] temp ;

            for (;;)
            {
                Console.WriteLine();
                Console.WriteLine();

                temp = Matrix.GameofLife(matrix);

                Matrix.PrintMatrixOnConsle(temp);

                matrix = temp;

                System.Threading.Thread.Sleep(200);
                Console.Clear();
            }


            Console.ReadLine();
        }
    }
}
