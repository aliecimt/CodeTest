using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using DAUtility.Domain;
using DAUtility.Repository;
using Unity;

namespace DAUtility
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadDataFile readDataFile = new ReadDataFile();
            readDataFile.Execute();
        }
        
    }

    class ReadDataFile
    {
        private ServiceCaller serviceCaller;
        public void Execute()
        {
            IUnityContainer contaner = new UnityContainer();
            contaner.RegisterType<IServiceCaller, ServiceCaller>();
            contaner.RegisterType<IDataReadDomain, DataReadDomain>();
            contaner.RegisterType<IDataReadRepository, DataReadRepository>();

            serviceCaller = contaner.Resolve<ServiceCaller>();
            serviceCaller.ReadSeculitiesDetails();
            serviceCaller.ReadFolderFiles();
            Console.ReadKey();
        }
    }
}
