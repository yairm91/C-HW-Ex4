﻿using System;
using Ex04.Menus.Delegates;

namespace Ex04.Menus.Delegate
{
    public delegate void MenuItemDelegate();

    public class OperationMenuItem : MenuItem
    {
        public event MenuItemDelegate Selected;

        public OperationMenuItem(string i_MenuItemName) : base(i_MenuItemName)
        {
        }

        private void OnSelected()
        {
            if(Selected != null)
            { 
                Selected.Invoke();
            }
        }

        public override void Activate()
        {
            Console.Clear();
            OnSelected();
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
            PreviousMenu.Show();
        }
    }
}
