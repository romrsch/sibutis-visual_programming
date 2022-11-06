using Microsoft.Data.Sqlite;

namespace Project.Models
{
    public class MediaType : Model
    {
        public MediaType() { }

        public MediaType(SqliteDataReader reader) : base(reader) { }

        public override string[] GetColumnNames() => new string[] { "MediaTypeId", "Name" };

        public override void InitFromGridRow(DataGridViewRow row)
        {
            if (row.Cells.Count != 2)
                return;

            if (int.TryParse((string)row.Cells[0].Value, out int value))
                data["MediaTypeId"] = value;
            data["Name"] = (string)row.Cells[1].Value;
        }

        protected override Dictionary<string, object> CreateData() => new()
        {
            ["MediaTypeId"] = 0,
            ["Name"] = ""
        };
    }
}
