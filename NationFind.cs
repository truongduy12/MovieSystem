using System;
using System.Collections.Generic;
using System.Linq;

namespace AS
{
    public class NationFind : IFind
    {
        public List<IMovie> Find(string key, List<IMovie> list)
        {
            var result =
                from movie in list
                where movie.Nation.ToLower().Contains(key.ToLower()) 
                      && movie.Status == true
                select movie;
            int count = result.Count();
            if (count == 0)
            {
                Movie.Message("No result!", false);
            }
            else
            {
                Console.WriteLine($"Found {count} result(s)");
                foreach (var movie in result)
                {
                    Console.WriteLine(movie);
                }
            }
            return result.ToList();
        }
    }
}