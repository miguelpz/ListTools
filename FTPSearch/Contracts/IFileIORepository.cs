using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTPSearch.Contracts
{
    public interface IFileIORepository
    {
        List<FileInfo> GetFtpsFiles();
        List<FileInfo> GetIomFiles();
    }
}
