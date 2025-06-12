namespace BGC.Api.Web.Models.Shared
{
    public class PagedRequest
    {
        public string? SearchText { get; set; }
        public byte MaxResultCount { get; set; } = 10;
        public uint SkipCount { get; set; } = 1;
    }
}
