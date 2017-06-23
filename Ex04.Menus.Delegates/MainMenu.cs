using System;
using System.Collections.Generic;

namespace Ex4.Menus.Delegates
{
    public class MainMenu : MenuItem
    {
        private const string k_ExitMenu = "0. Exit";
        private const string k_Exit = "exit";
        private const string k_Back = "go back";
        private const string k_UnderLineForHeader = @"
==============
";

        private const string k_One = "1";
        private const string k_BackMenu = "0. Back";
        private const string k_MenuItemTemplate = "{0}. {1}";
        private const string k_WrongInputString = "Wrong Input! Must be an integer between {0} and {1}, please try again";
        private const string k_UserChoiceQuestionString = "Please enter your choice ({0}-{1} or 0 to {2}";
        private List<MenuItem> m_MenuItems;
        private MainMenu m_PreviousMenu = null;
    
        public MainMenu PreviousMenu
        {
            get
            {
                return m_PreviousMenu;
            }

            set
            {
                m_PreviousMenu = value;
            }
        }

        public MainMenu(string i_MenuItemName, List<MenuItem> i_MenuItems) : base(i_MenuItemName)
        {
            m_MenuItems = i_MenuItems;
            int itemIndex = 0;
            foreach (MenuItem menuItem in m_MenuItems)
            {
                menuItem.ItemIndex = itemIndex;
                MainMenu menuItemAsMainMenu = menuItem as MainMenu;
                if(menuItemAsMainMenu != null)
                {
                    menuItemAsMainMenu.PreviousMenu = this;
                }

                itemIndex++;
            }    
        }

        public void Show()
        {
            Console.Clear();
            if (m_PreviousMenu == null)
            {
                writeFirstMenu();
            }
            else
            {
                writeRegularMenu();
            }

            int indexOfOption = getAnswerFromUser();
            navigateToNextItem(indexOfOption);
        }

        private void navigateToNextItem(int i_IndexOfOption)
        {
            m_MenuItems[i_IndexOfOption].Activate();
        }

        private int getAnswerFromUser()
        {
            bool isAnswerValid = false;
            int answerFromUserIndex = -1;
            while (!isAnswerValid)
            {
                string answerFromUser = Console.ReadLine();
                isAnswerValid = validateAnswerFromUser(answerFromUser, out answerFromUserIndex);
            }

            return answerFromUserIndex;
        }

        private bool validateAnswerFromUser(string i_AnswerFromUser, out int o_AnswerFromUserIndex)
        {
            bool didParseWork = int.TryParse(i_AnswerFromUser, out o_AnswerFromUserIndex);
       
            if (!didParseWork || (didParseWork && (o_AnswerFromUserIndex < 0 || o_AnswerFromUserIndex > m_MenuItems.Count)))
            {
                didParseWork = false;
                Console.WriteLine(string.Format(k_WrongInputString, k_One, m_MenuItems.Count));
            }

            return didParseWork;
        }

        private void writeRegularMenu()
        {
            string header = string.Format(k_MenuItemTemplate, ItemIndex, MenuName);
            writeHeader(header);
            writeMenuItems(m_MenuItems);
            Console.WriteLine(k_BackMenu);
            writeUserChoice(m_MenuItems.Count, k_Back);
        }

        private void writeFirstMenu()
        {
            writeHeader(MenuName);
            writeMenuItems(m_MenuItems);
            Console.WriteLine(k_ExitMenu);
            writeUserChoice(m_MenuItems.Count, k_Exit);
        }

        private void writeUserChoice(int i_Count, string i_LastOption)
        {
            Console.WriteLine(string.Format(k_UserChoiceQuestionString, k_One, i_Count, i_LastOption));
        }

        private void writeMenuItems(List<MenuItem> i_MenuItems)
        {
            foreach (MenuItem menuItem in i_MenuItems)
            {
                Console.WriteLine(string.Format(k_MenuItemTemplate, menuItem.ItemIndex, menuItem.MenuName));
            }
        }

        private void writeHeader(string i_MenuName)
        {
            Console.WriteLine(i_MenuName);
            Console.WriteLine(k_UnderLineForHeader);
        }

        public override void Activate()
        {
            Show();
        }
    }
}
