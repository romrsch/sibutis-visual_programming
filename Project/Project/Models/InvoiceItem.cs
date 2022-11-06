using Microsoft.Data.Sqlite;

namespace Project.Models
{
    public class InvoiceItem : Model
    {
        public InvoiceItem() { }

        public InvoiceItem(SqliteDataReader reader) : base(reader) { }

        public override string[] GetColumnNames() => new string[] { "InvoiceLineId", "InvoiceId", "TrackId", "UnitPrice", "Quantity" };

        public override void InitFromGridRow(DataGridViewRow row)
        {
            if (row.Cells.Count != 5)
                return;

            if (int.TryParse((string)row.Cells[0].Value, out int value))
                data["GenreId"] = value;
            if (int.TryParse((string)row.Cells[1].Value, out value))
                data["InvoiceId"] = value;
            if (int.TryParse((string)row.Cells[2].Value, out value))
                data["TrackId"] = value;

            if (decimal.TryParse((string)row.Cells[3].Value, out decimal d))
                data["UnitPrice"] = d;

            if (int.TryParse((string)row.Cells[4].Value, out value))
                data["Quantity"] = value;
        }

        protected override Dictionary<string, object> CreateData() => new()
        {
            ["GenreId"] = 0,
            ["InvoiceId"] = 0,
            ["TrackId"] = 0,
            ["UnitPrice"] = 0.0m,
            ["Quantity"] = 0
        };
    }
}
