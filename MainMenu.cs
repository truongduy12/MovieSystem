using System;

namespace AS
{
    public class MainMenu : IMenu
    {
        public void ShowMenu()
        {
            Console.WriteLine("_______________________________ MAIN MENU _______________________________");
            Console.WriteLine(" [1] Manage Feature Film");
            Console.WriteLine(" [2] Manage Television Series");
            Console.WriteLine(" [3] Exit");
            Console.WriteLine("__________________________________________________________________________");
        }

        public string ChooseMenu()
        {
            Console.Write("Select your option: ");
            switch (Console.ReadLine())
            {
             case "1": return "FeatureFilmMenu";
             case "2": return "TVSeriesMenu";
             case "3": return "Exit";
             default: return "Main";
            }
        }
    }
}