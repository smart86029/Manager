namespace Manager.ViewModels
{
    public class PaginationQuery
    {
        private int pageIndex = 1;
        private int pageSize = 10;

        public int PageIndex
        {
            get => pageIndex;
            set => pageIndex = value > 1 ? value : pageIndex;
        }

        public int PageSize
        {
            get => pageSize;
            set => pageSize = value > 0 && value < 100 ? value : pageSize;
        }
    }
}