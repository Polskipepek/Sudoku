using Sudoku.Game;
using System;

namespace Sudoku {
    class Program {
        static void Main () {
            int[][] nums = SudokuGenerator.Instance.GenerateSudokuNumbers ();
            Console.WriteLine ("Hello World!");

            for (int x = 0; x < 9; x++) {
                for (int y = 0; y < 9; y++) {
                    Console.Write (nums[x][y] + "   ");
                }
                Console.WriteLine ();
                Console.WriteLine ();
            }

            Console.ReadLine ();
        }
    }
}