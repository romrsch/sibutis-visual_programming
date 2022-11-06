using Microsoft.Data.Sqlite;

namespace Project.Models
{
    internal class Employee : Model
    {
        public Employee() { }

        public Employee(SqliteDataReader reader) : base(reader) { }

        public override void InitFromGridRow(DataGridViewRow row)
        {
            if (row.Cells.Count != 15)
                return;

            if (int.TryParse((string)row.Cells[0].Value, out int value))
                data["EmployeeId"] = value;

            data["LastName"] = (string)row.Cells[1].Value;
            data["FirstName"] = (string)row.Cells[2].Value;
            data["Title"] = (string)row.Cells[3].Value;

            if (int.TryParse((string)row.Cells[4].Value, out value))
                data["ReportsTo"] = value;

            DateTime dateTimeValue = new();
            if (DateTime.TryParse((string)row.Cells[5].Value, out dateTimeValue))
                data["BirthDate"] = dateTimeValue;
            if (DateTime.TryParse((string)row.Cells[6].Value, out dateTimeValue))
                data["HireDate"] = dateTimeValue;

            data["Address"] = (string)row.Cells[7].Value;
            data["City"] = (string)row.Cells[8].Value;
            data["State"] = (string)row.Cells[9].Value;
            data["Country"] = (string)row.Cells[10].Value;
            data["PostalCode"] = (string)row.Cells[11].Value;
            data["Phone"] = (string)row.Cells[12].Value;
            data["Fax"] = (string)row.Cells[13].Value;
            data["Email"] = (string)row.Cells[14].Value;
        }

        public override string[] GetColumnNames() => new string[] { "EmployeeId", "LastName", "FirstName", "Title",
                "ReportsTo", "BirthDate", "HireDate", "Address",
                "City", "State", "Country", "PostalCode",
                "Phone", "Fax", "Email" };

        protected override Dictionary<string, object> CreateData() => new()
        {
            ["EmployeeId"] = 0,
            ["LastName"] = "",
            ["FirstName"] = "",
            ["Title"] = "",
            ["ReportsTo"] = 0,
            ["BirthDate"] = new DateTime(),
            ["HireDate"] = new DateTime(),
            ["Address"] = "",
            ["City"] = "",
            ["State"] = "",
            ["Country"] = "",
            ["PostalCode"] = "",
            ["Phone"] = "",
            ["Fax"] = "",
            ["Email"] = ""
        };
    }
}
