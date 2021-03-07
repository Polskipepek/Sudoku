using Sudoku.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sudoku.Game {
    public class GameLoop : Singleton<GameLoop> {

        public bool IsGameMode { get; private set; } = false;
        public List<Field> Fields { get; init; }

        public void StartGame () {
            IsGameMode = true;
            MainGameLoop ();
        }

        private void MainGameLoop () {
            while (IsGameMode) {
                Console.WriteLine ("Write");
                var input = Console.ReadLine ();
                var feedback = InputReader.ReadInput (input, out FieldPosition fieldPosition, out int number);
                if (feedback) {
                    WriteNumber (fieldPosition, number);
                } else {
                    Console.WriteLine ("error");
                }
            }
        }

        private void WriteNumber (FieldPosition fieldPosition, int newNumber) {
            Fields.First (field => field.FieldPosition == fieldPosition).ChangeNumber (newNumber);
        }
    }
}
