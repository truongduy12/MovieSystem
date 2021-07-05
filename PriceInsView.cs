using System;
using System.Collections.Generic;
using System.Linq;

namespace AS
{
    public class PriceInsView : IView
    {
        public void View(List<IMovie> list)
        {
            var result =
                from movie in list
                where movie.Status == true
                orderby movie.Price ascending
                select movie;
            if (result.Count() != 0)
            {
                foreach (var movie in result)
                {
                    Console.WriteLine(movie);
                }
            }
            else
            {
                Movie.Message("No result!", false);
            }
        }
    }
}