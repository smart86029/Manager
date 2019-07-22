namespace MatchaLatte.HumanResources.App.Queries
{
    public class PaginationOption
    {
        private int offset = 0;
        private int limit = 10;

        public int Offset
        {
            get => offset;
            set => offset = value > 0 ? value : offset;
        }

        public int Limit
        {
            get => limit;
            set => limit = value > 0 && value <= 100 ? value : limit;
        }
    }
}