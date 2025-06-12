using CsvHelper.Configuration.Attributes;

namespace BGC.Api.Web.Models.Shared
{
    public class Entity
    {
        [Ignore]
        public uint Id { get; set; }

        [Ignore]
        public DateTime CreationTime { get; set; }

        [Ignore]
        public DateTime? LastUpdateTime { get; set; }

        /*
         * Implement user information to filter in the future
         */
    }
}
