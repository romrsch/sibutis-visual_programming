using Microsoft.Data.Sqlite;

namespace Project.Models
{
    public class Track : Model
    {
        public Track() { }

        public Track(SqliteDataReader reader) : base(reader) { }

        public override string[] GetColumnNames() => new string[] { "TrackId", "Name", "AlbumId", "MediaTypeId",
            "GenreId", "Composer", "Milliseconds", "Bytes", "UnitPrice" };

        public override void InitFromGridRow(DataGridViewRow row)
        {
            if (row.Cells.Count != 8)
                return;

            if (int.TryParse((string)row.Cells[0].Value, out int value))
                data["TrackId"] = value;

            data["Name"] = (string)row.Cells[1].Value;

            if (int.TryParse((string)row.Cells[2].Value, out value))
                data["AlbumId"] = value;

            if (int.TryParse((string)row.Cells[3].Value, out value))
                data["MediaTypeId"] = value;

            if (int.TryParse((string)row.Cells[4].Value, out value))
                data["GenreId"] = value;

            data["Composer"] = (string)row.Cells[5].Value;


            if (int.TryParse((string)row.Cells[6].Value, out value))
                data["Milliseconds"] = value;

            if (int.TryParse((string)row.Cells[7].Value, out value))
                data["Bytes"] = value;

            if (decimal.TryParse((string)row.Cells[8].Value, out decimal d))
                data["UnitPrice"] = d;
        }

        protected override Dictionary<string, object> CreateData() => new()
        {
            ["TrackId"] = 0,
            ["Name"] = "",
            ["AlbumId"] = 0,
            ["MediaTypeId"] = 0,
            ["GenreId"] = 0,
            ["Composer"] = "",
            ["Milliseconds"] = 0,
            ["Bytes"] = 0,
            ["UnitPrice"] = 0.0m
        };
    }
}
