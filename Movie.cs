using System;

namespace AS
{
    public abstract class Movie : IMovie
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Nation { get; set; }
        public int Duration { get; set; }
        public DateTime Publish { get; set; }
        public bool Status { get; set; }
        public IMovie Add(IMovie typeMovie)
        {
            var movie = new MovieCreator(typeMovie)
                .MovieInfo
                .SetName()
                .SetPrice()
                .SetDuration()
                .SetStatus()
                .PublishInfo
                .SetNation()
                .SetPublishDate()
                .Create();
            Message("Added successfully", true);
            return movie;
        }
        public void Update(IMovie movie)
        {
            var update = new MovieCreator(movie);
            BEGIN:
            Console.WriteLine("[1] Update Name ");
            Console.WriteLine("[2] Update Duration ");
            Console.WriteLine("[3] Update Price ");
            Console.WriteLine("[4] Update Publish Date ");
            Console.WriteLine("[5] Update Nation ");
            Console.WriteLine("[6] Cancel");
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
                    update.MovieInfo.SetDuration();
                    break;
                }
                case "3":
                {
                    update.MovieInfo.SetPrice();
                    break;
                }
                case "4":
                {
                    update.PublishInfo.SetPublishDate();
                    break;
                }
                case "5":
                {
                    update.PublishInfo.SetNation();
                    break;
                }
                case "6":
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
            movie = update.Create();
            Console.Clear();
            Message("Updated successfully\n",true);
            Console.WriteLine(movie);
            Console.WriteLine("\nPress any key to return...");
            Console.ReadKey();
            Console.Clear();
        }
        public void Delete(IMovie movie)
        {
            Console.WriteLine("Are you sure to delete? [y/n]");
            if (Console.ReadLine().ToLower().Equals("y"))
            {
                movie.Status = false;
                Message("Movie deleted!", false);
                Console.WriteLine("Press any key to continue..");
                Console.ReadKey();
            }
        }
        public void Restore(IMovie movie)
        {
            movie.Status = true;
            Message("Movie restored!", true);
            Console.WriteLine("Press any key to continue..");
            Console.ReadKey();
        }
        public static void Message(string msg, bool isOK)
        {
            if (isOK)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(msg);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(msg);
            }

            Console.ForegroundColor = ConsoleColor.Black;
        }

        public abstract override string ToString();
    }
}