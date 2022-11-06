using Microsoft.Data.Sqlite;

namespace Project.Models
{
    public class Customer : Model
    {
        public Customer() { }

        public Customer(SqliteDataReader reader) : base(reader) { }

        public override string[] GetColumnNames() => new string[] { "CustomerId", "FirstName", "LastName", "Company",
            "Address", "City", "State", "Country", "PostalCode", "Phone", "Fax",
            "Email", "SupportRepId" };

        public override void InitFromGridRow(DataGridViewRow row)
        {
            if (row.Cells.Count != 13)
                return;

            if (int.TryParse((string)row.Cells[0].Value, out int value))
                data["CustomerId"] = value;

            data["FirstName"] = (string)row.Cells[1].Value;
            data["LastName"] = (string)row.Cells[2].Value;
            data["Company"] = (string)row.Cells[3].Value;
            data["Address"] = (string)row.Cells[4].Value;
            data["City"] = (string)row.Cells[5].Value;
            data["State"] = (string)row.Cells[6].Value;
            data["Country"] = (string)row.Cells[7].Value;
            data["PostalCode"] = (string)row.Cells[8].Value;
            data["Phone"] = (string)row.Cells[9].Value;
            data["Fax"] = (string)row.Cells[10].Value;
            data["Email"] = (string)row.Cells[11].Value;

            if (int.TryParse((string)row.Cells[12].Value, out value))
                data["SupportRepId"] = value;

        }

        protected override Dictionary<string, object> CreateData() => new()
        {
            ["CustomerId"] = 0,
            ["FirstName"] = "",
            ["LastName"] = "",
            ["Company"] = "",
            ["Address"] = "",
            ["City"] = "",
            ["State"] = "",
            ["Country"] = "",
            ["PostalCode"] = "",
            ["Phone"] = "",
            ["Fax"] = "",
            ["Email"] = "",
            ["SupportRepId"] = 0,
        };
    }
}
