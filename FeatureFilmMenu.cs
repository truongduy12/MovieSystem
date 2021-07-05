using System;
using System.Collections.Generic;
using System.Linq;

namespace AS
{
    public class FeatureFilmMenu : IMenu
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
            Console.WriteLine("___________________________ FEATURE FILM MENU ____________________________");
            Console.WriteLine(" [1] Add Movie");
            Console.WriteLine(" [2] Update Movie");
            Console.WriteLine(" [3] Delete Movie");
            Console.WriteLine(" [4] Restore Movie");
            Console.WriteLine(" [5] Find Movie");
            Console.WriteLine(" [6] View All Movie");
            Console.WriteLine(" [7] View Deleted Movie");
            Console.WriteLine(" [8] Back");
            Console.WriteLine("__________________________________________________________________________");
        }

        public string ChooseMenu()
        {
            Console.Write("Select your option: ");
            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                {
                    BEGIN:
                    Console.Clear();
                    IMovie newMovie = new FeatureFilm();
                    newMovie = newMovie.Add(newMovie);
                    newMovie.ID = Program.ListFeatureFilms.Count + 1001;
                    Program.ListFeatureFilms.Add(newMovie);
                    Console.WriteLine("Do you want to add another? [y/n]");
                    if (Console.ReadLine().ToLower().Equals("y"))
                    {
                        goto BEGIN;
                    }
                    return "FeatureFilmMenu";
                }
                case "2":
                {
                    BEGIN:
                    Console.Clear();
                    Console.Write("Enter ID: ");
                    string id = Console.ReadLine();
                    List<IMovie> result = IdFinder.Find(id,Program.ListFeatureFilms);
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
                        result.First().Update(result.First());
                    }
                    return "FeatureFilmMenu";
                }
                case "3":
                {
                    BEGIN:
                    Console.Clear();
                    Console.Write("Enter ID: ");
                    string id = Console.ReadLine();
                    List<IMovie> result = IdFinder.Find(id, Program.ListFeatureFilms);
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
                        result.First().Delete(result.First());
                    }
                    return "FeatureFilmMenu";
                }
                case "4":
                {
                    BEGIN:
                    Console.Clear();
                    Console.Write("Enter ID: ");
                    string id = Console.ReadLine();
                    List<IMovie> result = DeletedFinder.Find(id, Program.ListFeatureFilms);
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
                    return "FeatureFilmMenu";
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
                            IdFinder.Find(keyword, Program.ListFeatureFilms);
                            break;
                        }
                        case "2":
                        {
                            Console.Write("Enter keyword: ");
                            string keyword = Console.ReadLine();
                            NameFinder.Find(keyword,Program.ListFeatureFilms);
                            break;
                        }
                        case "3":
                        {
                            Console.Write("Enter keyword: ");
                            string keyword = Console.ReadLine();
                            NationFinder.Find(keyword, Program.ListFeatureFilms);
                            break;
                        }
                        default:
                        {
                            goto BEGIN;
                        }
                    }
                    Console.WriteLine("Press any key to continue..");
                    Console.ReadKey();
                    return "FeatureFilmMenu";
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
                            PriceInsView.View(Program.ListFeatureFilms);
                            break;
                        }
                        case "2":
                        {
                            PriceDesView.View(Program.ListFeatureFilms);
                            break;
                        }
                        case "3":
                        {
                            DefaultView.View(Program.ListFeatureFilms);
                            break;
                        }
                        default:
                        {
                            goto BEGIN;
                        }
                    }
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    return "FeatureFilmMenu";
                }
                case "7":
                {
                    Console.Clear();
                    DeletedView.View(Program.ListFeatureFilms);
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    return "FeatureFilmMenu";
                }
                case "8": return "Main";
                default: return "FeatureFilmMenu";
            }
        }
    }
}