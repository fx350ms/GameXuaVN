using Abp.AutoMapper;
using GameXuaVN.Entities;

namespace GameXuaVN.Files.Dto
{

    [AutoMapFrom(typeof(File))]
    public class FileDto
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public int DownloadCount { get; set; }
        public int TotalRateCount { get; set; }
        public float TotalRate { get; set; }

        public float AverageRating { get; set; } // Tính điểm đánh giá trung bình

        public byte[] Thumbnail { get; set; } // ID của hình thumbnail, nếu có

        public string DownloadUrl { get; set; }

        // Dữ liệu ảnh (binary)
        public byte[] Data { get; set; }

        // Kiểu MIME của file ảnh (ví dụ: image/jpeg, image/png)
        public string ContentType { get; set; }

        public int CategoryId { get; set; }

        public bool AllowPlayOnline { get; set; }   

        public string EmbedUrl { get; set; }

    }
}
