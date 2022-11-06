using Microsoft.Data.Sqlite;

namespace Project.Models
{
    public class Genre : Model
    {
        public Genre() { }

        public Genre(SqliteDataReader reader) : base(reader) { }

        public override string[] GetColumnNames() => new string[] { "GenreId", "Name" };

        public override void InitFromGridRow(DataGridViewRow row)
        {
            if (row.Cells.Count != 2)
                return;

            if (int.TryParse((string)row.Cells[0].Value, out int value))
                data["GenreId"] = value;
            data["Name"] = (string)row.Cells[1].Value;
        }

        protected override Dictionary<string, object> CreateData() => new()
        {
            ["GenreId"] = 0,
            ["Name"] = ""
        };
    }
}
