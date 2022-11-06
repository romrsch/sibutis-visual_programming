using Project.Models;
using System.Collections;

namespace Project.DB
{
    // Класс-синглтон таблицы "media_types"
    public class MediaTypesDBTable : DBTable
    {
        private static MediaTypesDBTable? INSTANCE;
        public static DBTable Instance
        {
            get
            {
                INSTANCE ??= new MediaTypesDBTable();
                return INSTANCE;
            }
        }

        private MediaTypesDBTable() : base("media_types") { }

        public override string[] GetColumnsNames() => new string[] { "MediaTypeId", "Name" };
        protected override IList CreateListOfModel() => new List<MediaType>();
        protected override Model CreateModel() => new MediaType();
    }
}
