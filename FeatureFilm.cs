namespace AS
{
    public class FeatureFilm : Movie
    {
        public override string ToString()
        {
            return $"ID: {ID}\nName: {Name}\nDuration: {Duration} minutes\nPrice: {Price}$\nPublish time: {Publish.ToShortDateString()}\nNation: {Nation}\n";
        }
    }
}