using FTPSearch.DTO;
using FTPSearch.Repositories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FTPSearch.Services
{
    public class AccessExternalService
    {
        private List<MatchDTO> _usersList;
        private IJiraRepository _jiraRepository;

        public AccessExternalService(IJiraRepository jiraRepository)
        {
            _jiraRepository = jiraRepository;
        }

        public List<MatchDTO>  GetOwnerFromAppUsers (List<MatchDTO> userList)
        {
            _usersList = userList;

            foreach (MatchDTO user in _usersList)
            {
                if (user.Application.Count > 0)
                {

                    user.Application.ForEach(app =>
                    {
                        user.Owner.Add(_jiraRepository.GetOwnerFromApp(app));
                    });

                }

            }

            return _usersList;
        }

    }
}
