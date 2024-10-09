using Abp.Application.Services;
using Abp.Domain.Repositories;
using GameXuaVN.Authorization.Roles;
using GameXuaVN.Categories.Dto;
using GameXuaVN.Entities;
using GameXuaVN.Files.Dto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameXuaVN.Files
{
    public class FileAppService : ApplicationService, IFileAppService
    {
        private readonly IRepository<File, int> _fileRepository;

        public FileAppService(IRepository<File, int> fileRepository)
        {
            _fileRepository = fileRepository;
            
        }

        public async Task Create(CreateFileDto input)
        {
            var file = ObjectMapper.Map<File>(input);
            await _fileRepository.InsertAsync(file);
        }

        public Task Delete(CreateFileDto input)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<FileDto>> GetAllAsync()
        {
            var files = await _fileRepository.GetAll().ToListAsync();
            return files.Select(f => new FileDto
            {
                Id = f.Id,
                FileName = f.FileName,
                Description = f.Description,
                DownloadCount = f.DownloadCount,
                AverageRating = f.TotalRateCount > 0 ? f.TotalRate / f.TotalRateCount : 0,
               
                 
            }).ToList();
        }

        public async Task Rate(int fileId, float rating)
        {
            var file = await _fileRepository.GetAsync(fileId);
            file.TotalRate += rating;
            file.TotalRateCount++;
            await _fileRepository.UpdateAsync(file);
        }

        public Task Update(CreateFileDto input)
        {
            throw new System.NotImplementedException();
        }
    }
}
