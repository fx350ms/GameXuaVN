using Abp.Domain.Entities.Auditing;
using System.Collections.Generic;


namespace GameXuaVN.Entities
{
    public class File : FullAuditedEntity<int>
    {
        public string FileName { get; set; }
        public string Description { get; set; }
        public int DownloadCount { get; set; }
        public int TotalRateCount { get; set; }
        public float TotalRate { get; set; }
        public byte[] Thumbnail { get; set; }

        public string DownloadUrl { get; set; }

        // Dữ liệu ảnh (binary)
        public byte[] Data { get; set; }

        // Kiểu MIME của file ảnh (ví dụ: image/jpeg, image/png)
        public string ContentType { get; set; }

        public int CategoryId { get; set; }
         
        public virtual ICollection<FileImageDetail> ImageDetails { get; set; }

        public File()
        {
            ImageDetails = new List<FileImageDetail>();
        }
    }
}
