using System.Xml.Serialization;

namespace Project
{
    /// <summary>
    /// Класс-синглтон для работы с БД запросов
    /// </summary>
    internal class RequestDB
    {
        private static RequestDB? instance = null;
        /// <summary>
        /// Запросы
        /// </summary>
        public List<Request> requests = new();

        private RequestDB() { }

        public static RequestDB Instance
        {
            get
            {
                instance ??= new RequestDB();
                return instance;
            }
        }

        /// <summary>
        /// Получить запрос по его названию
        /// </summary>
        /// <param name="requestName"></param>
        /// <returns></returns>
        public Request? GetRequestByRequestName(string requestName) => requests.Find(request => request.RequestName == requestName);

        /// <summary>
        /// Сохранить запросы на диск
        /// </summary>
        public void Serialize()
        {
            XmlSerializer xmlSerializer = new(typeof(List<Request>));
            using FileStream fs = new("requests.xml", FileMode.OpenOrCreate);
            fs.SetLength(0);
            xmlSerializer.Serialize(fs, requests);
        }

        /// <summary>
        /// Загрузить запросы с диска
        /// </summary>
        public void Deserialize()
        {
            XmlSerializer xmlSerializer = new(typeof(List<Request>));
            using FileStream fs = new("requests.xml", FileMode.OpenOrCreate);
            try
            {
                object? obj = xmlSerializer.Deserialize(fs);
                if (obj != null)
                {
                    if (obj is List<Request> list)
                        requests = list;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
