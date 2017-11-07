using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    public class ManagerEventArgs : EventArgs
    {
        public readonly Manager manager;
        public readonly Employee employee;

        public ManagerEventArgs(Manager manager, Employee employee)
        {
            this.manager = manager;
            this.employee = employee;
        }

        public virtual string Message()
        {
            StringBuilder retString = new StringBuilder();
            retString.Append(manager.Name);
            retString.Append(" has ");
            retString.Append(Manager.MaxReports);
            retString.Append(" reports, can not add report ");
            retString.Append(employee.Name);
            return retString.ToString();

        }
    }
}
