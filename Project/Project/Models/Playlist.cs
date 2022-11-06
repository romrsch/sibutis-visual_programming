using Microsoft.Data.Sqlite;

namespace Project.Models
{
    public class Playlist : Model
    {
        public Playlist() { }

        public Playlist(SqliteDataReader reader) : base(reader) { }

        public override string[] GetColumnNames() => new string[]
            {
                "PlaylistId", "Name"
            };

        public override void InitFromGridRow(DataGridViewRow row)
        {
            if (row.Cells.Count != 2)
                return;

            if (int.TryParse((string)row.Cells[0].Value, out int value))
                data["PlaylistId"] = value;
            data["Name"] = (string)row.Cells[1].Value;
        }

        protected override Dictionary<string, object> CreateData() => new()
        {
            ["PlaylistId"] = 0,
            ["Name"] = ""
        };
    }
}
