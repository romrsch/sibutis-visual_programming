using Microsoft.Data.Sqlite;

namespace Project.Models
{
    public class PlaylistTrack : Model
    {
        public PlaylistTrack() { }

        public PlaylistTrack(SqliteDataReader reader) : base(reader) { }

        public override string[] GetColumnNames() => new string[]
            {
                "PlaylistId", "TrackId"
            };

        public override void InitFromGridRow(DataGridViewRow row)
        {
            if (row.Cells.Count != 2)
                return;

            if (int.TryParse((string)row.Cells[0].Value, out int value))
                data["PlaylistId"] = value;

            if (int.TryParse((string)row.Cells[1].Value, out value))
                data["TrackId"] = value;
        }

        protected override Dictionary<string, object> CreateData() => new()
        {
            ["PlaylistId"] = 0,
            ["TrackId"] = 0
        };
    }
}
