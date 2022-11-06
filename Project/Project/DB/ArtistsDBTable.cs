using Project.Models;
using System.Collections;

namespace Project.DB
{
    // Класс-синглтон таблицы "artists"
    public class ArtistsDBTable : DBTable
    {
        private static ArtistsDBTable? INSTANCE;
        public static DBTable Instance
        {
            get
            {
                INSTANCE ??= new ArtistsDBTable();
                return INSTANCE;
            }
        }

        private ArtistsDBTable() : base("artists") { }

        public override string[] GetColumnsNames() => new string[] { "ArtistId", "Name" };
        protected override IList CreateListOfModel() => new List<Artist>();
        protected override Model CreateModel() => new Artist();
    }
}
