using Project.Models;
using System.Collections;

namespace Project.DB
{
    // Класс-синглтон таблицы "invoices"
    public class InvoicesDBTable : DBTable
    {
        private static InvoicesDBTable? INSTANCE;
        public static DBTable Instance
        {
            get
            {
                INSTANCE ??= new InvoicesDBTable();
                return INSTANCE;
            }
        }

        private InvoicesDBTable() : base("invoices") { }

        public override string[] GetColumnsNames() => new string[] { "InvoiceId", "CustomerId", "InvoiceDate", "BillingAddress",
            "BillingCity", "BillingState", "BillingCountry", "BillingPostalCode", "Total" };
        protected override IList CreateListOfModel() => new List<Invoice>();
        protected override Model CreateModel() => new Invoice();
    }
}
