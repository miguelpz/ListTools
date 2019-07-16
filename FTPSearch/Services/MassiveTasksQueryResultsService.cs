using FTPSearch.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTPSearch.Services
{
    public class MassiveTasksQueryResultsService
    {
        private List<TaskModelData> totalResults;

        public MassiveTasksQueryResultsService()
        {
            totalResults = new List<TaskModelData>();
        }


        public void AddFoundTeamList (List<TaskModelData> taskList)
        {

            totalResults.AddRange(taskList);
        }


        public void ClearLists()
        {
            totalResults.Clear();
        }
       



        public string GetAllTeams()
        {
            var result = from TaskModelData in totalResults
                            group TaskModelData by TaskModelData.team into g
                            select new
                            {
                                team = g.Key,
                                tasks = totalResults.Where(o => o.team == g.Key).Select(o => o.key).ToList()

                            };

            return JsonConvert.SerializeObject(result);
        }

       


    }
}
