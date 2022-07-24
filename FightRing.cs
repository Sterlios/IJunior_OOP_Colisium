﻿using Colisium.Control;
using Colisium.Fighters;
using System.Collections.Generic;

namespace Colisium
{
    class FightRing
    {
        private StringCreator _stringCreator;
        private IDataInput _dataInput;
        private List<Manager> _managers;
        private bool _opening;
        private string _name;

        public FightRing(string name, StringCreator stringCreator, IDataInput dataInput)
        {
            _name = name;
            _stringCreator = stringCreator;
            _dataInput = dataInput;
            _stringCreator.ShowMessage("Создан новый ринг: " + _name);

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
                    manager.TakeUser(new User("Петя", _dataInput, _stringCreator));
                }

                manager.Work(out BaseFighter LeftFighter, out BaseFighter RightFighter);

                if(LeftFighter is BaseFighter && RightFighter is BaseFighter)
                {
                    Fight fight = new Fight(LeftFighter, RightFighter, _stringCreator);
                    fight.Start();
                }
            }
        }

        private void Open()
        {
            if (_managers.Count > 0)
            {
                _opening = true;
                _stringCreator.ShowMessage("Ринг " + _name + " открыт.");

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
                _stringCreator.ShowMessage("Ринг " + _name + " закрыт.");
            }
        }

        private void initializeManagers()
        {
            _managers = new List<Manager>();
            _managers.Add(new Manager("Ваня", _stringCreator));
            _managers.Add(new Manager("Gtnz", _stringCreator));
        }
    }
}
