using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;
using XFFinanceManager.iOS.Helper;
using XFFinanceManager.Interface;

[assembly: Dependency(typeof(LocalFileHelper))]
namespace XFFinanceManager.iOS.Helper
{
    public class LocalFileHelper : ILocalFileHelper
    {
        public string GetLocalFilePath(string fileName)
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");
            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }
            return Path.Combine(libFolder, fileName);
        }
    }
}
