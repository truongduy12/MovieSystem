using System;
using System.Collections.Generic;
using System.Linq;

namespace AS
{
    public class TVSeriesMenu : IMenu
    {
        private IFind IdFinder => new IDFind();
        private IFind NameFinder => new NameFind();
        private IFind NationFinder => new NationFind();
        private IFind DeletedFinder => new DeletedFind();
        private IView DefaultView => new DefaultView();
        private IView PriceInsView => new PriceInsView();
        private IView PriceDesView => new PriceDesView();
        private IView DeletedView => new DeletedView();
        public void ShowMenu()
        {
            Console.WriteLine("_________________________ TELEVISION SERIES MENU _________________________");
            Console.WriteLine(" [1] Add Series");
            Console.WriteLine(" [2] Update Series");
            Console.WriteLine(" [3] Delete Series");
            Console.WriteLine(" [4] Restore Series");
            Console.WriteLine(" [5] Find Series");
            Console.WriteLine(" [6] View All Series");
            Console.WriteLine(" [7] View Deleted Series");
            Console.WriteLine(" [8] Manage Chapters");
            Console.WriteLine(" [9] Back");
            Console.WriteLine("__________________________________________________________________________");
        }

        public string ChooseMenu()
        {
            Console.Write("Select your option: ");
            switch (Console.ReadLine())
            {
                case "1":
                {
                    BEGIN:
                    Console.Clear();
                    IMovie newSeries = new TVSeries();
                    Movie.Message("Price and Duration is count by single chapter in the series", false);
                    newSeries = newSeries.Add(newSeries);
                    newSeries.ID = Program.ListTVSeries.Count + 1001;
                    Program.ListTVSeries.Add(newSeries);
                    Console.WriteLine("Do you want to add another? [y/n]");
                    if (Console.ReadLine().ToLower().Equals("y"))
                    {
                        goto BEGIN;
                    }
                    return "TVSeriesMenu";
                }
                case "2":
                {
                    BEGIN:
                    Console.Clear();
                    Console.Write("Enter ID: ");
                    string id = Console.ReadLine();
                    List<IMovie> result = IdFinder.Find(id,Program.ListTVSeries);
                    if (result.Count == 0)
                    {
                        Console.WriteLine("Do you want to continue? [y/n]");
                        if (Console.ReadLine().ToLower().Equals("y"))
                        { 
                            goto BEGIN;
                        }
                    }
                    else
                    {
                        Movie.Message("Price and Duration is count by single chapter in the series", false);
                        result.First().Update(result.First());
                    }
                    return "TVSeriesMenu";
                }
                case "3":
                {
                    BEGIN:
                    Console.Clear();
                    Console.Write("Enter ID: ");
                    string id = Console.ReadLine();
                    List<IMovie> result = IdFinder.Find(id, Program.ListTVSeries);
                    if (result.Count == 0)
                    {
                        Console.WriteLine("Do you want to continue? [y/n]");
                        if (Console.ReadLine().ToLower().Equals("y"))
                        { 
                            goto BEGIN;
                        }
                    }
                    else
                    {
                        Movie.Message("The deletion will remove all chapter from this series", false);
                        result.First().Delete(result.First());
                    }
                    return "TVSeriesMenu";
                }
                case "4":
                {
                    BEGIN:
                    Console.Clear();
                    Console.Write("Enter ID: ");
                    string id = Console.ReadLine();
                    List<IMovie> result = DeletedFinder.Find(id, Program.ListTVSeries);
                    if (result.Count == 0)
                    {
                        Console.WriteLine("Do you want to continue? [y/n]");
                        if (Console.ReadLine().ToLower().Equals("y"))
                        { 
                            goto BEGIN;
                        }
                    }
                    else
                    {
                        result.First().Restore(result.First());
                    }
                    return "TVSeriesMenu";
                }
                case "5":
                {
                    BEGIN:
                    Console.Clear();
                    Console.WriteLine("[1] Find by ID");
                    Console.WriteLine("[2] Find by Name");
                    Console.WriteLine("[3] Find by Nation");
                    Console.Write("Select your option: ");
                    string select = Console.ReadLine();
                    Console.Clear();
                    switch (select)
                    {
                        case "1":
                        {
                            Console.Write("Enter keyword: ");
                            string keyword = Console.ReadLine();
                            IdFinder.Find(keyword, Program.ListTVSeries);
                            break;
                        }
                        case "2":
                        {
                            Console.Write("Enter keyword: ");
                            string keyword = Console.ReadLine();
                            NameFinder.Find(keyword,Program.ListTVSeries);
                            break;
                        }
                        case "3":
                        {
                            Console.Write("Enter keyword: ");
                            string keyword = Console.ReadLine();
                            NationFinder.Find(keyword, Program.ListTVSeries);
                            break;
                        }
                        default:
                        {
                            goto BEGIN;
                        }
                    }
                    Console.WriteLine("Press any key to continue..");
                    Console.ReadKey();
                    return "TVSeriesMenu";
                }
                case "6":
                {
                    BEGIN:
                    Console.Clear();
                    Console.WriteLine("[1] View by Ascending Price Order");
                    Console.WriteLine("[2] View by Descending Price Order");
                    Console.WriteLine("[3] View by Default Order");
                    Console.Write("Select your option: ");
                    string select = Console.ReadLine();
                    Console.Clear();
                    switch (select)
                    {
                        case "1":
                        {
                            PriceInsView.View(Program.ListTVSeries);
                            break;
                        }
                        case "2":
                        {
                            PriceDesView.View(Program.ListTVSeries);
                            break;
                        }
                        case "3":
                        {
                            DefaultView.View(Program.ListTVSeries);
                            break;
                        }
                        default:
                        {
                            goto BEGIN;
                        }
                    }
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    return "TVSeriesMenu";
                }
                case "7":
                {
                    Console.Clear();
                    DeletedView.View(Program.ListTVSeries);
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    return "TVSeriesMenu";
                }
                case "8":
                {
                    BEGIN:
                    Console.Clear();
                    Console.Write("Enter ID: ");
                    string id = Console.ReadLine();
                    List<IMovie> result = IdFinder.Find(id,Program.ListTVSeries);
                    if (result.Count == 0)
                    {
                        Console.WriteLine("Do you want to continue? [y/n]");
                        if (Console.ReadLine().ToLower().Equals("y"))
                        { 
                            goto BEGIN;
                        }
                        else
                        {
                            return "TVSeriesMenu";
                        }
                    }
                    return $"ChaptersMenu/{result.First().ID}";
                }
                case "9":
                {
                    return "Main";
                }
                default: return "TVSeriesMenu";
            }
        }
    }
}