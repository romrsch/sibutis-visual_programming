using Project.Models;
using System.Collections;

namespace Project.DB
{
    // Класс-синглтон таблицы "customers"
    public class CustomersDBTable : DBTable
    {
        private static CustomersDBTable? INSTANCE;
        public static DBTable Instance
        {
            get
            {
                INSTANCE ??= new CustomersDBTable();
                return INSTANCE;
            }
        }

        private CustomersDBTable() : base("customers") { }

        public override string[] GetColumnsNames() => new string[] { "CustomerId", "FirstName", "LastName", "Company",
            "Address", "City", "State", "Country", "PostalCode", "Phone", "Fax",
            "Email", "SupportRepId" };
        protected override IList CreateListOfModel() => new List<Customer>();
        protected override Model CreateModel() => new Customer();
    }
}
