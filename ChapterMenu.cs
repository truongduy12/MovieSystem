using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace AS
{
    public class ChapterMenu : IMenu
    {
        private IFind IdFinder => new IDFind();
        private IFind NameFinder => new NameFind();
        private IFind DeletedFinder => new DeletedFind();
        private IView DefaultView => new DefaultView();
        private IView DeletedView => new DeletedView();

        private TVSeries _thisSeries;
        private List<IMovie> _listChapter;
        public ChapterMenu(int seriesID)
        {
             _thisSeries = (TVSeries) Program.ListTVSeries.Find(movie => movie.ID == seriesID);
             _listChapter = _thisSeries.ListChapter;
        }
        public void ShowMenu()
        {
            Console.WriteLine("_______________________________ SERIES INFO ________________________________");
            IdFinder.Find(_thisSeries.ID.ToString(), Program.ListTVSeries);
            Console.WriteLine($"_____________________________ CHAPTER MENU: ______________________________");
            Console.WriteLine(" [1] Add Chapter\t[2] Update Chapter\t[3] Delete Chapter\t\t[4] Restore Chapter");
            Console.WriteLine(" [5] Find Chapter\t[6] View All Chapters\t[7] View Deleted Chapter\t[8] Back");
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
                    Chapter newSeries = new Chapter();
                    newSeries = (Chapter) newSeries.Add(newSeries);
                    newSeries.ID = _listChapter.Count + 1001;
                    newSeries.Duration = _thisSeries.Duration;
                    newSeries.Nation = _thisSeries.Nation;
                    newSeries.Price = _thisSeries.Price;
                    newSeries.Publish = _thisSeries.Publish;
                    _listChapter.Add(newSeries);
                    Console.WriteLine("Do you want to add another? [y/n]");
                    if (Console.ReadLine().ToLower().Equals("y"))
                    {
                        goto BEGIN;
                    }
                    return $"ChaptersMenu/{_thisSeries.ID}";
                }
                case "2":
                {
                    BEGIN:
                    Console.Clear();
                    Console.Write("Enter ID: ");
                    string id = Console.ReadLine();
                    List<IMovie> result = IdFinder.Find(id,_listChapter);
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
                        Chapter temp = (Chapter) result.First();
                        temp.Update(temp);
                    }
                    return $"ChaptersMenu/{_thisSeries.ID}";
                }
                case "3":
                {
                    BEGIN:
                    Console.Clear();
                    Console.Write("Enter ID: ");
                    string id = Console.ReadLine();
                    List<IMovie> result = IdFinder.Find(id, _listChapter);
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
                    return $"ChaptersMenu/{_thisSeries.ID}";
                }
                case "4":
                {
                    BEGIN:
                    Console.Clear();
                    Console.Write("Enter ID: ");
                    string id = Console.ReadLine();
                    List<IMovie> result = DeletedFinder.Find(id, _listChapter);
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
                    return $"ChaptersMenu/{_thisSeries.ID}";
                }
                case "5":
                {
                    BEGIN:
                    Console.Clear();
                    Console.WriteLine("[1] Find by ID");
                    Console.WriteLine("[2] Find by Name");
                    Console.Write("Select your option: ");
                    string select = Console.ReadLine();
                    Console.Clear();
                    switch (select)
                    {
                        case "1":
                        {
                            Console.Write("Enter keyword: ");
                            string keyword = Console.ReadLine();
                            IdFinder.Find(keyword, _listChapter);
                            break;
                        }
                        case "2":
                        {
                            Console.Write("Enter keyword: ");
                            string keyword = Console.ReadLine();
                            NameFinder.Find(keyword, _listChapter);
                            break;
                        }
                        default:
                        {
                            goto BEGIN;
                        }
                    }
                    Console.WriteLine("Press any key to continue..");
                    Console.ReadKey();
                    return $"ChaptersMenu/{_thisSeries.ID}";
                }
                case "6":
                {
                    Console.Clear();
                    DefaultView.View(_listChapter);
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    return $"ChaptersMenu/{_thisSeries.ID}";
                }
                case "7":
                {
                    Console.Clear();
                    DeletedView.View(_listChapter);
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    return $"ChaptersMenu/{_thisSeries.ID}";
                }
                case "8":
                {
                    return "TVSeriesMenu";
                }
                default: return $"ChaptersMenu/{_thisSeries.ID}";
            }
        }
    }
}