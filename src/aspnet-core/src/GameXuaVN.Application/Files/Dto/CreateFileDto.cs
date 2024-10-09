using Abp.AutoMapper;
using GameXuaVN.Entities;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace GameXuaVN.Files.Dto
{

    [AutoMapFrom(typeof(File))]
    public class CreateFileDto
    {
        [Required]
        [StringLength(255)]
        public string FileName { get; set; }


        public string DownloadUrl { get; set; } 
        public string Description { get; set; }

        public byte[] Thumbnail { get; set; } // hình ảnh thumbnail

        // Dữ liệu ảnh (binary)
        public byte[] Data { get; set; }

        // Kiểu MIME của file ảnh (ví dụ: image/jpeg, image/png)
        public string ContentType { get; set; }

        public int CategoryId { get; set; }

        public int DownloadCount { get; set; }
        public int TotalRateCount { get; set; }
        public float TotalRate { get; set; }

      
    }
}
