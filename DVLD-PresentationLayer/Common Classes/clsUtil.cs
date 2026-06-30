using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Common_Classes
{
    public static class clsUtil
    {
        public static string GetPathExtension(string path)
        {
            string Ext = "";

            int extIndex = -1;

            if (path.Contains('.'))
                extIndex = path.LastIndexOf(".");
            else return "";

            Ext = path.Remove(0,extIndex);

            return Ext;
        }
    }
}
