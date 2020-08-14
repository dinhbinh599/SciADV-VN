using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AdvWeb_VN.Application.Common
{
    public class FileStorageService : IStorageService
    {
        private readonly string _userContentFolder;
        private const string USER_CONTENT_FOLDER_NAME = "user-content";

        public FileStorageService(IWebHostEnvironment webHostEnvironment)
        {
            _userContentFolder = Path.Combine(webHostEnvironment.WebRootPath, USER_CONTENT_FOLDER_NAME);
        }

        public string GetFileUrl(string fileName)
        {
            return $"/{USER_CONTENT_FOLDER_NAME}/{fileName}";
        }

        public async Task SaveFileAsync(Stream mediaBinaryStream, string fileName)
        {
            var filePath = Path.Combine(_userContentFolder, fileName);
            using var output = new FileStream(filePath, FileMode.Create);
            await mediaBinaryStream.CopyToAsync(output);
        }

        public async Task DeleteFileAsync(string fileName)
        {
            var filePath = Path.Combine(_userContentFolder, fileName);
            if (File.Exists(filePath))
            {
                await Task.Run(() => File.Delete(filePath));
            }
        }
        
        public async Task<long> SaveFileByUrlAsync(string url, string fileName)
        {
            var filePath = Path.Combine(_userContentFolder, fileName);
            WebClient client = new WebClient();
            client.DownloadFileAsync(new Uri(url), filePath);
            /*var client = new HttpClient();
            Stream s = await client.GetStreamAsync(url);
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            Stream contentStream = await (await client.SendAsync(request)).Content.ReadAsStreamAsync(),
            stream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None, 3145728, true);
            await contentStream.CopyToAsync(stream);*/
            FileInfo fi = new FileInfo(filePath);
            return fi.Length;
        }
    }
}
