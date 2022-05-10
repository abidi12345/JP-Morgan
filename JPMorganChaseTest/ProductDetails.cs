using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPMorganChaseTest
{
    public class ProductDetails
    {
     
        public string ProductNames { get; set; }
        public List<product> ProductSales = new List<product>();

    }

    public class LogFile
    {
        public string FilePath { get; set; }
    }

}

public class product
{
    public int numberofSales { get; set; }
    public string typeofOperator { get; set; }


    //  public string ProductName { get; set; }

    public string NumberofProductP { get; set; }
}
