using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Common_Classes
{
    public static class clsUtil
    {
        public static string GetPathExtension(string path)
        {
            string Ext = "";

            int extIndex = -1;
            try
            {
                if (path.Contains('.'))
                    extIndex = path.LastIndexOf(".");
                else return "";

            }
            catch (Exception) {
                return "";
            }

            Ext = path.Remove(0,extIndex);

            return Ext;
        }

        public static string CustomShortDate(DateTime date)
        {
            return date.ToString("dd")+"/"+date.ToString("MMM")+"/"+date.ToString("yyyy");
        }

        private static string ImagesFolderPath = @"C:\DVLD\People-Images\";
        private static bool CreateImagesFolderIfNotExist()
        {
           
            if (!Directory.Exists(ImagesFolderPath))
            {
                try
                {
                    Directory.CreateDirectory(ImagesFolderPath);

                }
                catch (Exception) {
                    return false;
                }
            }
            return true;
        }

        private static string ChangeImageNameToGUID(string ImageFileName)
        {
            string GUID = Guid.NewGuid().ToString();

            FileInfo fileInfo = new FileInfo(ImageFileName);
            string ext =  fileInfo.Extension;

            return GUID + ext;

        }
        public static bool CopyImageToProjectFolderImages(ref string SourceImageLocation)
        {
            if (!CreateImagesFolderIfNotExist()) { 
                return false;
            }

            string DestinationImageLocation = ImagesFolderPath + ChangeImageNameToGUID(SourceImageLocation);

            try
            {
                File.Copy(SourceImageLocation, DestinationImageLocation,true);

            }
            catch (IOException iox)
            {
                MessageBox.Show(iox.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            SourceImageLocation = DestinationImageLocation;
            return true;
        }

    }
}
