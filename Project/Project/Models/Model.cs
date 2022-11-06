using Microsoft.Data.Sqlite;
using Project.DB;

namespace Project.Models
{
    public abstract class Model
    {
        public Model()
        {
            data = CreateData();
            parameters = CreateParameters();
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="reader">Объект-читатель данных из таблицы</param>
        protected Model(SqliteDataReader reader) : this() => InitFromDB(reader);

        /// <summary>
        /// Параметры запроса
        /// </summary>
        protected List<string> parameters = new();
        /// <summary>
        /// Данные
        /// </summary>
        protected Dictionary<string, object> data;

        /// <summary>
        /// Инициализировать из строки таблицы
        /// </summary>
        /// <param name="row">Строка таблицы</param>
        public abstract void InitFromGridRow(DataGridViewRow row);
        /// <summary>
        /// Получить названия столбцов
        /// </summary>
        /// <returns>Названия столбцов</returns>
        public abstract string[] GetColumnNames();
        /// <summary>
        /// Создать данные
        /// </summary>
        /// <returns>Данные</returns>
        protected abstract Dictionary<string, object> CreateData();

        /// <summary>
        /// Получить данные по переданным названиям таблиц
        /// </summary>
        /// <param name="columnsNames">Названия таблиц</param>
        /// <returns>Данные</returns>
        public string[] GetDataByColumnsNames(List<string> columnsNames)
        {
            string[] result = new string[columnsNames.Count];
            for (int i = 0; i < result.Length; i++)
            {
                var s = data[columnsNames[i]].ToString();
                if (s != null)
                    result[i] = s;
            }

            return result;
        }

        /// <summary>
        /// Получить параметры запрос в виде одной строки
        /// </summary>
        /// <returns>Запрос в виде одной строки</returns>
        public string GetParametersAsStringToInsert()
        {
            string s = parameters[0];
            for (int i = 1; i < parameters.Count; i++)
                s += ", " + parameters[i];

            return s;
        }

        /// <summary>
        /// Получить модель по названию таблицы
        /// </summary>
        /// <param name="tableName">Название таблицы</param>
        /// <returns>Модель</returns>
        public static Model? GetModel(string tableName)
        {
            return tableName switch
            {
                "albums" => new Album(),
                "artists" => new Artist(),
                "customers" => new Customer(),
                "employees" => new Employee(),
                "genres" => new Genre(),
                "invoice_items" => new InvoiceItem(),
                "invoices" => new Invoice(),
                "media_types" => new MediaType(),
                "playlists" => new Playlist(),
                "playlist_track" => new PlaylistTrack(),
                "tracks" => new Track(),
                _ => null,
            };
        }

        /// <summary>
        /// Инициализировать из БД
        /// </summary>
        /// <param name="reader">Объект-читатель базы данных</param>
        /// <param name="columns">Названия таблиц. Если не передан, то используются все столбцы</param>
        public virtual void InitFromDB(SqliteDataReader reader, List<string>? columns = null)
        {
            try
            {
                var list = columns == null || columns.Count == 0 ? GetColumnNames() : columns.ToArray();
                for (int i = 0; i < list.Length; i++)
                    data[list[i]] = reader.GetValue(i);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        /// <summary>
        /// Перевести модель в массив
        /// </summary>
        /// <returns>Массив данных в виде массива</returns>
        public virtual string[] ToArray()
        {
            string[] dataAsString = new string[data.Count];
            var it = data.GetEnumerator();
            int i = 0;
            while (it.MoveNext())
            {
                string? v = it.Current.Value.ToString();
                if (v == null)
                {
                    dataAsString[i] = "";
                    continue;
                }

                dataAsString[i] = v;
                i++;
            }

            return dataAsString;
        }

        /// <summary>
        /// Получить параметры для запроса
        /// </summary>
        /// <returns>Параметры для запроса</returns>
        public virtual SqliteParameter[] GetParameters()
        {
            SqliteParameter[] sp = new SqliteParameter[data.Count];
            var it = data.GetEnumerator();
            int i = 0;
            while (it.MoveNext())
            {
                sp[i] = new SqliteParameter(parameters[i], it.Current.Value);
                i++;
            }

            return sp;
        }

        /// <summary>
        /// Создать параметры модели
        /// </summary>
        /// <returns>Созданные параметры</returns>
        protected virtual List<string> CreateParameters()
        {
            var list = data.Keys.ToList();
            for (int i = 0; i < list.Count; i++)
                list[i] = "@" + list[i].ToLower();

            return list;
        }
    }
}
