using FTPSearch.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTPSearch.Repositories
{
    public interface IMassiveRepository
    {
        IEnumerable<TaskModelData> GetTlsExcelData();
        IEnumerable<TaskModelData> GetInstallTaskLingExcelData();
        IEnumerable<TaskModelData> GetUpdateTaskLingExcelData();
        IEnumerable<TaskModelData> GetAppfabricExcelData();
        IEnumerable<TaskModelData> GetUpdatePoolExcelData();
        IEnumerable<TaskModelData> GetDataBaseExcelData();
    }
}
