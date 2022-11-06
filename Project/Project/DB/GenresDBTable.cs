using Project.Models;
using System.Collections;

namespace Project.DB
{
    // Класс-синглтон таблицы "genres"
    public class GenresDBTable : DBTable
    {
        private static GenresDBTable? INSTANCE;
        public static DBTable Instance
        {
            get
            {
                INSTANCE ??= new GenresDBTable();
                return INSTANCE;
            }
        }

        private GenresDBTable() : base("genres") { }

        public override string[] GetColumnsNames() => new string[] { "GenreId", "Name" };
        protected override IList CreateListOfModel() => new List<Genre>();
        protected override Model CreateModel() => new Genre();
    }
}
