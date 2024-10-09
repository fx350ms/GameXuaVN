using Abp.Domain.Entities;

namespace GameXuaVN.Entities
{
    public class FileImageDetail : Entity<int>
    {
        public int FileId { get; set; }
        public virtual File File { get; set; }
        public int ImageId { get; set; }
        public virtual Image Image { get; set; }
    }
}
