namespace Ex04.Menus.Interfaces
{
    public class OperationMenuItem : MenuItem
    {
        private IAction m_ActionListener;

        public IAction ActionListener
        {
            set
            {
                if (m_ActionListener == null)
                {
                    m_ActionListener = value;
                }   
            }
        }

        public OperationMenuItem(string i_MenuItemName) : base(i_MenuItemName)
        {
        }

        private void notifyListener()
        {
            m_ActionListener.ReportAction(MenuName);
        }

        public override void Activate()
        {
            notifyListener();
        }
    }
}
