using System;
using System.Collections.Generic;
using System.Threading;

namespace AS
{
    public class TVSeries : Movie
    {
        public List<IMovie> ListChapter = new List<IMovie>();
        private int GetTotalChapter()
        {
            int count = ListChapter.Count;
            foreach (var chapter in ListChapter)
            {
                if (chapter.Status == false)
                    count--;
            }
            return count;
        }
        private double GetTotalPrice()
        {
            return this.Price * GetTotalChapter();
        }
        public override string ToString()
        {
            return $"ID: {ID}\nName: {Name}\nTotal Chapter: {GetTotalChapter()}\nDuration: {Duration} minutes\nChapter Price: {Price}$\nTotal Price: {GetTotalPrice()}\nPublish time: {Publish.ToShortDateString()}\nNation: {Nation}\n";
        }
    }
}