using DAUtility.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DAUtility
{
    public class ServiceCaller:IServiceCaller
    {
        public readonly IDataReadDomain dataReadDomain;
       public ServiceCaller(IDataReadDomain dataReadDomain)
       {
            this.dataReadDomain = dataReadDomain;
       }
        public void ReadSeculitiesDetails()
        {
            string filePath = ConfigurationManager.AppSettings["FilePath"];
            string rootFile = ConfigurationManager.AppSettings["RootFilePath"];
            var data = dataReadDomain.GetSeuritiesList(filePath, rootFile);
        }
        public void ReadFolderFiles()
        {
            string folderPath = ConfigurationManager.AppSettings["FolderPath"];
            var data = dataReadDomain.DirSearch( folderPath);
        }
    }
}
