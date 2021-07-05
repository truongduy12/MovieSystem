using System;
using System.Collections.Generic;

namespace AS
{
    class Program
    {
        public static List<IMovie> ListFeatureFilms = new List<IMovie>();
        public static List<IMovie> ListTVSeries = new List<IMovie>();
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            
            IMenu menu = null;
            BEGIN:
            string getType = "Main";
            do
            {
                Console.Clear();
                if (getType.Equals("Main"))
                {
                    menu = new MainMenu();
                }
                else if (getType.Equals("FeatureFilmMenu"))
                {
                    menu = new FeatureFilmMenu();
                }
                else if (getType.Equals("TVSeriesMenu"))
                {
                    menu = new TVSeriesMenu();
                }
                else if (getType.Contains("ChaptersMenu"))
                {
                    int id = Convert.ToInt32(getType.Split("/")[1]);
                    menu = new ChapterMenu(id);
                }
                else
                {
                    Console.Clear();
                    goto BEGIN;
                }
                menu.ShowMenu();
                getType = menu.ChooseMenu();
            } while (!getType.Equals("Exit"));
        }
    }
}