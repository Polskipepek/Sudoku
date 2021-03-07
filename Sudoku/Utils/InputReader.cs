using Sudoku.Game;

namespace Sudoku.Utils {
    public class InputReader : Singleton<InputReader> {

        public static bool ReadInput (string input, out FieldPosition fieldPosition, out int number) {
            fieldPosition = null;
            number = 0;
            if (input.Length < 5) {
                return false;
            }

            char x = input[0];
            char y = input[2];
            number = input[4];
            fieldPosition = new FieldPosition () { X = x, Y = y };

            return true;
        }
    }
}