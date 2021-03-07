using Sudoku.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sudoku.Game {
    public class SudokuGenerator : Singleton<SudokuGenerator> {
        Random Random = new Random ();

        public void Generate () {
            var tempFields = new List<Field> ();
            for (int x = 0; x < 8; x++) {
                for (int y = 0; y < 8; y++) {
                    var fieldPosition = new FieldPosition { X = x, Y = y };
                    tempFields.Add (new Field (fieldPosition) { });
                }
            }
        }

        List<int> GetNumbers () {
            List<int> nums = new List<int> ();
            while (nums.Count < 9) {
                var num = Random.Next (1, 10);
                if (!nums.Contains (num)) {
                    nums.Add (num);
                }
            }
            return nums;
        }

        public int[][] GenerateSudokuNumbers () {
            int[][] nums = new int[9][];
            for (int i = 0; i < nums.Length; i++) {
                nums[i] = new int[9];
            }
            int sum = 0;

            for (int x = 0; x < 9; x++) {
                var numbersToAssign = GetNumbers ();
                for (int y = 0; y < 9; y++) {
                    var index = Random.Next (numbersToAssign.Count);

                    var doesContainInX = nums[x].Contains (numbersToAssign[index]);
                    while (doesContainInX && sum < 9) {
                        index = Random.Next (numbersToAssign.Count);
                        sum++;
                        doesContainInX = nums[x].Contains (numbersToAssign[index]);
                    }

                    var doesContainInY = DoesContainInY (nums, numbersToAssign[index], x, y);
                    var isDuplicateInSmallSquare = IsDuplicateInSmallSquare (x, y, numbersToAssign[index], nums);

                    if (doesContainInX || doesContainInY || isDuplicateInSmallSquare) {
                        numbersToAssign = GetNumbers ();
                        y = 0;
                    } else {
                        nums[x][y] = numbersToAssign[index];
                        numbersToAssign.RemoveAt (index);
                        sum = 0;
                    }
                }
            }
            return nums;
        }
        bool DoesContainInY (int[][] nums, int number, int X, int Y) {
            for (int y = 0; y < 9; y++) {
                if (Y != y && nums[X][y] == number) {
                    return true;
                }
            }
            return false;
        }
        bool IsDuplicateInSmallSquare (int x, int y, int number, int[][] nums) {
            int xSquare = (x + 3) / 3;
            int ySquare = (y + 3) / 3;

            int leftBorder = (xSquare - 1) * 3 + 1;
            int rightBorder = (xSquare - 1) * 3 + 3;
            int lowerBorder = (ySquare - 1) * 3 + 1;
            int upperBorder = (ySquare - 1) * 3 + 3;

            for (int X = leftBorder; X < rightBorder; X++) {
                for (int Y = lowerBorder; Y < upperBorder; Y++) {
                    if (nums[x][y] == number)
                        return true;
                }
            }
            return false;
        }
    }
}
