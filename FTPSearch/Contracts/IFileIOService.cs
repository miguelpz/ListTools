using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTPSearch.Contracts
{
    public interface IFileIOService
    {
        List<FileInfo> GetFtpsFiles();
        List<FileInfo> GetIomFiles();
    }
}
