using Abp.Application.Services;
using GameXuaVN.Categories.Dto;
using GameXuaVN.Files.Dto;
using GameXuaVN.Roles.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GameXuaVN.Files
{
    public interface IFileAppService : IApplicationService
    {
        Task Create(CreateFileDto input);
        Task Update(CreateFileDto input);
        Task Delete(CreateFileDto input);
        Task Rate(int fileId, float rating);
        Task<List<FileDto>> GetAllAsync();
    }
}
