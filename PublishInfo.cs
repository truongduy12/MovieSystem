using System;

namespace AS
{
    public class PublishInfo : MovieCreator
    {
        public PublishInfo(IMovie movie)
        {
            Movie = movie;
        }

        public PublishInfo SetNation()
        {
            BEGIN:
            Console.Write("Enter nation: ");
            string nation = Console.ReadLine();
            if (nation.Trim().Equals(""))
            {
                AS.Movie.Message("Please enter this field!", false);
                goto BEGIN;
            }
            Movie.Nation = nation;
            return this;
        }

        public PublishInfo SetPublishDate()
        {
            BEGIN:
            Console.Write("Enter published date: ");
            DateTime date;
            try
            {
                date = Convert.ToDateTime(Console.ReadLine());
            }
            catch (Exception e)
            {
                AS.Movie.Message(e.Message,false);
                AS.Movie.Message("Please enter valid date!", false);
                goto BEGIN;
            }
            Movie.Publish = date;
            return this;
        }
    }
}