using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DAUtility.Repository
{
    public interface IDataReadRepository
    {
        List<String> DirSearch(string folderPath);
        XmlReader GetSeuritiesList(string filePath);
        List<Trades> GetTradesSampleList(string rootFile);
    }
}
