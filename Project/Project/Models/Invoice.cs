using Microsoft.Data.Sqlite;

namespace Project.Models
{
    public class Invoice : Model
    {
        public Invoice() { }

        public Invoice(SqliteDataReader reader) : base(reader) { }

        public override string[] GetColumnNames() => new string[] { "InvoiceId", "CustomerId", "InvoiceDate", "BillingAddress",
            "BillingCity", "BillingState", "BillingCountry", "BillingPostalCode", "Total" };

        public override void InitFromGridRow(DataGridViewRow row)
        {
            if (row.Cells.Count != 9)
                return;

            if (int.TryParse((string)row.Cells[0].Value, out int value))
                data["InvoiceId"] = value;
            if (int.TryParse((string)row.Cells[1].Value, out value))
                data["CustomerId"] = value;

            DateTime dateTime = new();
            if (DateTime.TryParse((string)row.Cells[2].Value, out dateTime))
                data["InvoiceDate"] = dateTime;

            data["BillingAddress"] = (string)row.Cells[3].Value;
            data["BillingCity"] = (string)row.Cells[4].Value;
            data["BillingState"] = (string)row.Cells[5].Value;
            data["BillingCountry"] = (string)row.Cells[6].Value;
            data["BillingPostalCode"] = (string)row.Cells[7].Value;

            if (decimal.TryParse((string)row.Cells[0].Value, out decimal d))
                data["Total"] = d;
        }

        protected override Dictionary<string, object> CreateData() => new()
        {
            ["InvoiceId"] = 0,
            ["CustomerId"] = 0,
            ["InvoiceDate"] = new DateTime(),
            ["BillingAddress"] = "",
            ["BillingCity"] = "",
            ["BillingState"] = "",
            ["BillingCountry"] = "",
            ["BillingPostalCode"] = "",
            ["Total"] = 0.0m
        };
    }
}
