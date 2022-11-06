using Project.Models;
using System.Collections;

namespace Project.DB
{
    // Класс-синглтон таблицы "albums"
    public class AlbumsDBTable : DBTable
    {
        private static AlbumsDBTable? INSTANCE;
        public static DBTable Instance
        {
            get
            {
                INSTANCE ??= new AlbumsDBTable();
                return INSTANCE;
            }
        }

        private AlbumsDBTable() : base("albums") { }

        public override string[] GetColumnsNames() => new string[] { "AlbumId", "Title", "ArtistId" };
        protected override IList CreateListOfModel() => new List<Album>();
        protected override Model CreateModel() => new Album();
    }
}
