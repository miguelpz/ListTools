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
    public class ExtractIdsFromFtpFiles
    {
        private List<FileInfo> files;
        private List<String> users;
        private List<MatchDTO> listMatch = new List<MatchDTO>();

        public ExtractIdsFromFtpFiles(List<FileInfo> _files, List<String> _users)
        {
            this.files = _files;
            this.users = _users;
        }

        public List<MatchDTO> GetAll()
        {
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

        private List<string> ReadConfigXmlFile (string user, FileInfo file)
        {
            string f = @file.FullName;
            XDocument docu = XDocument.Load(@file.FullName);
            XElement doc = XElement.Parse(docu.ToString());
             List<XElement> result = doc.Elements("add").
                Where(c => c.Attribute("user").Value == user).ToList();
            return result.Select(res => res.Attribute("name").Value).ToList();
        }

        private  void CheckAndInsertDuplicatedUserIds(string user, List<string> ids)
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
               
            


        

    }

}