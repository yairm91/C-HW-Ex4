using System;

namespace Ex4.Menus.Interfaces
{
    public class OperationMenuItem : MenuItem
    {
        public event Action<string> Selected;

        public OperationMenuItem(string i_MenuItemName) : base(i_MenuItemName)
        {
        }

        private void OnSelected()
        {
            if (Selected != null)
            {
                Selected.Invoke(MenuName);
            }
        }

        public override void Activate()
        {
            OnSelected();
        }
    }
}
