namespace StreamVault.Models
{
    public enum SortByEnum
    {
        PopularityDesc,
        ReleaseDateDesc,
        VoteCountDesc,
    }
    public class DiscoverQuery
    {
        public SortByEnum? SortBy;
        public DateTime? ReleaseDateLTE;
        public int? VoteCountGTE;
        public Genre? Genre;


        public DiscoverQuery(SortByEnum? sortBy = null, int? voteCountGTE = null, Genre? genre = null, DateTime? releaseDateLTE = null)
        {
            SortBy = sortBy;
            VoteCountGTE = voteCountGTE;
            Genre = genre;
            ReleaseDateLTE = releaseDateLTE;
        }

        public override string ToString()
        {
            string uri = "";
            if (ReleaseDateLTE != null)
            {
                uri += $"primary_release_date.lte={ReleaseDateLTE.Value.ToString("yyyy-MM-dd")}&";
            }

            if (Genre != null)
            {
                uri += $"with_genres={Genre.Id}&";
            }

            if (VoteCountGTE != null)
            {
                uri += $"vote_count.gte={VoteCountGTE}&";
            }

            if (SortBy != null)
            {
                uri += "sort_by=";
                if (SortBy == SortByEnum.VoteCountDesc)
                {
                    uri += "vote_count.desc";
                }
                if (SortBy == SortByEnum.PopularityDesc)
                {
                    uri += "popularity.desc";
                }
                if (SortBy == SortByEnum.ReleaseDateDesc)
                {
                    uri += "primary_release_date.desc";
                }
            }
            return uri;
        }
    }
}
