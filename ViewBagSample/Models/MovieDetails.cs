namespace ViewBagSample.Models
{
    public class MovieDetails
    {
        public IEnumerable<Movies> Information()
        {
            IEnumerable<Movies> movies = new List<Movies>()
            {
                new Movies(){MovieId=1,MovieName="Yeh Jawani Hain Deewani",Actor="Ranbir Kapoor",Actoress="Deepika Padukone"},
                new Movies(){MovieId=2,MovieName="Zindagi Na Milegi Dobara",Actor="Hrithik Roshan",Actoress="Katrina Kafe"}
            };
            return movies;
        }

        public IEnumerable<Movies> GetDetailsById(int Id)
        {
            var detailsResult = from moviesList in Information()
                                where moviesList.MovieId == Id
                                select moviesList;
            if (detailsResult.Count()==1)
            {
                return detailsResult;
            }
            return Information();

        }
    }
}
