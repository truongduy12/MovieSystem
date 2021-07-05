using System;
using System.Collections.Generic;
using System.Linq;

namespace AS
{
    public class IDFind : IFind
    {
        public List<IMovie> Find(string key, List<IMovie> list)
        {
            var result =
                from movie in list
                where movie.ID.ToString() == key && movie.Status == true
                select movie;
            int count = result.Count();
            if (count == 0)
            {
                Movie.Message("No result!", false);
            }
            else
            {
                foreach (var movie in result)
                {
                    Console.WriteLine(movie);
                }
            }
            return result.ToList();
        }
    }
}