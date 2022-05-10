using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JPMorganChaseTest
{

    public class SalesProcess
    {

        public static List<ProductDetails> ProductSalesdetails = new List<ProductDetails>();
        int CounterforSales = 1;
        ProductDetails GetProductSales = new ProductDetails();
        product GetProduct = new product();
        //product productD = new product();
        public void SaleProcessMessages(string Input, int GetCorrectNumberofMessage)
        {

            // Processing the external vendor Msg  
            MessagesProcessing(Input, GetCorrectNumberofMessage);




        }

        public void MessagesProcessing(string Input, int GetCorrectNumberofMessage)
        {

            bool printResult = false;
            string productType = string.Empty;
            string productOperatorType = string.Empty;

            if (Input != string.Empty && Input != null)
            {

                // spiliting the msg using at 
                string[] message = Input.Trim().Split("at");

                //using contain funtion to go in that statment 
                // but it should not contain sales
                if ((Input.Contains("at")) && (!Input.Contains("sales")))
                {
                    if ((message.Length <= 2))
                    {
                        string quantityofPrice = message[1];
                        GetProduct.numberofSales = Convert.ToInt32(1);
                        GetProduct.typeofOperator = "";
                        GetProductSales.ProductNames = message[0].Trim();
                        //GetProductSales.ProductSales.Add()
                        GetProductSales.ProductSales.Add(GetProduct);
                        if (quantityofPrice.Contains("p"))
                        {
                            GetProduct.NumberofProductP = quantityofPrice.Replace('p', ' ');
                        }

                        var checkalreadyexistedProduct = ProductSalesdetails.Where(x => x.ProductNames == message[0]);

                        if (checkalreadyexistedProduct == null || ProductSalesdetails.Count == 0)
                        {
                            ProductSalesdetails.Add(GetProductSales);
                        }


                    }
                }

                //if customer msg contain sales 
                else if (Input.Contains("sales of"))
                {
                    string[] Finalget = null;
                    string[] getresult = Input.Trim().Split("at");
                    product GetProduct = new product();
                    int Counter = 0;
                    foreach (var Values in getresult)
                    {

                        // using counter just wanted to go inside only first time 
                        if (Counter == 0)
                        {
                            Finalget = Values.Split("sales of");
                            // getting the values on postion zero 
                            GetProduct.numberofSales = Convert.ToInt32(Finalget[0]);
                            // Trimming the space
                            GetProductSales.ProductNames = Finalget[1].Trim();
                            GetProduct.typeofOperator = "";
                            Counter++;
                        }
                        else
                        {
                            // spiting it with p
                            string[] Finalget1 = Values.Split("p");
                            GetProduct.NumberofProductP = Finalget1[0].Trim();
                        }

                    }
                    // Adding in the list 
                    GetProductSales.ProductSales.Add(GetProduct);
                    // linked list not to add in the ProductSalesdetails if product name is already added 
                    var ts = ProductSalesdetails.Where(x => x.ProductNames != Finalget[1].Trim());
                    if (ts == null)
                    {
                        ProductSalesdetails.Add(GetProductSales);
                    }
                }
                // input contain add 
                else if (Input.Contains("Add") || Input.Contains("Subtract") || Input.Contains("Multiply"))
                {


                    if (Input.Contains("Add"))
                    {

                        int totalSals = 0;
                        int totalNumberofP = 0;
                        int totalNumberofProduct = 0;
                        int getnunmberofSales = 0;


                        // using regex 
                        string[] match = null;
                        string InputSplit = Input;
                        Regex re = new Regex(@"(.{3})(.{3})(.{1})(.{6})");
                        match = re.Split(InputSplit);
                        // reset the varible as it was using previous vaule
                        product GetProductss = new product();
                        GetProductss.NumberofProductP = match[2].Trim();
                        GetProductss.typeofOperator = "Add";
                        GetProductss.numberofSales = 0;

                        //GetProduct.numberofSales = Convert.ToInt32(match[2].TrimStart());
                        //GetProduct.NumberofProductP = match[4].Trim();

                        GetProductSales.ProductSales.Add(GetProductss);

                        var ts = ProductSalesdetails.Where(x => x.ProductNames == match[3].Trim());
                        if (ts == null)
                        {
                            ProductSalesdetails.Add(GetProductSales);
                        }

                        if (GetProductSales != null)
                        {

                            //"apples"
                            var product = ProductSalesdetails.Where(x => x.ProductNames == x.ProductNames);

                            if (product != null)
                            {

                                foreach (var m in product)
                                {

                                    var namn = m.ProductSales;



                                    for (int i = namn.Count() - 1; i >= 0; i--)
                                    {

                                        var GetValue = namn[i];
                                        int CounterLopp = 0;
                                        int InsideCounterLopp = 0;
                                        if (GetValue.typeofOperator.Contains("Add"))
                                        {
                                            for (int s = namn.Count() - 1; s >= 0; s--)
                                            {
                                                CounterLopp++;

                                                GetValue = namn[s];

                                                if (GetValue.typeofOperator != "Add" || s == i)
                                                {

                                                    totalNumberofProduct = Convert.ToInt32(GetValue.NumberofProductP);
                                                    totalNumberofP = totalNumberofP + totalNumberofProduct;
                                                    getnunmberofSales = GetValue.numberofSales;

                                                    totalSals = totalSals + getnunmberofSales;

                                                    InsideCounterLopp++;

                                                }

                                                else if (CounterLopp != InsideCounterLopp)
                                                {
                                                    break;

                                                }

                                                foreach (var GetValuess in namn)
                                                {

                                                    if (GetCorrectNumberofMessage % 10 == 0)
                                                    {
                                                        printResult = true;
                                                        totalNumberofProduct = Convert.ToInt32(GetValue.NumberofProductP);
                                                        totalNumberofP = totalNumberofP + totalNumberofProduct;
                                                        getnunmberofSales = GetValue.numberofSales;

                                                        totalSals = totalSals + getnunmberofSales;

                                                    }
                                                    //else
                                                    //{
                                                    //     totalNumberofProduct = Convert.ToInt32(GetValue.NumberofProductP);
                                                    //    totalNumberofP = totalNumberofP + totalNumberofProduct;
                                                    //     getnunmberofSales = GetValue.numberofSales;

                                                    //    totalSals = totalSals + getnunmberofSales;

                                                    //}
                                                }


                                            }


                                            break;
                                        }
                                    }
                                }


                            }
                        }

                        if (printResult == false)
                        {
                            LogMessage(" Total Number of Sales " + totalSals + " Total Number of Pieces " + totalNumberofP);

                        }
                        else
                        {
                            LogMessage(" Total Number of Last 10 Sales " + totalSals + " Total Number of Pieces sold in last 10 sales " + totalNumberofP);
                        }

                    }

                    else if (Input.Contains("Subtract"))
                    {
                        bool subtractTrue = false;
                        int totalSals = 0;
                        int totalNumberofP = 0;
                        int totalNumberofProduct = 0;
                        int getnunmberofSales = 0;
                        int totalNumberofPSubtract = 0;
                        // using regex 
                        string[] match = null;
                        string InputSplit = Input;
                        Regex re = new Regex(@"(.{8})(.{2})(.{1})(.{7})");
                        match = re.Split(InputSplit);
                        // reset the varible as it was using previous vaule
                        product GetProductss = new product();
                        GetProductss.NumberofProductP = match[2].Trim();
                        GetProductss.typeofOperator = "Subtract";
                        GetProductss.numberofSales = 0;

                        //GetProduct.numberofSales = Convert.ToInt32(match[2].TrimStart());
                        //GetProduct.NumberofProductP = match[4].Trim();

                        GetProductSales.ProductSales.Add(GetProductss);

                        var ts = ProductSalesdetails.Where(x => x.ProductNames == match[3].Trim());
                        if (ts == null)
                        {
                            ProductSalesdetails.Add(GetProductSales);
                        }

                        if (GetProductSales != null)
                        {

                            //"apples"
                            var product = ProductSalesdetails.Where(x => x.ProductNames == x.ProductNames);

                            if (product != null)
                            {

                                foreach (var m in product)
                                {

                                    var namn = m.ProductSales;



                                    for (int i = namn.Count() - 1; i >= 0; i--)
                                    {

                                        var GetValue = namn[i];
                                        int CounterLopp = 0;
                                        int InsideCounterLopp = 0;
                                        if (GetValue.typeofOperator.Contains("Subtract"))
                                        {
                                            for (int s = namn.Count() - 1; s >= 0; s--)
                                            {
                                                CounterLopp++;

                                                GetValue = namn[s];

                                                if (GetValue.typeofOperator != "Subtract" || s == i)
                                                {
                                                    if (GetValue.typeofOperator == "Subtract")
                                                    {
                                                        subtractTrue = true; ;
                                                        totalNumberofProduct = Convert.ToInt32(GetValue.NumberofProductP);
                                                        totalNumberofPSubtract = totalNumberofProduct;
                                                        getnunmberofSales = GetValue.numberofSales;

                                                        totalSals = totalSals + getnunmberofSales;

                                                        InsideCounterLopp++;
                                                    }

                                                    else
                                                    {

                                                        totalNumberofProduct = Convert.ToInt32(GetValue.NumberofProductP);
                                                        totalNumberofP = totalNumberofP + totalNumberofProduct;
                                                        getnunmberofSales = GetValue.numberofSales;

                                                        totalSals = totalSals + getnunmberofSales;

                                                        InsideCounterLopp++;

                                                    }



                                                }

                                                else if (CounterLopp != InsideCounterLopp)
                                                {
                                                 

                                                    break;
                                                  
                                                }

                                                foreach (var GetValuess in namn)
                                                {

                                                    if (GetCorrectNumberofMessage % 10 == 0)
                                                    {
                                                        printResult = true;
                                                        totalNumberofProduct = Convert.ToInt32(GetValue.NumberofProductP);
                                                        totalNumberofP = totalNumberofP - totalNumberofProduct;
                                                        getnunmberofSales = GetValue.numberofSales;

                                                        totalSals = totalSals - getnunmberofSales;

                                                    }
                                                    //else
                                                    //{
                                                    //     totalNumberofProduct = Convert.ToInt32(GetValue.NumberofProductP);
                                                    //    totalNumberofP = totalNumberofP + totalNumberofProduct;
                                                    //     getnunmberofSales = GetValue.numberofSales;

                                                    //    totalSals = totalSals + getnunmberofSales;

                                                    //}
                                                }


                                            }
                                            if (subtractTrue == true)
                                            {

                                                totalNumberofP = totalNumberofP - totalNumberofPSubtract;

                                            }

                                            break;
                                        }
                                    }
                                }


                            }
                        }

                        if (printResult == false)
                        {
                            LogMessage(" Total Number of Sales " + totalSals + " Total Number of Pieces " + totalNumberofP);

                        }
                        else
                        {
                            LogMessage(" Total Number of Last 10 Sales " + totalSals + " Total Number of Pieces sold in last 10 sales " + totalNumberofP);
                        }
                    }



                    else if (Input.Contains("Multiply"))
                    {
                        bool subtractTrue = false;
                        bool multiplyTrue = false;

                        int totalSals = 0;
                        int totalNumberofP = 0;
                        int totalNumberofProduct = 0;
                        int getnunmberofSales = 0;
                        int totalNumberofPSubtract = 0;
                        int totalNumberofPMultiply = 0;
                        
                        // using regex 
                        string[] match = null;
                        string InputSplit = Input;
                        Regex re = new Regex(@"(.{8})(.{2})(.{1})(.{7})");
                        match = re.Split(InputSplit);
                        // reset the varible as it was using previous vaule
                        product GetProductss = new product();
                        GetProductss.NumberofProductP = match[2].Trim();
                        GetProductss.typeofOperator = "Multiply";
                        GetProductss.numberofSales = 0;

                        //GetProduct.numberofSales = Convert.ToInt32(match[2].TrimStart());
                        //GetProduct.NumberofProductP = match[4].Trim();

                        GetProductSales.ProductSales.Add(GetProductss);

                        var ts = ProductSalesdetails.Where(x => x.ProductNames == match[3].Trim());
                        if (ts == null)
                        {
                            ProductSalesdetails.Add(GetProductSales);
                        }

                        if (GetProductSales != null)
                        {

                            //"apples"
                            var product = ProductSalesdetails.Where(x => x.ProductNames == x.ProductNames);

                            if (product != null)
                            {

                                foreach (var m in product)
                                {

                                    var namn = m.ProductSales;



                                    for (int i = namn.Count() - 1; i >= 0; i--)
                                    {

                                        var GetValue = namn[i];
                                        int CounterLopp = 0;
                                        int InsideCounterLopp = 0;
                                        if (GetValue.typeofOperator.Contains("Multiply"))
                                        {
                                            for (int s = namn.Count() - 1; s >= 0; s--)
                                            {
                                                CounterLopp++;

                                                GetValue = namn[s];

                                                if (GetValue.typeofOperator != "Multiply" || s == i)
                                                {
                                                    if (GetValue.typeofOperator == "Multiply")
                                                    {
                                                        multiplyTrue = true; ;
                                                        totalNumberofPMultiply = Convert.ToInt32(GetValue.NumberofProductP);
                                                        totalNumberofPSubtract = totalNumberofProduct;
                                                        getnunmberofSales = GetValue.numberofSales;

                                                        totalSals = totalSals + getnunmberofSales;

                                                        InsideCounterLopp++;
                                                    }

                                                    else
                                                    {

                                                        totalNumberofProduct = Convert.ToInt32(GetValue.NumberofProductP);
                                                        totalNumberofP = totalNumberofP + totalNumberofProduct;
                                                        getnunmberofSales = GetValue.numberofSales;

                                                        totalSals = totalSals + getnunmberofSales;

                                                        InsideCounterLopp++;

                                                    }



                                                }

                                                else if (CounterLopp != InsideCounterLopp)
                                                {


                                                    break;

                                                }

                                                foreach (var GetValuess in namn)
                                                {

                                                    if (GetCorrectNumberofMessage % 10 == 0)
                                                    {
                                                        printResult = true;
                                                        totalNumberofProduct = Convert.ToInt32(GetValue.NumberofProductP);
                                                        totalNumberofP = totalNumberofP - totalNumberofProduct;
                                                        getnunmberofSales = GetValue.numberofSales;

                                                        totalSals = totalSals - getnunmberofSales;

                                                    }
                                                    //else
                                                    //{
                                                    //     totalNumberofProduct = Convert.ToInt32(GetValue.NumberofProductP);
                                                    //    totalNumberofP = totalNumberofP + totalNumberofProduct;
                                                    //     getnunmberofSales = GetValue.numberofSales;

                                                    //    totalSals = totalSals + getnunmberofSales;

                                                    //}
                                                }


                                            }
                                            if (subtractTrue == true)
                                            {

                                                totalNumberofP = totalNumberofP - totalNumberofPSubtract;

                                            }

                                            if (multiplyTrue == true)
                                            {

                                                totalNumberofP = totalNumberofP * totalNumberofPMultiply;

                                            }

                                            break;
                                        }
                                    }
                                }


                            }
                        }

                        if (printResult == false)
                        {
                            LogMessage(" Total Number of Sales " + totalSals + " Total Number of Pieces " + totalNumberofP);

                        }
                        else
                        {
                            LogMessage(" Total Number of Last 10 Sales " + totalSals + " Total Number of Pieces sold in last 10 sales " + totalNumberofP);
                        }

                    }
                    else
                    {
                        Console.WriteLine("Wrong Msg");

                    }



                }




                CounterforSales++;
               




            }
            else
            {
                throw new Exception();
            }

        }


        private void LogMessage(string message)
        {
            var folder = Directory.CreateDirectory(@"C:\logfile"); // returns a DirectoryInfo object
            string log_file_path = @"C:\logfile\logfile.txt";
            // ConfigurationManager.AppSettings["EnableLogging"];
            string enableLogging = "1";

            if (enableLogging.Equals("1"))
            {
                var logFile = new LogFile();
                logFile.FilePath = log_file_path;

                using (StreamWriter sw = (File.Exists(logFile.FilePath)) ? File.AppendText(logFile.FilePath) : File.CreateText(logFile.FilePath))
                {
                    sw.WriteLine(DateTime.Now + message);
                    sw.Close();
                }
            }
        }
        public double parseProductPrice(string parsePrice)
        {
            double price = Double.Parse(parsePrice.Replace("£|p", ""));
            if (!parsePrice.Contains("."))
            {
                price = price / 100;

            }
            return price;
        }

        public string parseProductType(string parseMessage)
        {
            String parsedType = "";
            String typeWithoutLastChar = parseMessage.Substring(0, parseMessage.Length - 1);

            if (parseMessage.EndsWith("o"))
            {
                parsedType = String.Format("%soes", typeWithoutLastChar);
            }
            else if (parseMessage.EndsWith("y"))
            {
                parsedType = String.Format("%sies", typeWithoutLastChar);
            }
            else if (parseMessage.EndsWith("h"))
            {
                parsedType = String.Format("%shes", typeWithoutLastChar);
            }
            else if (!parseMessage.EndsWith("s"))
            {
                parsedType = String.Format("%ss", parseMessage);
            }
            else
            {
                parsedType = String.Format("%s", parseMessage);
            }
            return parsedType.ToLower();
        }
    }

}




