using Microsoft.Data.Sqlite;
using System.Collections;

namespace Project.DB
{
    internal class DB
    {
        /// <summary>
        /// Строка подключения
        /// </summary>
        private static readonly string connectionString = "Data Source=chinook.db";

        /// <summary>
        /// Получить таблицу по её названию
        /// </summary>
        /// <param name="tableName">Название таблицы</param>
        /// <returns>Таблица</returns>
        public static DBTable? GetTableByTableName(string tableName) => tableName switch
        {
            "albums" => AlbumsDBTable.Instance,
            "artists" => ArtistsDBTable.Instance,
            "customers" => CustomersDBTable.Instance,
            "employees" => EmployeesDBTable.Instance,
            "genres" => GenresDBTable.Instance,
            "invoice_items" => InvoiceItemsDBTable.Instance,
            "invoices" => InvoicesDBTable.Instance,
            "media_types" => MediaTypesDBTable.Instance,
            "playlists" => PlaylistsDBTable.Instance,
            "playlist_track" => PlaylistTrackDBTable.Instance,
            "tracks" => TracksDBTable.Instance,
            _ => null,
        };

        /// <summary>
        /// Выполнить запрос и получить ответ
        /// </summary>
        /// <param name="request">Запрос, который необходимо выполнить</param>
        /// <returns>Ответ</returns>
        public static IList? Execute(Request request)
        {
            using var connection = new SqliteConnection(connectionString);
            connection.Open();
            var result = request.Execute(connection);

            return result;
        }

        /// <summary>
        /// Получить названия таблиц
        /// </summary>
        /// <returns>Названия таблиц</returns>
        public static string[] GetTablesNames() => new string[]
            {
                "employees", "customers", "invoices", "invoice_items", "artists", "albums", "media_types", "genres",
                "tracks", "playlists", "playlist_track"
            };
    }
}
