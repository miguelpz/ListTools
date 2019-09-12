using FTPSearch.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTPSearch.Services
{
    public class JQLGeneratorService
    {
        private string result = null;


        public string GenerateStringsJQL (IEnumerable<TaskModelData> epicTasks)
        {
           
            

            var res =   from TaskModelData in epicTasks
                         group TaskModelData by TaskModelData.team into g
                         select new ResultModel
                         {
                             team = g.Key,                             
                             tasks = epicTasks.Where(o => o.team == g.Key).Select(o => o.key).ToList()
                         };

            res.ToList().ForEach(o => result += GenerateStringTeam(o));

            return result;


        }

        private string GenerateStringTeam (ResultModel epicTasksByTeam)
        {
            StringBuilder teamJQL = new StringBuilder();
            teamJQL.Append("Team: " + epicTasksByTeam.team);
            teamJQL.Append(" Jira Query: issuekey in (");
            epicTasksByTeam.tasks.ForEach(o => { teamJQL.Append(o + ","); });
            teamJQL.Remove(teamJQL.Length - 1, 1);
            teamJQL.Append(")\n");
            return teamJQL.ToString();
        }
        
    }
}
