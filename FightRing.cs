using Colisium.Control;
using Colisium.Display;
using System.Collections.Generic;

namespace Colisium
{
    class FightRing : IString
    {
        private IDisplay _display;
        private IDataInput _dataInput;
        private List<Manager> _managers;
        private bool _opening;
        private string _text;
        private string _name;

        public FightRing(string name, IDisplay display, IDataInput dataInput)
        {
            _name = name;
            _display = display;
            _dataInput = dataInput;
            _text = "Создан новый ринг: " + _name;
            _display.Display(this);

            initializeManagers();
        }

        public void Run()
        {
            Open();

            while (_opening)
            {
                foreach (Manager manager in _managers)
                {
                    WorkManager(manager);
                }

                Close();
            }
        }

        private void WorkManager(Manager manager)
        {
            while (manager.Working)
            {
                if (manager.User is null)
                {
                    manager.TakeUser(new User("Петя", _dataInput, _display));
                }

                manager.Work();
            }
        }

        private void Open()
        {
            if (_managers.Count > 0)
            {
                _opening = true;
                _text = "Ринг " + _name + " открыт.";
                _display.Display(this);

                foreach (Manager manager in _managers)
                {
                    manager.BeginWork();
                }
            }
        }

        private void Close()
        {
            _opening = false;

            foreach (Manager manager in _managers)
            {
                if (manager.Working)
                {
                    _opening = manager.Working;
                }
            }

            if (_opening == false)
            {
                _text = "Ринг " + _name + " закрыт.";
                _display.Display(this);
            }
        }

        public override string ToString()
        {
            return _text;
        }

        private void initializeManagers()
        {
            _managers = new List<Manager>();
            _managers.Add(new Manager("Ваня", _display));
        }
    }
}
