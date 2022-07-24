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
            }
        }
    }
}
