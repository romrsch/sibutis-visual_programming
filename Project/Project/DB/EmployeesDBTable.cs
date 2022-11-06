using Project.Models;
using System.Collections;

namespace Project.DB
{
    // Класс-синглтон таблицы "employees"
    internal class EmployeesDBTable : DBTable
    {
        private static EmployeesDBTable? INSTANCE;
        public static DBTable Instance
        {
            get
            {
                INSTANCE ??= new EmployeesDBTable();
                return INSTANCE;
            }
        }

        private EmployeesDBTable() : base("employees") { }

        public override string[] GetColumnsNames() => new string[] { "EmployeeId", "LastName", "FirstName", "Title",
                "ReportsTo", "BirthDate", "HireDate", "Address",
                "City", "State", "Country", "PostalCode",
                "Phone", "Fax", "Email" };
        protected override IList CreateListOfModel() => new List<Employee>();
        protected override Model CreateModel() => new Employee();
    }
}