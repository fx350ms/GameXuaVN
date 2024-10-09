using GameXuaVN.Files;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using GameXuaVN.Controllers;
using System.Linq;
using GameXuaVN.Web.Models.File;
using GameXuaVN.Files.Dto;
using System.IO;


namespace GameXuaVN.Web.Controllers
{
    public class FileController : GameXuaVNControllerBase
    {
        private readonly IFileAppService _fileAppService;

        public FileController(IFileAppService fileAppService)
        {
            _fileAppService = fileAppService;
        }

        public async Task<IActionResult> Index()
        {
            // Lấy danh sách file từ Application Service
            var fileDtos = await _fileAppService.GetAllAsync();

            // Ánh xạ từ FileDto sang FileViewModel
            var fileViewModels = fileDtos.Select(file => new FileViewModel
            {
                FileName = file.FileName,
                Description = file.Description,
                DownloadCount = file.DownloadCount,
                AverageRating = file.AverageRating,
               
            }).ToList();

            // Trả về view với danh sách FileViewModel
            return View(fileViewModels);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateFileModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Chuyển đổi file thành byte[]
            byte[] fileData = null;
            byte[] thumb = null;
            string contentType = null;
            if (model.FileData != null && model.FileData.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await model.FileData.CopyToAsync(memoryStream);
                    fileData = memoryStream.ToArray();
                    contentType = model.FileData.ContentType;
                }
            }


            if(model.Thumbnail != null && model.Thumbnail.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await model.Thumbnail.CopyToAsync(memoryStream);
                    thumb = memoryStream.ToArray();
                }
            }    
            // Tạo đối tượng FileDto và gửi tới service để lưu vào DB
            var fileDto = new CreateFileDto
            {
                FileName = model.FileName,
                Description = model.Description,
                CategoryId = model.CategoryId,
                Data = fileData,
                Thumbnail = thumb,
                ContentType = contentType,
                DownloadCount = 0, // Bắt đầu với 0 lượt tải
                TotalRateCount = 0, // Bắt đầu với 0 lượt đánh giá
                TotalRate = 0,
                DownloadUrl = "", // Có thể thêm sau khi xử lý lưu trữ file thực tế
            };

            await _fileAppService.Create(fileDto);
            return RedirectToAction("Index"); // Redirect về danh sách file hoặc trang thành công
        }

      

        [HttpPost]
        public async Task<IActionResult> Rate(int fileId, float rating)
        {
            await _fileAppService.Rate(fileId, rating);
            return RedirectToAction("Index");
        }
    }
}
