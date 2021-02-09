using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAUtility.Repository
{
    public class Trades
    {
        public string code { get; set; }
        public string transactionCode { get; set; }
        public string tradeDate { get; set; }
        public double quantity { get; set; }
        public double price { get; set; }

    }
}
