using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace AdvWeb_VN.Application.Common
{
    public interface IStorageService
    {
        string GetFileUrl(string fileName);

        Task SaveFileAsync(Stream mediaBinaryStream, string fileName);
        Task<long> SaveFileByUrlAsync(string url, string fileName);
        Task DeleteFileAsync(string fileName);
    }
}
