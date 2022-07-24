using Colisium.Display;
using Colisium.Fighters;
using System.Collections.Generic;

namespace Colisium
{
    class Manager : IString
    {
        private List<BaseFighter> _fighters;
        private IDisplay _display;
        private bool _isWork;
        public bool Working { get; private set; }
        private string _text;
        private string _name;
        public User User { get; private set; }

        public Manager(string name, IDisplay display)
        {
            _display = display;
            _name = name;

            _fighters = new List<BaseFighter>()
            {
                new Assassin(),
                new Priest(),
                new Warior(),
                new IceMen(),
                new Viking()
            };

            _text = "Менеджер " + _name + " принят на работу";
            _display.Display(this);
        }

        public void TakeUser(User user)
        {
            User = user;
        }

        public void Work()
        {
            if (Working)
            {
                _text = "Менеджер " + _name + " работает";
                _display.Display(this);

                if (ToContinue())
                {

                }

                EndWork();
            }
        }

        public override string ToString()
        {
            return _text;
        }

        public void BeginWork()
        {
            if (Working == false)
            {
                _text = "Менеджер " + _name + " начал работать";
                _display.Display(this);
                Working = true;
            }
        }

        public bool EndWork()
        {
            if (Working)
            {
                _text = "Менеджер " + _name + " закончил работать";
                _display.Display(this);
                Working = false;
            }

            return Working;
        }

        private bool ToContinue()
        {
            if (User is User)
            {
                _text = User.Name + ", продолжаем работу? (Y/N) ";
                _display.Display(this);
                return User.getAnswerYesOrNo();
            }
            else
            {
                return false;
            }
        }
    }
}
