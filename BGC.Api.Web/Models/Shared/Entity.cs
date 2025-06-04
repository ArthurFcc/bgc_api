namespace BGC.Api.Web.Models.Shared
{
    public class Entity
    {
        public uint Id { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime? LastUpdateTime { get; set; }

        /*
         * Implement user information to filter in the future
         */
    }
}
