using System;

namespace Ex04.Menus.Delegates
{
    public class OperationMenuItem : MenuItem
    {
        public event Action<OperationMenuItem> Selected;

        public OperationMenuItem(string i_MenuItemName) : base(i_MenuItemName)
        {
        }

        private void OnSelected()
        {
            if(Selected != null)
            {
                Selected.Invoke(this);
            }
        }

        public override void Activate()
        {
            OnSelected();
        }
    }
}
