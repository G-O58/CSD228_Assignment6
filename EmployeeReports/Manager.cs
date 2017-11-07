using System;
using System.Collections;

namespace Employees
{
    // Managers need to know their number of stock options and reports
    public class Manager : Employee, IEnumerable
    {
        #region constructors 
        public Manager() { }

        public Manager(string fullName, int age, int empID,
                       float currPay, string ssn, int numbOfOpts)
          : base(fullName, age, empID, currPay, ssn)
        {
            // This property is defined by the Manager class.
            StockOptions = numbOfOpts;
        }
		#endregion

		#region Constants, data members and properties
        // Add a private member for reports
		public const int MaxReports = 5;
		private static Employee NullEmp = new Manager();
		private Employee[] _reports = { NullEmp, NullEmp, NullEmp, NullEmp, NullEmp };

        // Stock options unique to Managers
		public int StockOptions { get; set; }
        #endregion

        #region Exceptions
        // Exception raised when adding more than MaxReports to a Manager
        [System.Serializable]
        public class TooManyReportsException : ApplicationException
        {
            // Standard exception constructors
            public TooManyReportsException() {}
            public TooManyReportsException(string message) 
                : base(message) {}
            public TooManyReportsException(string message, Exception inner) 
                : base(message, inner) {}
            protected TooManyReportsException(System.Runtime.Serialization.SerializationInfo info, 
                                  System.Runtime.Serialization.StreamingContext context) 
                : base(info, context) {}
        }
		#endregion

		#region Class Methods
        // Enumerate reports for Manager
		IEnumerator IEnumerable.GetEnumerator()
		{
            // Return non-null reports
            foreach (Employee emp in _reports) {
                if (emp != NullEmp) yield return emp;
            }
		}

        // Enumerate reports, sorted by Employee Name, Age, and Pay
		public IEnumerable ReportsByName() { return GetReports(Employee.SortByName); }
		public IEnumerable ReportsByAge() { return GetReports(Employee.SortByAge); }
		public IEnumerable ReportsByPay() { return GetReports(Employee.SortByPay); }

        // Enumerator to return reports in passed sort order 
        private IEnumerable GetReports(IComparer sortOrder = null)
        {
            // Sort reports if sort order non-null
            if (sortOrder != null) Array.Sort(_reports, sortOrder);

            // Enumerate reports in specified order
			foreach (Employee emp in this) yield return emp;
		}

		// Override GiveBonus to change stock options for Manager
		public override void GiveBonus(float amount)
        {
            base.GiveBonus(amount);
            Random r = new Random();
            StockOptions += r.Next(500);
        }

        // Methods for adding/removing reports
        public virtual void AddReport(Employee report)
        {
            int emptyPos = Array.IndexOf(_reports, NullEmp);

            // Array full - no empty positions
            if (emptyPos < 0)
            {
                // Raise excepction for too many reports
				Exception ex = new TooManyReportsException(
                    string.Format("Manager already has {0} reports.", MaxReports));

                // Add Manager custom data dictionary
                ex.Data.Add("Manager", this.Name);

                // Build report string and add to custom data dictionary
				string reports = "";
				foreach (Employee emp in this) reports += emp.Name + " ";
                ex.Data.Add("Reports", reports);

                // Finally, add report that failed to be added, and throw exception
				ex.Data.Add("New Report", report.Name);
				throw ex;
            }

            // Only add report if not already a report and not same as this
            else if (Array.IndexOf(_reports, report) < 0 && this != report)
            {
                // Put Employee in empty position
                _reports.SetValue(report, emptyPos);
            }
        }

        public virtual void RemoveReport(Employee emp)
        {
            // See if the passed employee is a report
            int pos = Array.IndexOf(_reports, emp);

            if (pos >= 0)
            {
                _reports.SetValue(NullEmp, pos);
            }
        }

        // Display Manager with stock options and list of reports
        public override void DisplayStats()
        {
            base.DisplayStats();
            Console.WriteLine("Stock Options: {0:N0}", StockOptions);

            // Print out reports on a single line
            Console.Write("Reports: ");
			foreach (Employee emp in this)
				Console.Write("{0} ", emp.Name);
			Console.WriteLine();
        }
        #endregion
    }
 }