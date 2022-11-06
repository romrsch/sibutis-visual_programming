using Microsoft.Data.Sqlite;

namespace Project.Models
{
    public class Album : Model
    {
        public Album() { }

        public Album(SqliteDataReader reader) : base(reader) { }

        public override string[] GetColumnNames() => new string[] { "AlbumId", "Title", "ArtistId" };

        public override void InitFromGridRow(DataGridViewRow row)
        {
            if (row.Cells.Count != 3)
                return;

            if (int.TryParse((string)row.Cells[0].Value, out int value))
                data["AlbumId"] = value;

            data["Title"] = (string)row.Cells[1].Value;

            if (int.TryParse((string)row.Cells[2].Value, out value))
                data["ArtistId"] = value;
        }

        protected override Dictionary<string, object> CreateData() => new()
        {
            ["AlbumId"] = 0,
            ["Title"] = "",
            ["ArtistId"] = 0,
        };
    }
}
