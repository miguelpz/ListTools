using FTPSearch.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTPSearch.Contracts
{
    public interface IFileManagementService
    {
        List<MatchDTO> ExtractIdsFromFtpFiles(List<FileInfo> _files, List<String> _users);
        List<MatchDTO> ExtractAppNameFromUsersIds(List<FileInfo> _files, List<MatchDTO> _userList);

    }
}
