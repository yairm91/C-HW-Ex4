namespace Ex4.Menus.Interfaces
{
    public abstract class MenuItem
    {
        private string m_MenuItemName;
        private int m_ItemIndex = -1;

        public string MenuName
        {
            get
            {
                return m_MenuItemName;
            }
        }

        public int ItemIndex
        {
            get
            {
                return m_ItemIndex;
            }

            set
            {
                m_ItemIndex = value;
            }
        }

        public MenuItem(string i_MenuItemName)
        {
            m_MenuItemName = i_MenuItemName;
        }

        public abstract void Activate();
    }
}
