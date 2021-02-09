using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using DAUtility.Repository;

namespace DAUtility.Domain
{
    public class DataReadDomain:IDataReadDomain
    { 
        private IDataReadRepository datareadRepository;
        public DataReadDomain(IDataReadRepository datareadRepository)
        {
            this.datareadRepository = datareadRepository;
        }
       public List<string> GetSeuritiesList(string filePath, string rootFile)
       {
            Console.WriteLine("");
            Console.WriteLine("1. Section to view all data aggregated by BloombergId, TransactionCode, Trade Date, Sum on Quantity and Average Price");
            XmlReader securityList = datareadRepository.GetSeuritiesList(filePath);
            var tradeList = datareadRepository.GetTradesSampleList(rootFile);
            Console.WriteLine("");
            Console.WriteLine("  BloombergId  |  TransactionCode  |  TradeDate  |  Quantity  |  Price  ");
           
            List<Trades> result = tradeList
                .GroupBy(l => l.transactionCode)
                .SelectMany(cl => cl.Select(
                    csLine => new Trades
                    {
                        code = csLine.code,
                        transactionCode=csLine.transactionCode,
                        quantity = cl.Sum(c => c.quantity),
                        price = cl.Average(c => c.price),
                        tradeDate = csLine.tradeDate,

                    })).ToList<Trades>();

            Console.WriteLine("------------------------------------------------------------------------------------");
            foreach (var item in result)
            {
                Console.WriteLine("  "+item.code+"  |  "+item.transactionCode+ "  |  " + item.tradeDate+ "  |Sum of Quantity:  " + item.quantity+ "  |Avg Price  " + item.price);
            }
            return null; 
       }

        public List<String> DirSearch(string folderPath)
        {
            Console.WriteLine("");
            Console.WriteLine("2. Read all files with names starting with Trades and .xml as their extension within root folder (C:\\Engineer Code Test\\Test) & all its sub folders");
            Console.WriteLine("");
            
            var data = datareadRepository.DirSearch(folderPath);
            foreach (var item in data)
            {
                Console.WriteLine(item);
            }
            return null;
        }
    }
}
