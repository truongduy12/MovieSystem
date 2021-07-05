namespace AS
{
    public class MovieCreator
    {
        public IMovie Movie { get; set; }
        public MovieCreator(IMovie movie)
        {
            this.Movie = movie;
        }
        public MovieCreator()
        {
            
        }

        public IMovie Create() => Movie;
        public MovieInfo MovieInfo => new MovieInfo(Movie);
        public PublishInfo PublishInfo => new PublishInfo(Movie);
    }
}