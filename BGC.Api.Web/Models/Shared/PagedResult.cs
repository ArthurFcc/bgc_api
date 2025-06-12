namespace BGC.Api.Web.Models.Shared
{
    public class PagedResult<TEntity>(int totalCount, IEnumerable<TEntity> items)
    {
        public int TotalCount { get; } = totalCount;
        public IEnumerable<TEntity> Items { get; set; } = items;
    }
}
