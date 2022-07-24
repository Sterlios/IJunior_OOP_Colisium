using Colisium.Control;

namespace Colisium
{
    class User
    {
        private StringCreator _stringCreator;
        private IDataInput _dataInput;
        public string Name { get; private set; }

        public User(string name, IDataInput dataInput, StringCreator stringCreator)
        {
            _dataInput = dataInput;
            Name = name;
            _stringCreator = stringCreator;

            _stringCreator.ShowMessage("Появился новый клиент " + Name);
        }

        public bool getAnswerYesOrNo()
        {
            const string YesWord = "y";
            const string NoWord = "n";
            bool isCorrect = true;

            string command = _dataInput.GetText();

            if (command.ToLower() == YesWord)
            {
                isCorrect = true;
            }
            else if (command.ToLower() == NoWord)
            {
                isCorrect = false;
            }
            else
            {
                isCorrect = getAnswerYesOrNo();
            }

            _dataInput.ClearPosition();
            return isCorrect;
        }

        public string getAnswer()
        {
            _dataInput.ClearPosition();
            string answer = _dataInput.GetText();
            _dataInput.ClearPosition();
            return answer;
        }
    }
}
