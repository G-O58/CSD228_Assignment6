using System;
using System.Collections;

namespace Employees
{
    abstract public partial class Employee
    {
        #region Nested benefit packages
        public class BenefitPackage
        {
            public enum BenefitPackageLevel
            {
                Standard, Gold, Platinum
            }

            // Assume we have other members that represent
            // dental/health benefits, and so on.
            public double ComputePayDeduction()
            {
                return 125.0;
            }
        }
        #endregion

        #region Class methods 
        public virtual void GiveBonus(float amount)
        { Pay += amount; }

        public virtual void DisplayStats()
        {
            Console.WriteLine("Name: {0}", Name);
            Console.WriteLine("ID: {0}", ID);
            Console.WriteLine("Age: {0}", Age);
            Console.WriteLine("Pay: {0:C}", Pay);
            Console.WriteLine("SSN: {0}", SocialSecurityNumber);
        }
        #endregion

        #region Traditional Get / Set method
        // Accessor (get method)
        public string GetName()
        {
            return empName;
        }

        // Mutator (set method)
        public void SetName(string name)
        {
            // Do a check on incoming value
            // before making assignment.
            if (name.Length > 15)
                Console.WriteLine("Error!  Name must be less than 15 characters!");
            else
                empName = name;
        }
		#endregion

		#region Employee sort oders
		// Sort employees by name.
		private class NameComparer : IComparer
		{
			// Compare the name of each object.
			int IComparer.Compare(object o1, object o2)
			{
				Employee t1 = o1 as Employee;
				Employee t2 = o2 as Employee;
				if (t1 != null && t2 != null)
					return String.Compare(t1.Name, t2.Name);
				else
					throw new ArgumentException("Parameter is not an Employee!");
			}
		}

		// Sort by age
		private class AgeComparer : IComparer
		{
			// Compare the Age of each object.
			int IComparer.Compare(object o1, object o2)
			{
				Employee t1 = o1 as Employee;
				Employee t2 = o2 as Employee;
				if (t1 != null && t2 != null)
					return t1.Age.CompareTo(t2.Age);
				else
					throw new ArgumentException("Parameter is not an Employee!");
			}
		}
		
        // Sort By pay
		private class PayComparer : IComparer
		{
			// Compare the Pay of each object.
			int IComparer.Compare(object o1, object o2)
			{
				Employee t1 = o1 as Employee;
				Employee t2 = o2 as Employee;
				if (t1 != null && t2 != null)
					return t1.Pay.CompareTo(t2.Pay);
				else
					throw new ArgumentException("Parameter is not an Employee!");
			}
		}

		// Static, read-only properties to return Employee Name, Age, or Pay comparers
		public static IComparer SortByName { get; } = new NameComparer();
		public static IComparer SortByPay { get; } = new PayComparer();
		public static IComparer SortByAge { get; } = new AgeComparer();

		#endregion
	}
}