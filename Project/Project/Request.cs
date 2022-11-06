using Microsoft.Data.Sqlite;
using System.Collections;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace Project
{
    /// <summary>
    /// Тип запроса
    /// </summary>
    [Serializable]
    public enum RequestType
    {
        Unknown = -1,
        SELECT,
        INSERT,
        UPDATE,
        DELETE,

        Count
    }

    /// <summary>
    /// Класс запроса
    /// </summary>
    [XmlInclude(typeof(SelectRequest))]
    [XmlInclude(typeof(InsertRequest))]
    [XmlInclude(typeof(UpdateRequest))]
    [XmlInclude(typeof(DeleteRequest))]
    [Serializable]
    public abstract class Request : Token
    {
        /// <summary>
        /// Получить новый запрос по типу запроса
        /// </summary>
        /// <param name="requestType">Тип запроса</param>
        /// <returns>Новый запрос</returns>
        public static Request? GetRequest(RequestType requestType) => requestType switch
        {
            RequestType.SELECT => new SelectRequest(),
            RequestType.INSERT => new InsertRequest(),
            RequestType.UPDATE => new UpdateRequest(),
            RequestType.DELETE => new DeleteRequest(),
            _ => null
        };

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="requestType">Тип запроса</param>
        protected Request(RequestType requestType) => this.requestType = requestType;

        /// <summary>
        /// Получить SQL-запрос, готовый для выполнения
        /// </summary>
        /// <returns>SQL-запрос, готовый для выполнения</returns>
        public virtual SqliteCommand GetSqliteCommand()
        {
            SqliteCommand cmd = new()
            {
                CommandText = CreateRequestLine()
            };
            cmd.CommandText += GetJoinSection();
            cmd.CommandText += GetWhereSection();
            cmd.CommandText += GetGroupBySection();
            FillParameters(ref cmd);

            return cmd;
        }

        /// <summary>
        /// Сделать запрос строкой
        /// </summary>
        /// <returns>Запрос строкой</returns>
        public override string TurnToString()
        {
            var command = GetSqliteCommand();
            return $"({command.CommandText})";
        }

        /// <summary>
        /// Получить секцию JOIN
        /// </summary>
        /// <returns>Секция JOIN</returns>
        protected virtual string GetJoinSection() => joinParameter == null ? string.Empty : $" {joinParameter.ToString()}";
        /// <summary>
        /// Получить секцию WHERE
        /// </summary>
        /// <returns>Секция WHERE</returns>
        protected virtual string GetWhereSection() => whereParameter == null ? string.Empty : $" {whereParameter.ToString()}";
        /// <summary>
        /// Получить секцию GROUP BY
        /// </summary>
        /// <returns>Секция GROUP BY</returns>
        protected virtual string GetGroupBySection() => groupByParameter == null ? string.Empty : $" {groupByParameter.ToString()}";

        /// <summary>
        /// Выполнить запрос
        /// </summary>
        /// <param name="connection">Подключение к БД</param>
        /// <returns>Результат</returns>
        public abstract IList? Execute(SqliteConnection connection);
        /// <summary>
        /// Создать строку запроса
        /// </summary>
        /// <returns>Строка запроса</returns>
        protected abstract string CreateRequestLine();
        /// <summary>
        /// Заполнить SQL-команду параметрами
        /// </summary>
        /// <param name="command">SQL-команда</param>
        protected abstract void FillParameters(ref SqliteCommand command);

        /// <summary>
        /// Название запроса
        /// </summary>
        private string requestName = "";
        /// <summary>
        /// Тип запроса
        /// </summary>
        private RequestType requestType = RequestType.Unknown;
        /// <summary>
        /// Задействованные колонки
        /// </summary>
        protected List<string> columns = new();
        /// <summary>
        /// Параметры запроса
        /// </summary>
        protected List<string> queryParameters = new();
        /// <summary>
        /// Название основной таблицы
        /// </summary>
        protected string tableName = "";
        /// <summary>
        /// Секция WHERE
        /// </summary>
        protected WhereParameter? whereParameter = null;
        /// <summary>
        /// Секция GROUP BY
        /// </summary>
        protected GroupByParameter? groupByParameter = null;
        /// <summary>
        /// Секция JOIN
        /// </summary>
        protected JoinParameter? joinParameter = null;

        public string RequestName { get => requestName; set => requestName = value; }
        public RequestType RequestType => requestType;
        public List<string> Columns { get => columns; set => columns = value; }
        public List<string> QueryParameters { get => queryParameters; set => queryParameters = value; }
        public int ColumnsCount => columns.Count;
        public string TableName { get => tableName; set => tableName = value; }
        public WhereParameter? WhereParameter { get => whereParameter; set => whereParameter = value; }
        public GroupByParameter? GroupByParameter { get => groupByParameter; set => groupByParameter = value; }
        public JoinParameter? JoinParameter { get => joinParameter; set => joinParameter = value; }
    }

    /// <summary>
    /// SELECT-запрос
    /// </summary>
    [Serializable]
    public class SelectRequest : Request
    {
        public SelectRequest() : base(RequestType.SELECT)
        { }

        public override IList Execute(SqliteConnection connection)
        {
            var list = new List<List<string>>();
            var command = GetSqliteCommand();
            command.Connection = connection;

            try
            {
                using var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var l = new List<string>();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            var value = reader.GetValue(i).ToString();
                            l.Add(value ?? "");
                        }

                        list.Add(l);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return list;
        }

        protected override string CreateRequestLine()
        {
            string columnsString = "";

            for (int i = 0; i < columns.Count; i++)
            {
                columnsString += $"{tableName}.{columns[i]}, ";
            }
            columnsString = columnsString.Remove(columnsString.Length - 2, 2);

            if (joinParameter == null)
                return $"SELECT {columnsString} FROM {tableName}";
            else
            {
                string otherTable = "";
                for (int i = 0; i < joinParameter.Table2Name.Count; i++)
                    otherTable += $"{joinParameter.Table2Name[i]}.{joinParameter.Table2Column[i]}, ";
                otherTable = otherTable.Remove(otherTable.Length - 2, 2);

                return $"SELECT {columnsString}, {otherTable} FROM {tableName}";
            }
        }

        protected override void FillParameters(ref SqliteCommand command)
        { }
    }

    /// <summary>
    /// INSERT-запрос
    /// </summary>
    [Serializable]
    public class InsertRequest : Request
    {
        public InsertRequest() : base(RequestType.INSERT) { }

        public override IList? Execute(SqliteConnection connection)
        {
            var command = GetSqliteCommand();
            command.Connection = connection;
            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Запись успешно вставлена");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return null;
        }

        protected override string CreateRequestLine()
        {
            string columnsString = "";

            Regex regex = new(@"[a-z]?Id");
            int start = regex.Matches(columns[0]).Count > 0 ? 1 : 0;
            for (int column = start; column < columns.Count; column++)
                columnsString += columns[column] + ", ";
            columnsString = columnsString.Remove(columnsString.Length - 2, 2);

            string parametersString = "";
            for (int i = start; i < Columns.Count; i++)
                parametersString += $"@{i}, ";
            parametersString = parametersString.Remove(parametersString.Length - 2, 2);

            return $"INSERT INTO {tableName} ({columnsString}) VALUES ({parametersString})";
        }

        protected override void FillParameters(ref SqliteCommand command)
        {
            for (int i = 0; i < queryParameters.Count; i++)
            {
                var p = new SqliteParameter($"@{i}", queryParameters[i]);
                command.Parameters.Add(p);
            }
        }

        protected override string GetWhereSection() => "";
        protected override string GetJoinSection() => "";
        protected override string GetGroupBySection() => "";
    }

    /// <summary>
    /// UPDATE-запрос
    /// </summary>
    [Serializable]
    public class UpdateRequest : Request
    {
        public UpdateRequest() : base(RequestType.UPDATE) { }

        public override IList? Execute(SqliteConnection connection)
        {
            var command = GetSqliteCommand();
            command.Connection = connection;
            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Запись успешно обновлена");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return null;
        }

        protected override string CreateRequestLine()
        {
            string s = "";
            for (int i = 0; i < Columns.Count; i++)
                s += $"{Columns[i]}=@{i}, ";
            s = s.Remove(s.Length - 2, 2);

            return $"UPDATE {tableName} SET {s}";
        }

        protected override void FillParameters(ref SqliteCommand command)
        {
            for (int i = 0; i < queryParameters.Count; i++)
            {
                var p = new SqliteParameter($"@{i}", queryParameters[i]);
                command.Parameters.Add(p);
            }
        }
    }

    /// <summary>
    /// DELETE-запрос
    /// </summary>
    [Serializable]
    public class DeleteRequest : Request
    {
        public DeleteRequest() : base(RequestType.DELETE) { }

        public override IList? Execute(SqliteConnection connection)
        {
            var command = GetSqliteCommand();
            command.Connection = connection;
            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Запись успешно удалена");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return null;
        }

        protected override string CreateRequestLine() => $"DELETE FROM {tableName}";

        protected override void FillParameters(ref SqliteCommand command)
        {
            for (int i = 0; i < queryParameters.Count; i++)
            {
                var p = new SqliteParameter($"@{i}", queryParameters[i]);
                command.Parameters.Add(p);
            }
        }
    }
}
