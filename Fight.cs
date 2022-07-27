using Colisium.Fighters;

namespace Colisium
{
    class Fight
    {
        private BaseFighter _leftFighter;
        private BaseFighter _rightFighter;
        private StringCreator _stringCreator;

        public Fight(BaseFighter leftFighter, BaseFighter rightFighter, StringCreator stringCreator)
        {
            _leftFighter = leftFighter;
            _rightFighter = rightFighter;
            _stringCreator = stringCreator;
        }

        public void Start()
        {
            while(_leftFighter.IsAlive && _rightFighter.IsAlive)
            {
                _leftFighter.ShowInfo();
                _rightFighter.ShowInfo();

                if (_leftFighter.IsAlive)
                {
                    _rightFighter.TakeDamage(_leftFighter.Attack());
                }

                if (_rightFighter.IsAlive)
                {
                    _leftFighter.TakeDamage(_rightFighter.Attack());
                }

                _stringCreator.ShowMessage("\n");
            }

            _leftFighter.ShowInfo();
            _rightFighter.ShowInfo();
            End();
        }

        private void End()
        {
            if (_leftFighter.IsAlive == false && _rightFighter.IsAlive == false)
            {
                _stringCreator.ShowMessage("Ничья!");
            }
            else if (_leftFighter.IsAlive == false)
            {
                _stringCreator.ShowMessage(_rightFighter.Class + " справа Победил");
            }
            else
            {
                _stringCreator.ShowMessage(_leftFighter.Class + " слева Победил");
            }
        }
    }
}
