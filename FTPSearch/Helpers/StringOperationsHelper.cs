using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTPSearch.Helpers
{
    static class StringOperationsHelper
    {
        static public string DeleteString(string summaryTask, string deleteString)
        {
            if (summaryTask == "")
            {
                return summaryTask;
            }


            int startIndext = deleteString.Length;
            return summaryTask.Substring(startIndext);
        }
    }
}
