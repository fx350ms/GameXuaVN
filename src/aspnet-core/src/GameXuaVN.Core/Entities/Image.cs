using Abp.Domain.Entities;

namespace GameXuaVN.Entities
{
    public class Image : Entity<int>
    {
        public string FilePath { get; set; }
        public virtual File File { get; set; }
    }
}
