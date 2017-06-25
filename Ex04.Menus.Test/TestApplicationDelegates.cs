﻿using System;
using System.Collections.Generic;
using Ex04.Menus.Delegates;
using Ex04.Menus.Delegate;

namespace Ex04.Menus.Test
{
    internal class TestApplicationDelegates
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

        public TestApplicationDelegates()
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
            showDateMenuItem.Selected += showDateMenuItem_Select;
            listOfMenus.Add(showDateMenuItem);

            OperationMenuItem showTimeMenuItem = new OperationMenuItem(k_ShowTimeMenuName);
            showTimeMenuItem.Selected += showTimeMenuItem_Select;
            listOfMenus.Add(showTimeMenuItem);

            return listOfMenus;
        }

        private void showTimeMenuItem_Select()
        {
            string timeToPrint = DateTime.Now.ToShortTimeString();
            Console.WriteLine(timeToPrint);
        }

        private List<MenuItem> createActionsAndInfoMenusItems()
        {
            List<MenuItem> listOfMenus = new List<MenuItem>();

            OperationMenuItem displayMenuItem = new OperationMenuItem(k_DisplayVersionMenuName);
            displayMenuItem.Selected += showVersionMenuItem_Select;
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
            countSpaces.Selected += countSpacesMenuItem_Select;
            listOfMenus.Add(countSpaces);

            OperationMenuItem charCount = new OperationMenuItem(k_CharCountMenuName);
            charCount.Selected += charCountMenuItem_Select;
            listOfMenus.Add(charCount);

            return listOfMenus;
        }

        private void showDateMenuItem_Select()
        {
            string dateToPrint = DateTime.Now.ToShortDateString();
            Console.WriteLine(dateToPrint);
        }

        private void showVersionMenuItem_Select()
        {
            Console.WriteLine(k_AppVersion);
        }

        private void countSpacesMenuItem_Select()
        {
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
        }

        private void charCountMenuItem_Select()
        {
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
        }

        public void Show()
        {
            m_MainMenu.Show();
        }
    }
}
