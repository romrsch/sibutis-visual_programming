using System.Xml.Serialization;

namespace Project
{
    /// <summary>
    /// Секция WHERE
    /// </summary>
    [Serializable]
    public class WhereParameter
    {
        public WhereParameter() { }
        /// <summary>
        /// Список токенов
        /// </summary>
        public List<Token> Tokens { get; set; } = new();

        /// <summary>
        /// Получить секцию в виде строки
        /// </summary>
        /// <returns>Секция в виде строки</returns>
        public override string ToString()
        {
            string s = "WHERE (";
            foreach (Token token in Tokens)
                s += token.TurnToString() + " ";

            s = s.Remove(s.Length - 1, 1) + ")";

            return s;
        }

        /// <summary>
        /// Добавить токен
        /// </summary>
        /// <param name="token">Токен, который нужно добавить</param>
        public void AddToken(Token token) => Tokens.Add(token);
        /// <summary>
        /// Операторы, используемые в секции
        /// </summary>
        public static string[] WhereOperators => new[] { "=", "<", ">", ">=", "<=", "<>", "BETWEEN", "LIKE", "IN" };
    }

    /// <summary>
    /// Токен для использования в секции WHERE
    /// </summary>
    [XmlInclude(typeof(BooleanExpression))]
    [XmlInclude(typeof(BetweenBooleanExpression))]
    [XmlInclude(typeof(Bundle))]
    [Serializable]
    public abstract class Token
    {
        /// <summary>
        /// Преобразовать токен в строку
        /// </summary>
        /// <returns></returns>
        public abstract string TurnToString();
    }
    
    /// <summary>
    /// Токен-логическое выражение
    /// </summary>
    [Serializable]
    public class BooleanExpression : Token
    {
        /// <summary>
        /// Получить выражение в зависимости от операции
        /// </summary>
        /// <param name="oper"></param>
        /// <returns></returns>
        public static BooleanExpression GetExpression(string oper)
        {
            if (oper == "BETWEEN")
                return new BetweenBooleanExpression();

            return new BooleanExpression();
        }

        public BooleanExpression() { }

        /// <summary>
        /// Левый операнд
        /// </summary>
        public string LeftOperand { get; set; } = "";
        /// <summary>
        /// Оператор
        /// </summary>
        public string Operator { get; set; } = "";
        /// <summary>
        /// Правый оператор
        /// </summary>
        public virtual string RightOperand { get; set; } = "";

        public override string TurnToString()
        {
            string s = $"{LeftOperand} {Operator} ";
            if (RightOperand.Length != 0)
                s += $"'{RightOperand}'";

            return s;
        }
    }

    /// <summary>
    /// Токен BETWEEN
    /// </summary>
    [Serializable]
    public class BetweenBooleanExpression : BooleanExpression
    {
        public override string RightOperand
        {
            get => base.RightOperand;
            set
            {
                string[] split = value.Split("|");
                if (split.Length == 1)
                {
                    base.RightOperand = value;
                    return;
                }
                Operator = LeftOperand;
                LeftOperand = split[0];
                base.RightOperand = split[1];
            }
        }

        public override string TurnToString() => $"{Operator} BETWEEN {LeftOperand} AND {RightOperand}";
    }

    /// <summary>
    /// Тип связки
    /// </summary>
    [Serializable]
    public enum BundleType
    {
        AND,
        OR,
        Count
    }

    /// <summary>
    /// Токен связки
    /// </summary>
    [Serializable]
    public class Bundle : Token
    {
        public Bundle() { }
        public BundleType Type { get; set; } = BundleType.OR;
        public override string TurnToString() => Type.ToString();
    }

    /// <summary>
    /// Тип запроса JOIN
    /// </summary>
    [Serializable]
    public enum JoinType
    {
        Unknown = -1,
        INNER,
        CROSS,
        LEFT,
        RIGHT,
        FULL_OUTER,
        COUNT
    }

    /// <summary>
    /// Секция JOIN
    /// </summary>
    [Serializable]
    public class JoinParameter
    {
        /// <summary>
        /// Название первой таблицы
        /// </summary>
        public string Table1Name { get; set; } = "";
        /// <summary>
        /// Название колонки первой таблицы
        /// </summary>
        public List<string> Table1Column { get; set; } = new List<string>();

        /// <summary>
        /// Название второй таблицы
        /// </summary>
        public List<string> Table2Name { get; set; } = new List<string>();
        /// <summary>
        /// Название колонки второй таблицы
        /// </summary>
        public List<string> Table2Column { get; set; } = new List<string>();

        /// <summary>
        /// Список токенов
        /// </summary>
        public List<JoinType> JoinType { get; set; } = new List<JoinType>();

        /// <summary>
        /// Получить секцию в виде строки
        /// </summary>
        /// <returns>Секция в виде строки</returns>
        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < Table1Column.Count; i++)
                s += $"{JoinType[i].ToString().Replace("_", " ")} JOIN {Table2Name[i]} ON {Table1Name}.{Table1Column[i]}={Table2Name[i]}.{Table2Column[i]} ";

            return s;
        }
    }

    /// <summary>
    /// Секция GROUP BY
    /// </summary>
    [Serializable]
    public class GroupByParameter
    {
        /// <summary>
        /// Название колонки
        /// </summary>
        public string ColumnName { get; set; } = "";
        /// <summary>
        /// Получить секцию в виде строки
        /// </summary>
        /// <returns>Секция в виде строки</returns>
        public override string ToString() => $"GROUP BY {ColumnName}";
    }
}
