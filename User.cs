using Colisium.Control;
using Colisium.Display;
using System;
using System.Collections.Generic;
using System.Text;

namespace Colisium
{
    class User : IString
    {
        private IDataInput _dataInput;
        private IDisplay _display;
        private string _text;
        public string Name { get; private set; }

        public User(string name, IDataInput dataInput, IDisplay display)
        {
            _display = display;
            _dataInput = dataInput;
            Name = name;

            _text = "Появился новый клиент " + Name;
            _display.Display(this);
        }

        public bool getAnswerYesOrNo()
        {
            const string YesWord = "y";
            const string NoWord = "n";

            string command = _dataInput.GetText();

            if (command.ToLower() == YesWord)
            {
                return true;
            }
            else if (command.ToLower() == NoWord)
            {
                return false;
            }
            else
            {
                return getAnswerYesOrNo();
            }
        }

        public override string ToString()
        {
            return _text;
        }
    }
}
