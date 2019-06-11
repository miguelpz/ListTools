using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace FTPSearch.RenameServices
{
    public static class RenameExtensions
    {       
        public static string TrimNugetVersion (this String appName)
        {
            var index = Regex.Match(appName, ".[0-9]").Index;

            if (index != 0)
            {
                return appName.Remove(index);
            }
            else
            {
                return appName;
            }

                    
        }

    }
}
