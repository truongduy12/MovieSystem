using System;

namespace AS
{
    public class MovieInfo : MovieCreator
    {
        public MovieInfo(IMovie movie)
        {
            Movie = movie;
        }
        
        public MovieInfo SetName()
        {
            BEGIN:
            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            if (name.Trim().Equals(""))
            {
                AS.Movie.Message("Please enter this field!", false);
                goto BEGIN;
            }
            Movie.Name = name;
            return this;
        }

        public MovieInfo SetPrice()
        {
            BEGIN:
            Console.Write("Enter price: ");
            double price;
            try
            {
                price = Convert.ToDouble(Console.ReadLine());
            }
            catch (Exception e)
            {
                AS.Movie.Message(e.Message,false);
                AS.Movie.Message("Please enter valid number!", false);
                goto BEGIN;
            }
            Movie.Price = price;
            return this;
        }

        public MovieInfo SetDuration()
        {
            BEGIN:
            Console.Write("Enter duration: ");
            int duration;
            try
            {
                duration = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e)
            {
                AS.Movie.Message(e.Message,false);
                AS.Movie.Message("Please enter valid number!", false);
                goto BEGIN;
            }
            Movie.Duration = duration;
            return this;
        }

        public MovieInfo SetStatus()
        {
            Movie.Status = true;
            return this;
        }
    }
}