using Project.Models;
using System.Collections;

namespace Project.DB
{
    // Класс-синглтон таблицы "tracks"
    public class TracksDBTable : DBTable
    {
        private static TracksDBTable? INSTANCE;
        public static DBTable Instance
        {
            get
            {
                INSTANCE ??= new TracksDBTable();
                return INSTANCE;
            }
        }

        private TracksDBTable() : base("tracks") { }

        public override string[] GetColumnsNames() => new string[] { "TrackId", "Name", "AlbumId", "MediaTypeId",
            "GenreId", "Composer", "Milliseconds", "Bytes", "UnitPrice" };

        protected override IList CreateListOfModel() => new List<Track>();
        protected override Model CreateModel() => new Track();
    }
}
