using System;

namespace AS
{
    public class Chapter : TVSeries
    {
        public IMovie Add(IMovie ct)
        {
            var chapter = new MovieCreator(ct)
                .MovieInfo
                .SetName()
                .SetStatus()
                .Create();
            Message("Added successfully", true);
            return chapter;
        }

        public void Update(IMovie chapter)
        {
            var update = new MovieCreator(chapter);
            BEGIN:
            Console.WriteLine("[1] Update Name ");
            Console.WriteLine("[2] Cancel");
            Console.Write("Select your option: ");
            switch (Console.ReadLine())
            {
                case "1":
                {
                    update.MovieInfo.SetName();
                    break;
                }
                case "2":
                {
                    Console.Clear();
                    return;
                }
                default:
                {
                    Console.Clear();
                    goto BEGIN;
                }
            }
            chapter = update.Create();
            Console.Clear();
            Message("Updated successfully\n",true);
            Console.WriteLine(chapter);
            Console.WriteLine("\nPress any key to return...");
            Console.ReadKey();
            Console.Clear();
        }
        
        public override string ToString()
        {
            return $"ID: {ID}\nName: {Name}\nNation: {Nation}\n";
        }
    }
}