using System;

namespace Ex04.Menus.Test
{
    public class Program
    {
        public static void Main()
        {
            runDelegateApp();
            Console.Clear();
            runInterfaceApp();
        }

        private static void runInterfaceApp()
        {
            TestApplicationInterface interfaceTestApp = new TestApplicationInterface();
            interfaceTestApp.Show();
        }

        private static void runDelegateApp()
        {
            TestApplicationDelegates delegateTestApp = new TestApplicationDelegates();
            delegateTestApp.Show();
        }
    } 
}
