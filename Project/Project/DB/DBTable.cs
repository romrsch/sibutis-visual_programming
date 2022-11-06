using Microsoft.Data.Sqlite;
using Project.Models;
using System.Collections;

namespace Project.DB
{
    public abstract class DBTable
    {
        /// <summary>
        /// Строка подключения
        /// </summary>
        private const string connectionString = "Data Source=chinook.db";
        /// <summary>
        /// Название таблицы
        /// </summary>
        private string tableName = "";

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="tableName">Название таблицы</param>
        protected DBTable(string tableName) => this.tableName = tableName;

        /// <summary>
        /// Произвести запрос Select
        /// </summary>
        /// <param name="what">Что именно запрашивать. По умолчанию - всё</param>
        /// <returns>Список полученных данных</returns>
        public IList Select(string what = "*")
        {
            var list = CreateListOfModel();
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = $"SELECT {what} FROM {tableName}";
                try
                {
                    using var reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Model employee = CreateModel();
                            employee.InitFromDB(reader);
                            list.Add(employee);
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }

                connection.Close();
            }

            return list;
        }

        /// <summary>
        /// Произвести запрос Insert
        /// </summary>
        /// <param name="record">Модель данных, откуда брать данные</param>
        public void Insert(Model record)
        {
            using var connection = new SqliteConnection(connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = $"INSERT INTO {tableName} VALUES ({record.GetParametersAsStringToInsert()})";
            command.Parameters.AddRange(record.GetParameters());
            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Добавление произведено успешно");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            connection.Close();
        }

        /// <summary>
        /// Произвести запрос Update
        /// </summary>
        /// <param name="record">Модель данных, откуда брать данные</param>
        public void Update(Model record)
        {
            using var connection = new SqliteConnection(connectionString);
            var parameters = record.GetParametersAsStringToInsert().Split(", ");
            var columnsNames = record.GetColumnNames();
            string setSection = "";
            for (int i = 1; i < columnsNames.Length; i++)
                setSection += $"{columnsNames[i]} = {parameters[i]}, ";
            setSection = setSection.Remove(setSection.Length - 2, 2);

            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = $"UPDATE {tableName} SET {setSection} WHERE {columnsNames[0]} = {parameters[0]}";
            command.Parameters.AddRange(record.GetParameters());
            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Таблица успешно обновлена");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            connection.Close();
        }

        /// <summary>
        /// Произвести запрос Delete
        /// </summary>
        /// <param name="record">Модель данных, откуда брать данные</param>
        public void Delete(Model record)
        {
            using var connection = new SqliteConnection(connectionString);
            var parameters = record.GetParametersAsStringToInsert().Split(", ");
            var columnsNames = record.GetColumnNames();
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = $"DELETE FROM {tableName} WHERE {columnsNames[0]} = {parameters[0]}";
            command.Parameters.AddRange(record.GetParameters());
            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Запись успешно удалена");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            connection.Close();
        }

        /// <summary>
        /// Вернуть названия столбцов
        /// </summary>
        /// <returns>Массив с названиями столбцов</returns>
        public abstract string[] GetColumnsNames();
        /// <summary>
        /// Создать список с моделью, присущей данной таблице
        /// </summary>
        /// <returns></returns>
        protected abstract IList CreateListOfModel();
        /// <summary>
        /// Создать модель для данной таблицы
        /// </summary>
        /// <returns>Объект модели</returns>
        protected abstract Model CreateModel();
    }
}
