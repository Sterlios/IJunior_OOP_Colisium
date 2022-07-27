using Colisium.Fighters;
using System.Collections.Generic;

namespace Colisium
{
    class Manager
    {
        private List<BaseFighter> _fighters;
        private StringCreator _stringCreator;
        private string _name;
        private Position _answerCursorPosition;
        public bool IsWorking { get; private set; }
        public User User { get; private set; }

        public Manager(string name, StringCreator stringCreator)
        {
            _name = name;
            _stringCreator = stringCreator;

            InitializeFighters();

            _stringCreator.ShowMessage("Менеджер " + _name + " принят на работу");
        }

        public void TakeUser(User user)
        {
            User = user;
        }

        public void Work(out BaseFighter leftFighter, out BaseFighter rightFighter)
        {
            leftFighter = null;
            rightFighter = null;

            if (IsWorking)
            {
                _stringCreator.ShowMessage("Менеджер " + _name + " работает");

                if (ToContinue())
                {
                    ShowFighters();
                    leftFighter = GetFighter("слева");
                    rightFighter = GetFighter("справа");
                }
                else
                {
                    EndWork();
                }
            }
        }

        public void StartWork()
        {
            if (IsWorking == false)
            {
                _stringCreator.ShowMessage("Менеджер " + _name + " начал работать");
                IsWorking = true;
            }
        }

        public bool EndWork()
        {
            if (IsWorking)
            {
                _stringCreator.ShowMessage("Менеджер " + _name + " закончил работать");
                IsWorking = false;
            }

            return IsWorking;
        }

        private bool ToContinue()
        {
            if (User is User)
            {
                MoveCursor();
                _stringCreator.ShowMessage(User.Name + ", продолжаем работу? (Y/N) ");
                const string YesWord = "y";
                const string NoWord = "n";
                bool isCorrect;

                string command = User.GetAnswer();

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
                    isCorrect = ToContinue();
                }

                _answerCursorPosition = null;
                return isCorrect;
            }
            else
            {
                return false;
            }
        }

        private void ShowFighters()
        {
            _stringCreator.ShowMessage("Доступные бойцы:");

            foreach (BaseFighter fighter in _fighters)
            {
                fighter.ShowInfo();
            }
        }

        private void InitializeFighters()
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

            MoveCursor();
            _stringCreator.ShowMessage(User.Name + ", Выберите бойца для сражения " + fighterSide);

            string fighterName = User.GetAnswer();

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

            _answerCursorPosition = null;

            return chosenFighter;
        }

        private void MoveCursor()
        {
            if (_answerCursorPosition is null)
            {
                _answerCursorPosition = new Position();
            }

            _answerCursorPosition.MoveCursor();
        }
    }
}
