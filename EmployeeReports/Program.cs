using System;
using System.Collections;

namespace Employees
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Assignment 4: Employee Reports *****\n");

            // Create Employees
            Manager chucky = new Manager("Chucky", 50, 92, 100000, "333-23-2322", 9000);
			Manager mary   = new Manager("Mary", 54, 90, 200000, "121-12-1211", 9500);
			SalesPerson fran = new SalesPerson("Fran", 43, 93, 80000, "932-32-3232", 31);
            SalesPerson bob = new SalesPerson("Bob", 31, 94, 120000, "334-24-2422", 30);
            PTSalesPerson sally = new PTSalesPerson("Sally", 32, 95, 30000, "913-43-4343", 10);
            PTSalesPerson sam = new PTSalesPerson("Sam", 33, 96, 20000, "525-76-5030", 20);
			PTSalesPerson mike = new PTSalesPerson("Mike", 45, 91, 15000, "229-67-7898", 30);

			// Employee list
			Employee[] emps = { chucky, mary, fran, bob, sally, sam, mike };

            // handlers go here
            chucky.TooMany += TooManyReports;
            mary.TooMany += TooManyReports;

            chucky.TooMany += delegate(object sender, ManagerEventArgs manEvent)
            {
                Console.WriteLine(manEvent.Message());
            };
            mary.TooMany += delegate (object sender, ManagerEventArgs manEvent)
            {
                Console.WriteLine(manEvent.Message());
            };

            chucky.TooMany += (sender, manEvent) => Console.WriteLine(manEvent.Message());
            mary.TooMany += (sender, manEvent) => Console.WriteLine(manEvent.Message());

            // Add reports
            // try
            {
                mary.AddReport(fran);
                mary.AddReport(mike);
                chucky.AddReport(bob);
                chucky.AddReport(sally);
                chucky.AddReport(sam);
                mary.RemoveReport(fran);
                mary.RemoveReport(chucky);
                chucky.AddReport(fran);
                chucky.AddReport(mike);
                chucky.AddReport(mary);
            }
   // 		catch(Manager.TooManyReportsException e)
			//{
			//	Console.WriteLine("*** Error! ***");
			//	Console.WriteLine("Source: {0}", e.Source);
			//	Console.WriteLine("Method: {0}", e.TargetSite);
			//	Console.WriteLine("Message: {0}", e.Message);
			//	Console.WriteLine("Custom Data:");
			//	foreach (DictionaryEntry de in e.Data)
			//		Console.WriteLine("-> {0}: {1}", de.Key, de.Value);

			//}

            Console.WriteLine("\nDisplay Managers\n");
			mary.DisplayStats();
            Console.WriteLine();
            chucky.RemoveReport(sam); // Remove a report for testing
            chucky.DisplayStats();
            Console.Write("Reports by Name: ");
            foreach (Employee emp in chucky.ReportsByName())
                Console.Write("{0} ", emp.Name);
			Console.Write("\nReports by Age: ");
			foreach (Employee emp in chucky.ReportsByAge())
				Console.Write("{0}-{1} ", emp.Age, emp.Name);
			Console.Write("\nReports by Pay: ");
			foreach (Employee emp in chucky.ReportsByPay())
                Console.Write("{0:C}-{1} ", emp.Pay, emp.Name);
            Console.WriteLine();

			Console.ReadLine();
        }

        //the required method thingy
        public static void TooManyReports(object sender, ManagerEventArgs manEvent)
        {
            Console.WriteLine(manEvent.Message());
        }
    }
}