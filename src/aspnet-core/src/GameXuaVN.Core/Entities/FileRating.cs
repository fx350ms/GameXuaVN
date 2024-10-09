using Abp.Domain.Entities;
using System;

namespace GameXuaVN.Entities
{
    public class FileRating : Entity<int>
    {
        public int FileId { get; set; }
        public virtual File File { get; set; }
        public float Rating { get; set; }
        public string Comment { get; set; }
        public DateTime RatingDate { get; set; }
        public long? UserId { get; set; }
    }
}
