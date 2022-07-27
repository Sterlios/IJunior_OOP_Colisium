namespace Colisium.Control.Console
{
    class ConsoleDataInput : IDataInput
    {
        private string _answer;
        private Position _position;

        public ConsoleDataInput()
        {
            _answer = "";
        }

        public string GetText()
        {
            if (_position is null)
            {
                _position = new Position();
            }

            ClearText();

            _position.MoveCursor();
            _answer = System.Console.ReadLine();

            return _answer;
        }

        public void ClearPosition()
        {
            _position = null;
        }

        private void ClearText()
        {
            _position.MoveCursor();

            for (int i = 0; i < _answer.Length; i++)
            {
                System.Console.Write(" ");
            }
        }
    }
}
