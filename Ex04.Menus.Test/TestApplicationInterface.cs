using System;
using System.Collections.Generic;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    internal class TestApplicationInterface : IAction
    {
        private const string k_MainMenuName = "Main Menu";
        private const string k_ActionsAndInfoMenuName = "Actions and Info";
        private const string k_DisplayVersionMenuName = "Display Version";
        private const string k_ActionsMenuName = "Actions";
        private const string k_CountSpacesMenuName = "Count spaces";
        private const string k_CharCountMenuName = "Chars count";
        private const string k_ShowDateOrTimeMenuName = "Show Date/Time";
        private const string k_ShowTimeMenuName = "Show Time";
        private const string k_ShowDateMenuName = "Show Date";
        private const string k_AppVersion = "App Version: 17.2.4.0";

        private MainMenu m_MainMenu;

        public TestApplicationInterface()
        {
            List<MenuItem> listOfMenus = createListOfMenus();
            m_MainMenu = new MainMenu(k_MainMenuName, listOfMenus);
        }

        private List<MenuItem> createListOfMenus()
        {
            List<MenuItem> listOfMenus = new List<MenuItem>();

            List<MenuItem> actionsAndInfoMenusItems = createActionsAndInfoMenusItems();
            MainMenu actionsAndInfo = new MainMenu(k_ActionsAndInfoMenuName, actionsAndInfoMenusItems);
            listOfMenus.Add(actionsAndInfo);

            List<MenuItem> showDateAndTimeMenusItems = createDateAndTimeMenusItems();
            MainMenu showDateAndTime = new MainMenu(k_ShowDateOrTimeMenuName, showDateAndTimeMenusItems);
            listOfMenus.Add(showDateAndTime);

            return listOfMenus;
        }

        private List<MenuItem> createDateAndTimeMenusItems()
        {
            List<MenuItem> listOfMenus = new List<MenuItem>();

            OperationMenuItem showDateMenuItem = new OperationMenuItem(k_ShowDateMenuName);
            showDateMenuItem.ActionListener = this;
            listOfMenus.Add(showDateMenuItem);

            OperationMenuItem showTimeMenuItem = new OperationMenuItem(k_ShowTimeMenuName);
            showTimeMenuItem.ActionListener = this;
            listOfMenus.Add(showTimeMenuItem);

            return listOfMenus;
        }

        private void showTimeMenuItem()
        {
            Console.Clear();
            string timeToPrint = DateTime.Now.ToShortTimeString();
            Console.WriteLine(timeToPrint);
            Show();
        }

        private List<MenuItem> createActionsAndInfoMenusItems()
        {
            List<MenuItem> listOfMenus = new List<MenuItem>();

            OperationMenuItem displayMenuItem = new OperationMenuItem(k_DisplayVersionMenuName);
            displayMenuItem.ActionListener = this;
            listOfMenus.Add(displayMenuItem);

            List<MenuItem> actionsMenusItems = createActionsMenusItems();
            MainMenu actions = new MainMenu(k_ActionsMenuName, actionsMenusItems);
            listOfMenus.Add(actions);

            return listOfMenus;
        }

        private List<MenuItem> createActionsMenusItems()
        {
            List<MenuItem> listOfMenus = new List<MenuItem>();

            OperationMenuItem countSpaces = new OperationMenuItem(k_CountSpacesMenuName);
            countSpaces.ActionListener = this;
            listOfMenus.Add(countSpaces);

            OperationMenuItem charCount = new OperationMenuItem(k_CharCountMenuName);
            charCount.ActionListener = this;
            listOfMenus.Add(charCount);

            return listOfMenus;
        }

        private void showDateMenuItem()
        {
            Console.Clear();
            string dateToPrint = DateTime.Now.ToShortDateString();
            Console.WriteLine(dateToPrint);
            Show();
        }

        private void showVersionMenuItem()
        {
            Console.Clear();
            Console.WriteLine(k_AppVersion);
            Show();
        }

        private void countSpacesMenuItem()
        {
            Console.Clear();
            Console.WriteLine("Please enter a sentence");

            string sentence = Console.ReadLine();
            int counterOfSpaces = 0;
            foreach (char character in sentence)
            {
                if (char.IsWhiteSpace(character))
                {
                    counterOfSpaces++;
                }
            }

            Console.WriteLine(string.Format("There is {0} spaces in the string.", counterOfSpaces));

            Show();
        }

        private void charCountMenuItem()
        {
            Console.Clear();
            Console.WriteLine("Please enter a sentence");
            string sentence = Console.ReadLine();
            int counterOfLetters = 0;
            foreach (char character in sentence)
            {
                if (char.IsLetter(character))
                {
                    counterOfLetters++;
                }
            }

            Console.WriteLine(string.Format("There is {0} letters in the string.", counterOfLetters));

            Show();
        }

        public void Show()
        {
            m_MainMenu.Show();
        }

        public void ReportAction(string i_NameOfAction)
        {
            if (i_NameOfAction.Equals(k_DisplayVersionMenuName))
            {
                showVersionMenuItem();
            }
            else if (i_NameOfAction.Equals(k_ShowDateMenuName))
            {
                showDateMenuItem();
            }
            else if (i_NameOfAction.Equals(k_ShowTimeMenuName))
            {
                showTimeMenuItem();
            }
            else if (i_NameOfAction.Equals(k_CountSpacesMenuName))
            {
                countSpacesMenuItem();
            }
            else if (i_NameOfAction.Equals(k_CharCountMenuName))
            {
                charCountMenuItem();
            }
        }
    }
}
