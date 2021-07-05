using System;
using System.Collections.Generic;
using System.Linq;

namespace AS
{
    public class DeletedFind : IFind
    {
        public List<IMovie> Find(string key, List<IMovie> list)
        {
            var result =
                from movie in list
                where movie.ID.ToString() == key && movie.Status == false
                select movie;
            int count = result.Count();
            if (count == 0)
            {
                Movie.Message("No deleted movie found!", false);
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