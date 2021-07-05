using System;

namespace AS
{
    public interface IMovie
    {
         int ID { get; set; }
         string Name { get; set; }
         double Price { get; set; }
         string Nation { get; set; }
         int Duration { get; set; }
         DateTime Publish { get; set; }
         bool Status { get; set; }
         IMovie Add(IMovie typeMovie);
         void Update(IMovie movie);
         void Delete(IMovie movie);
         void Restore(IMovie movie);
    }
}