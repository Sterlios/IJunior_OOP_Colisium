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

        public string GetAnswer()
        {
            string answer = _dataInput.GetText();
            _dataInput.ClearPosition();
            return answer;
        }
    }
}
