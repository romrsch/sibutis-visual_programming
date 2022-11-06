using Project.Models;
using System.Collections;

namespace Project.DB
{
    // Класс-синглтон таблицы "playlist_track"
    public class PlaylistTrackDBTable : DBTable
    {
        private static PlaylistTrackDBTable? INSTANCE;
        public static DBTable Instance
        {
            get
            {
                INSTANCE ??= new PlaylistTrackDBTable();
                return INSTANCE;
            }
        }

        private PlaylistTrackDBTable() : base("playlist_track") { }

        public override string[] GetColumnsNames() => new string[] { "PlaylistId", "TrackId" };
        protected override IList CreateListOfModel() => new List<PlaylistTrack>();
        protected override Model CreateModel() => new PlaylistTrack();
    }
}
