namespace Sudoku.Game {
    public class Field {
        public FieldPosition FieldPosition { get; }
        public bool IsInteractable => !IsDefinedOnInit && Number != DesireNumber;
        public int Number { get; private set; }
        public int DesireNumber { get; init; }
        public bool IsDefinedOnInit { get; init; }

        public Field (FieldPosition fieldPosition) {
            FieldPosition = fieldPosition;
        }
        public void ChangeNumber (int newNumber) {
            Number = newNumber;
        }
    }
}
