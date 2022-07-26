using Colisium.Fighters;
using System.Collections.Generic;

namespace Colisium
{
    class Manager
    {
        private List<BaseFighter> _fighters;
        private StringCreator _stringCreator;
        public bool Working { get; private set; }
        private string _name;
        public User User { get; private set; }
        private Position _chosenFighterPosition;

        public Manager(string name, StringCreator stringCreator)
        {
            _name = name;
            _stringCreator = stringCreator;

            initializeFighters();

            _stringCreator.ShowMessage("Менеджер " + _name + " принят на работу");
        }

        public void TakeUser(User user)
        {
            User = user;
        }

        public void Work(out BaseFighter LeftFighter, out BaseFighter RightFighter)
        {
            LeftFighter = null;
            RightFighter = null;

            if (Working)
            {
                _stringCreator.ShowMessage("Менеджер " + _name + " работает");

                if (ToContinue())
                {
                    ShowFighters();
                    LeftFighter = GetFighter("слева");
                    RightFighter = GetFighter("справа");
                }
                else
                {
                    EndWork();
                }
            }
        }

        public void BeginWork()
        {
            if (Working == false)
            {
                _stringCreator.ShowMessage("Менеджер " + _name + " начал работать");
                Working = true;
            }
        }

        public bool EndWork()
        {
            if (Working)
            {
                _stringCreator.ShowMessage("Менеджер " + _name + " закончил работать");
                Working = false;
            }

            return Working;
        }

        private bool ToContinue()
        {
            if (User is User)
            {
                _stringCreator.ShowMessage(User.Name + ", продолжаем работу? (Y/N) ");
                return User.getAnswerYesOrNo();
            }
            else
            {
                return false;
            }
        }

        private void ShowFighters()
        {
            _stringCreator.ShowMessage("Доступные бойцы:");

            foreach (IFighter fighter in _fighters)
            {
                fighter.ShowInfo();
            }
        }

        private void initializeFighters()
        {
            _fighters = new List<BaseFighter>()
            {
                new Assassin(_stringCreator),
                new Priest(_stringCreator),
                new Warior(_stringCreator),
                new IceMan(_stringCreator),
                new Viking(_stringCreator)
            };
        }

        private BaseFighter GetFighter(string fighterSide)
        {
            BaseFighter chosenFighter = null;

            SetChosenFighterPosition();
            _stringCreator.ShowMessage(User.Name + ", Выберите бойца для сражения " + fighterSide);

            string fighterName = User.getAnswer();

            foreach (BaseFighter fighter in _fighters)
            {
                if (fighter.Class.ToLower() == fighterName.ToLower())
                {
                    chosenFighter = fighter.ToCopy();
                }
            }

            if(chosenFighter is null)
            {
                chosenFighter = GetFighter(fighterSide);
            }

            _chosenFighterPosition = null;

            return chosenFighter;
        }

        private void SetChosenFighterPosition()
        {
            if (_chosenFighterPosition is null)
            {
                _chosenFighterPosition = new Position();
            }

            _chosenFighterPosition.SetCursorPosition();
        }
    }
}
