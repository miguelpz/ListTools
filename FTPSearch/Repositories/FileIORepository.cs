using FTPSearch.DTO;
using FTPSearch.Contracts;

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTPSearch.Services
{
    public class FileIOService : IFileIORepository
    {
        private string typeFile = null;
        private DirectoryInfo _dir = null;

        public FileIOService(DirectoryInfo dir)
        {
            _dir = dir;
        }

        public List<FileInfo> GetFtpsFiles()
        {
            typeFile = "ftps.xml";
            return GetFiles(_dir);
        }

        public List<FileInfo> GetIomFiles()
        {
            typeFile = "iom.xml";
            return GetFiles(_dir);
        }

        public List<FileInfo> GetJsonFiles()
        {
            typeFile = "*.json";
            return GetFiles(_dir);
        }

        private List<FileInfo> GetFiles(DirectoryInfo dir)
        {
            List<FileInfo> res = dir.GetFiles(typeFile).ToList();
            dir.GetDirectories().ToList().ForEach(d => res.AddRange(GetFiles(d)));
            return res;
        }




    }
}
