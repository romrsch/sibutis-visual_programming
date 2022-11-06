using Microsoft.Data.Sqlite;

namespace Project.Models
{
    public class Artist : Model
    {
        public Artist() { }

        public Artist(SqliteDataReader reader) : base(reader) { }

        public override string[] GetColumnNames() => new string[] { "ArtistId", "Name" };

        public override void InitFromGridRow(DataGridViewRow row)
        {
            if (row.Cells.Count != 2)
                return;

            if (int.TryParse((string)row.Cells[0].Value, out int value))
                data["ArtistId"] = value;
            data["Name"] = (string)row.Cells[1].Value;
        }

        protected override Dictionary<string, object> CreateData() => new()
        {
            ["ArtistId"] = 0,
            ["Name"] = ""
        };
    }
}
