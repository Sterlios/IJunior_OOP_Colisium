using Colisium.Display;

namespace Colisium
{
    class StringCreator : IString
    {
        private string _message;
        public IDisplay Display { get; private set; }

        public StringCreator(IDisplay display)
        {
            Display = display;
        }

        public void ShowMessage(string message)
        {
            _message = message;
            Display.Display(this);
        }

        public override string ToString() => _message;
    }
}
