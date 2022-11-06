namespace Project
{
    /// <summary>
    /// Класс строителя запроса. Нужен для отложенного создания запроса
    /// </summary>
    public class RequestBuilder
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="request">Запрос, из которого нужно взять данные. Если пустой, то данные будут инициализированны по умолчанию</param>
        public RequestBuilder(Request? request)
        {
            if (request != null)
            {
                requestName = request.RequestName;
                TableName = request.TableName;
                Columns = new List<string>(request.Columns);
                RequestType = request.RequestType;
                SetQueryParameters(request.QueryParameters);
            }
        }

        /// <summary>
        /// Название запроса
        /// </summary>
        private string requestName = "";
        /// <summary>
        /// Секция WHERE
        /// </summary>
        private WhereParameter? whereParameter = null;
        /// <summary>
        /// Секция GROUP BY
        /// </summary>
        private GroupByParameter? groupByParameter = null;
        /// <summary>
        /// Секция JOIN
        /// </summary>
        private JoinParameter? joinParameter = null;
        /// <summary>
        /// Параметры запроса
        /// </summary>
        private Dictionary<string, string> queryParameters = new();

        public string RequestName { set => requestName = value; }
        public List<string> Columns { get; set; } = new();
        public WhereParameter WhereParameter { set => whereParameter = value; }
        public GroupByParameter GroupByParameter { set => groupByParameter = value; }
        public JoinParameter JoinParameter { set => joinParameter = value; }
        public RequestType RequestType { get; set; } = RequestType.Unknown;
        public string TableName { get; set; } = "";

        /// <summary>
        /// Получить значение по названию столбца
        /// </summary>
        /// <param name="columnName">Название столбца</param>
        /// <returns>Значение</returns>
        public string GetValueByColumnName(string columnName) => queryParameters.TryGetValue(columnName, out _) ? queryParameters[columnName] : "";

        /// <summary>
        /// Задать параметры запроса
        /// </summary>
        /// <param name="values">Параметры запроса</param>
        public void SetQueryParameters(List<string> values)
        {
            if (values.Count == 0)
                return;

            queryParameters.Clear();
            for (int i = 0; i < Columns.Count; i++)
                queryParameters.Add(Columns[i], values[i]);
        }

        /// <summary>
        /// Построить запрос
        /// </summary>
        /// <returns>Запрос</returns>
        public Request? BuildRequest()
        {
            Request? request = Request.GetRequest(RequestType);
            if (request == null)
                return null;

            request.RequestName = requestName;
            request.TableName = TableName;
            request.Columns = Columns;
            request.QueryParameters = queryParameters.Values.ToList();
            if (joinParameter != null)
                request.JoinParameter = joinParameter;
            if (whereParameter != null)
                request.WhereParameter = whereParameter;
            if (groupByParameter != null)
                request.GroupByParameter = groupByParameter;

            return request;
        }
    }
}
