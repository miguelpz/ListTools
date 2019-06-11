using FTPSearch.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FTPSearch
{
    public class ExtractAppNameFromUsersIds
    {
        private List<MatchDTO> userList;
        private List<FileInfo> files;

        public ExtractAppNameFromUsersIds( List<FileInfo> _files, List<MatchDTO> _userList )
        {
            this.userList = _userList;
            this.files = _files;
        }

        public List<MatchDTO> GetAll()
        {
            foreach (FileInfo fileInfo in files)
            {
                foreach (MatchDTO user in userList)
                {
                    string f = @fileInfo.FullName;
                    XDocument docu = XDocument.Load(@fileInfo.FullName);
                    XElement doc = XElement.Parse(docu.ToString());

                    

                    foreach (string id in user.ListaIds)
                    {
                        var result = doc.Element("ftps").Elements("ftp").
                        Where(c => c.Attribute("id").Value == id).ToList();

                        if (result.Count > 0)
                        {
                            string[] segments = fileInfo.FullName.Split('\\');
                            CheckAndInsertDuplicatedNameApp(user, segments[segments.Length - 2]);
                        }
                    }                                
                }
            }
            return userList;
        }

        private void CheckAndInsertDuplicatedNameApp(MatchDTO user, string appName)
        {
            if (!user.Application.Contains(appName))
            {
                user.Application.Add(appName);
            }
        }       
    }
}
