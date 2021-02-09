using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DAUtility.Repository
{
    public class DataReadRepository:IDataReadRepository
    {

        //Read C:\Engineer Code Test\Securities.xml which contains a list of known securities.
        public DataReadRepository()
        {

        }
        public XmlReader GetSeuritiesList(string filePath)
       {
           
            List<string> strArray = new List<string>();
            if (System.IO.File.Exists(filePath))
            {
                // Read file using StreamReader. Reads file line by line  
                using (XmlReader reader = XmlReader.Create(filePath))
                {
                    while (reader.Read())
                    {
                        if (reader.IsStartElement())
                        {
                            return reader;
                        }
                    }
                }
            }

            return null ;
       }
        public List<Trades> GetTradesSampleList(string rootFile)
        {
            //string textFile = "C:\\Engineer Code Test\\TradesSample.xml";
            List<Trades> trades = new List<Trades>();
            List<string> strArray = new List<string>();
            XmlNodeList xmlnode;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(rootFile);
            XmlNodeList nodeList = xmlDoc.DocumentElement.SelectNodes("/trades/trade");
            xmlnode = xmlDoc.GetElementsByTagName("trade");
            for (int i = 0; i < xmlnode.Count; i++)
            {
                Trades trade = new Trades();
                trade.tradeDate  = xmlnode[i].ChildNodes.Item(1).InnerText.Trim();
                trade.transactionCode= xmlnode[i].ChildNodes.Item(4).InnerText.Trim();
                trade.quantity = Convert.ToDouble(xmlnode[i].ChildNodes.Item(5).InnerText.Trim());
                trade.price =Convert.ToDouble( xmlnode[i].ChildNodes.Item(8).InnerText.Trim());
                trade.code = xmlnode[i].ChildNodes.Item(10).InnerText.Trim();
                trades.Add(trade);
            }
          
            return trades;
        }
        public List<String> DirSearch(string folderPath)
        { 
            //string sDir = "C:\\Engineer Code Test\\";
            string[] allfiles = Directory.GetFiles(folderPath, "*Trades*", SearchOption.AllDirectories);
           // string[] allfilesext = Directory.GetFiles(sDir, "*.xml*", SearchOption.AllDirectories);
            List<String> files = new List<String>();
           
            try
            {           
                foreach (string d in allfiles)
                {
                    files.Add(d);
                }
            }
            catch (System.Exception excpt)
            {
                //MessageBox.Show(excpt.Message);
            }

            return files;
        }
    }
}
