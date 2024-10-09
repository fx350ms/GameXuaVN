using Abp.Application.Services;
using Abp.Domain.Repositories;
using GameXuaVN.Categories.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameXuaVN.Entities;

namespace GameXuaVN.Categories
{
    public class FileCategoryAppService : ApplicationService, IFileCategoryAppService
    {
        private readonly IRepository<FileCategory, int> _fileCategoryRepository;

        public FileCategoryAppService(IRepository<FileCategory, int> fileRepository)
        {
            _fileCategoryRepository = fileRepository;
        }

        public async Task Create(CreateFileCategoryDto input)
        {
            var file = new FileCategory
            {
                Name = input.Name,
                ParentId = input.ParentId
            };
            await _fileCategoryRepository.InsertAsync(file);
        }

        public async Task<List<FileCategoryDto>> GetAllAsync()
        {
            var data = await _fileCategoryRepository.GetAllAsync();
            var result = ObjectMapper.Map<List<FileCategoryDto>>(data);
            return result;
        }
        
    }
}
