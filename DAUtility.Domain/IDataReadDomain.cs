using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAUtility.Domain
{
    public interface IDataReadDomain
    {
        List<string> GetSeuritiesList(string filePath, string rootFile);
        List<String> DirSearch(string folderPath);

    }
}
