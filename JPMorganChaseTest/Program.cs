using System;
using System.Collections.Generic;
using System.Linq;

namespace JPMorganChaseTest
{
    class Program
    {
		
		static void Main(string[] args)
        {
		 
        
            try
			{
				//Read the file
				string[] lines = System.IO.File.ReadAllLines(@"C:\Users\MohammadJohar\source\repos\JPMorganChaseTest\testInput\input.txt");
				SalesProcess GetSalesDetails = new SalesProcess();
 
				for (int i=0; i <= lines.Count(); i++)
               {
					// Redaing 1 by one line 
					string GetProductInfo = lines[i];
					// Processing the msg  and geting the line number of msg number 
					GetSalesDetails.SaleProcessMessages(GetProductInfo, i);
			   }


			} 
			catch (Exception e)

            { 
			
			
			
			}

			Console.WriteLine("Hello World!");
        }



		//public class SalesMessageProcessor
		//{
		//	public static void main(String[] args)
		//	{
		//		// Initiate the sale object
		//		Sale sale = new Sale();

		//		// Read inputs from test file
		//		try
		//		{
		//			String line;
		//			BufferedReader inputFile = new BufferedReader(new FileReader("testInput/input.txt"));
		//			while ((line = inputFile.readLine()) != null)
		//			{
		//				// process message for each sale notification
		//				sale.processNotification(line);

		//				// Call the report
		//				// @note: report only generates after every 10th iteration and stops on 50th
		//				// iteration and pauses for
		//				// 2 seconds.
		//				sale.log.report();
		//			}
		//		}
		//		catch (java.io.IOException e)
		//		{
		//			e.printStackTrace();
		//		}
		//	}
		//}


	}
}
