using Project.Models;
using System.Collections;

namespace Project.DB
{
    // Класс-синглтон таблицы "invoice_items"
    public class InvoiceItemsDBTable : DBTable
    {
        private static InvoiceItemsDBTable? INSTANCE;
        public static DBTable Instance
        {
            get
            {
                INSTANCE ??= new InvoiceItemsDBTable();
                return INSTANCE;
            }
        }

        private InvoiceItemsDBTable() : base("invoice_items") { }

        public override string[] GetColumnsNames() => new string[] { "InvoiceLineId", "InvoiceId", "TrackId", "UnitPrice", "Quantity" };
        protected override IList CreateListOfModel() => new List<InvoiceItem>();
        protected override Model CreateModel() => new InvoiceItem();
    }
}
