using System.Drawing.Printing;

namespace ProjectRealEstate.ViewModels
{
    public class PaginateVM<TEntity>
    {
        public List<TEntity> Models { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public bool Next { get; set; }
        public bool Previous { get; set; }

    }
}
