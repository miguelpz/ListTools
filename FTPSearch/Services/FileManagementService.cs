using FTPSearch.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FTPSearch.Services
{
    public class FileManagementService
    {
        private List<FileInfo> files = null;
        private List<String> users = null;
        private List<MatchDTO> listMatch = null;

        public List<MatchDTO> ExtractIdsFromFtpFiles (List<FileInfo> _files, List<String> _users)
        {
            this.files = _files;
            this.users = _users;
            this.listMatch= new List<MatchDTO>();

            foreach (FileInfo fileInfo in files)
            {
                foreach (string _user in users)
                {
                    var ids = ReadConfigXmlFile(_user, fileInfo);
                    CheckAndInsertDuplicatedUserIds(_user, ids);
                }
            }
            return listMatch;
        }

        private List<string> ReadConfigXmlFile(string user, FileInfo file)
        {
            string f = @file.FullName;
            XDocument docu = XDocument.Load(@file.FullName);
            XElement doc = XElement.Parse(docu.ToString());
            List<XElement> result = doc.Elements("add").
               Where(c => c.Attribute("user").Value == user).ToList();
            return result.Select(res => res.Attribute("name").Value).ToList();
        }

        private void CheckAndInsertDuplicatedUserIds(string user, List<string> ids)
        {
            MatchDTO userFind = listMatch.Where(u => u.user == user).FirstOrDefault();

            if (userFind == null)
            {
                userFind = new MatchDTO();
                userFind.user = user;
            }

            foreach (string id in ids)
                if (!userFind.ListaIds.Contains(id))
                    userFind.ListaIds.Add(id);
        }


        public List<MatchDTO> ExtractAppNameFromUsersIds (List<FileInfo> _files, List<MatchDTO> _userList)
        {
            this.listMatch = _userList;
            this.files = _files;

            foreach (FileInfo fileInfo in files)
            {
                foreach (MatchDTO user in listMatch)
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
            return listMatch;
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
