using Project.Models;
using System.Collections;

namespace Project.DB
{
    // Класс-синглтон таблицы "playlists"
    public class PlaylistsDBTable : DBTable
    {
        private static PlaylistsDBTable? INSTANCE;
        public static DBTable Instance
        {
            get
            {
                INSTANCE ??= new PlaylistsDBTable();
                return INSTANCE;
            }
        }

        private PlaylistsDBTable() : base("playlists") { }

        public override string[] GetColumnsNames() => new string[] { "PlaylistId", "Name" };
        protected override IList CreateListOfModel() => new List<Playlist>();
        protected override Model CreateModel() => new Playlist();
    }
}
