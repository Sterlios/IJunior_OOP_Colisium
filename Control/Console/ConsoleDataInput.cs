using System;
using System.Collections.Generic;
using System.Text;

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

            _position.SetCursorPosition();
            _answer = System.Console.ReadLine();

            return _answer;
        }

        private void ClearText()
        {
            _position.SetCursorPosition();

            for (int i = 0; i < _answer.Length; i++)
            {
                System.Console.Write(" ");
            }
        }
    }
}
