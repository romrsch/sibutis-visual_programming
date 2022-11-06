namespace Project
{
    public partial class AddNewRequestForm : Form
    {
        /// <summary>
        /// Перечисление страниц
        /// </summary>
        private enum Tabs
        {
            RequestName,
            RequestTypeAndTable,
            Columns,
            VALUESSection,
            JOINSection,
            WHERESection,
            GROUPBYSection,

            LastSection = GROUPBYSection,
            Count
        }

        /// <summary>
        /// Таблица значений
        /// </summary>
        private TableLayoutPanel? valuesTable;
        /// <summary>
        /// Строитель запроса
        /// </summary>
        private RequestBuilder? builder = null;
        /// <summary>
        /// Изначальный запрос
        /// </summary>
        private Request? originRequest = null;

        /// <summary>
        /// Список задействованных страниц
        /// </summary>
        private List<Tabs> idxs = new()
        {
            Tabs.RequestName,
            Tabs.RequestTypeAndTable,
            Tabs.Columns,
            Tabs.JOINSection,
            Tabs.WHERESection,
            Tabs.GROUPBYSection
        };

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="request">Запрос, из которого берутся данные</param>
        public AddNewRequestForm(Request? request = null)
        {
            InitializeComponent();
            originRequest = request;
        }

        private void ForwardButton_Click(object sender, EventArgs e)
        {
            if (builder == null)
                return;

            int selectedIndex = tabControl.SelectedIndex++;
            if (idxs[selectedIndex] == Tabs.RequestName)
            {
                if (requestNameTextBox.Text.Length == 0)
                {
                    MessageBox.Show("Введите имя запроса");
                    tabControl.SelectedIndex--;
                    return;
                }
                builder.RequestName = requestNameTextBox.Text;
                backButton.Show();
                return;
            }

            if (idxs[selectedIndex] == Tabs.RequestTypeAndTable)
            {
                var selectedType = typesOfRequestsListBox.CheckedIndices;
                if (selectedType == null || selectedType.Count == 0)
                {
                    MessageBox.Show("Выберите тип запроса");
                    tabControl.SelectedIndex--;
                    return;
                }

                builder.RequestType = (RequestType)selectedType[0];

                var selectedTable = tablesNamesListBox.CheckedItems;
                if (selectedTable == null || selectedTable.Count == 0)
                {
                    MessageBox.Show("Выберите таблицу");
                    tabControl.SelectedIndex--;
                    return;
                }

                builder.TableName = (string)selectedTable[0];
                if (columnsListBox.CheckedItems.Count == 0)
                {
                    columnsListBox.Items.Clear();
                    var table = DB.DB.GetTableByTableName(builder.TableName);
                    if (table != null)
                    {
                        var tableColumns = table.GetColumnsNames();
                        foreach (var col in tableColumns)
                            columnsListBox.Items.Add(col);
                    }
                }

                if (builder.RequestType == RequestType.DELETE)
                    tabControl.SelectedIndex += 2;

                return;
            }

            if (idxs[selectedIndex] == Tabs.Columns)
            {
                if (columnsListBox.CheckedItems.Count == 0)
                {
                    MessageBox.Show("Выберите столбец(столбцы)");
                    tabControl.SelectedIndex--;
                    return;
                }

                List<string> columns = new();
                if (allAreUsedCheckBox.Checked)
                {
                    for (int i = 0; i < columnsListBox.Items.Count; i++)
                    {
                        var s = columnsListBox.Items[i].ToString();
                        columns.Add(s ?? "");
                    }
                }
                else
                {
                    var selectedColumns = columnsListBox.CheckedItems;
                    if (selectedColumns.Count != 0)
                    {
                        var it = selectedColumns.GetEnumerator();
                        while (it.MoveNext())
                            columns.Add((string)it.Current);
                    }
                }

                builder.Columns = columns;

                if (builder.RequestType == RequestType.INSERT
                 || builder.RequestType == RequestType.UPDATE)
                {
                    if (idxs.Count != (int)Tabs.Count)
                    {
                        CreateValuesTabPage();
                        tabControl.SelectedIndex--;
                    }

                    if (valuesTable == null)
                        return;

                    for (int i = 2; i <= valuesTable.RowCount; i++)
                    {
                        var control = valuesTable.GetControlFromPosition(0, i);
                        valuesTable.Controls.Remove(control);
                        control = valuesTable.GetControlFromPosition(1, i);
                        valuesTable.Controls.Remove(control);
                    }
                    valuesTable.RowCount = 1;

                    for (int i = 0; i < columns.Count; i++)
                    {
                        int idx = ++valuesTable.RowCount;

                        Label label = new() { Text = columns[i] };
                        valuesTable.Controls.Add(label, 0, idx);
                        TextBox textBox = new() { Text = builder.GetValueByColumnName(columns[i]) };
                        valuesTable.Controls.Add(textBox, 1, idx);
                    }
                }

                return;
            }

            if (idxs[selectedIndex] == Tabs.JOINSection)
            {
                if (useJoinCheckBox.Checked)
                {
                    JoinParameter joinParameter = new();
                    string? v = tablesNamesListBox.CheckedItems[0].ToString();
                    if (v == null)
                        return;
                    joinParameter.Table1Name = v;

                    for (int i = 1; i <= joinTableLayout.RowCount; i++)
                    {
                        if (joinTableLayout.GetControlFromPosition(0, i) is not ComboBox table2NameCombobox)
                            continue;

                        if (table2NameCombobox.Text.Length == 0)
                        {
                            MessageBox.Show("Одно из полей ввода таблицы 2 не задано");
                            tabControl.SelectedIndex--;
                            return;
                        }
                        joinParameter.Table2Name.Add(table2NameCombobox.Text);

                        if (joinTableLayout.GetControlFromPosition(1, i) is not ComboBox table1Column)
                            continue;

                        if (table1Column.Text.Length == 0)
                        {
                            MessageBox.Show("Одно и полей ввода столбца таблицы 1 не задано");
                            tabControl.SelectedIndex--;
                            return;
                        }
                        joinParameter.Table1Column.Add(table1Column.Text);

                        if (joinTableLayout.GetControlFromPosition(2, i) is not ComboBox table2Column)
                            continue;

                        if (table2Column.Text.Length == 0)
                        {
                            MessageBox.Show("Одно и полей ввода столбца таблицы 2 не задано");
                            tabControl.SelectedIndex--;
                            return;
                        }
                        joinParameter.Table2Column.Add(table2Column.Text);

                        if (joinTableLayout.GetControlFromPosition(3, i) is not CheckedListBox joinMethodListBox)
                            continue;

                        joinParameter.JoinType.Add((JoinType)joinMethodListBox.SelectedIndex);
                    }

                    builder.JoinParameter = joinParameter;
                }
                return;
            }

            if (idxs[selectedIndex] == Tabs.VALUESSection)
            {
                if (valuesTable == null)
                    return;

                List<string> values = new();
                for (int row = 1; row < valuesTable.RowCount + 2; row++)
                {
                    var c = valuesTable.GetControlFromPosition(1, row);
                    if (c != null)
                        values.Add(c.Text);
                }
                builder.SetQueryParameters(values);

                if (builder.RequestType != RequestType.SELECT)
                    tabControl.SelectedIndex++;

                return;
            }

            if (idxs[selectedIndex] == Tabs.WHERESection)
            {
                if (useWhereCheckBox.Checked)
                {
                    WhereParameter whereParameter = new();
                    for (int i = 1, j = i, I = 3; i < whereTable.RowCount; i++, j = (j + 1) % 2)
                    {
                        if (j == 0)
                        {
                            Bundle bundle = new();
                            if (whereTable.Controls[I] is not ComboBox c)
                                return;
                            bundle.Type = (BundleType)c.SelectedIndex;
                            whereParameter.AddToken(bundle);
                            I++;
                        }
                        else
                        {
                            string oper = whereTable.Controls[I + 1].Text;
                            BooleanExpression booleanExpression = BooleanExpression.GetExpression(oper);
                            booleanExpression.LeftOperand = whereTable.Controls[I].Text;
                            if (booleanExpression.LeftOperand.Length == 0)
                            {
                                MessageBox.Show("Не выбран столбец, по которому должно выполняться условие");
                                return;
                            }

                            booleanExpression.Operator = oper;
                            whereParameter.AddToken(booleanExpression);

                            string rightOperand = whereTable.Controls[I + 2].Text;
                            if (oper == "BETWEEN")
                            {
                                string[] s = rightOperand.Split("|");
                                if (s.Length != 2)
                                {
                                    MessageBox.Show("Разделитель между значениями - |");
                                    return;
                                }
                                var subrequest1 = RequestDB.Instance.GetRequestByRequestName(s[0]);
                                var subrequest2 = RequestDB.Instance.GetRequestByRequestName(s[1]);

                                string finalS = $"{(subrequest1 == null ? s[0] : subrequest1.TurnToString())}|{(subrequest2 == null ? s[1] : subrequest2.TurnToString())}";

                                booleanExpression.RightOperand = finalS;
                            }
                            else
                            {
                                if (rightOperand[0] == '(' || rightOperand[0] == '(')
                                    rightOperand = rightOperand[1..^2];

                                Request? subrequest = RequestDB.Instance.GetRequestByRequestName(rightOperand);
                                if (subrequest == null)
                                {
                                    if (oper == "LIKE")
                                        booleanExpression.RightOperand = "'" + rightOperand + "'";
                                    else if (oper == "IN")
                                        booleanExpression.RightOperand = "(" + rightOperand + ")";
                                    else
                                        booleanExpression.RightOperand = rightOperand;
                                }
                                else
                                    whereParameter.AddToken(subrequest);
                            }
                            I += 3;
                        }
                    }

                    builder.WhereParameter = whereParameter;
                }
                return;
            }

            if (idxs[selectedIndex] == Tabs.GROUPBYSection)
            {
                if (useGroupByCheckBox.Checked)
                    builder.GroupByParameter = new() { ColumnName = grouppingColumnsComboBox.Text };
            }

            if (idxs[selectedIndex] == Tabs.LastSection)
            {
                var requestDB = RequestDB.Instance;
                var request = builder.BuildRequest();
                if (request != null)
                {
                    if (originRequest != null)
                        requestDB.requests.Remove(originRequest);
                    requestDB.requests.Add(request);
                }
                Close();
            }
        }

        /// <summary>
        /// Создать страницу "Значения"
        /// </summary>
        private void CreateValuesTabPage()
        {
            valuesTable = new() { ColumnCount = 2, RowCount = 1 };
            valuesTable.Controls.Add(new Label() { Text = "Столбец" }, 0, 0);
            valuesTable.Controls.Add(new Label() { Text = "Значение" }, 1, 0);

            valuesTable.AutoSize = true;
            valuesTable.AutoScroll = true;
            valuesTable.Dock = DockStyle.Fill;

            TabPage valuesPage = new() { Text = "Значения" };
            valuesPage.Controls.Add(valuesTable);
            tabControl.TabPages.Insert((int)Tabs.VALUESSection, valuesPage);

            idxs.Insert(3, Tabs.VALUESSection);
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            tabControl.SelectedIndex--;
            if (tabControl.SelectedIndex == 0)
                backButton.Hide();
        }

        private void AllAreUsedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < columnsListBox.Items.Count; i++)
                columnsListBox.SetItemChecked(i, allAreUsedCheckBox.Checked);
        }

        private void AddClauseButton_Click(object sender, EventArgs e)
        {
            ClauseChoosing clauseChoosing = new();
            clauseChoosing.FormClosing += OnCloseChoosingOperatorForm;
            clauseChoosing.Show();
        }

        /// <summary>
        /// Обработчик события закрытия формы выбора операции в секции "WHERE"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCloseChoosingOperatorForm(object? sender, FormClosingEventArgs e)
        {
            if (builder == null)
                return;

            if (sender is not ClauseChoosing clauseChoosing)
                return;

            if (whereTable.Controls.Count > 3)
            {
                whereTable.RowCount++;
                ComboBox comboBox1 = new();
                for (BundleType i = BundleType.AND; i < BundleType.Count; i++)
                    comboBox1.Items.Add(i.ToString());
                whereTable.Controls.Add(comboBox1, 1, whereTable.RowCount);
            }

            whereTable.RowCount++;
            ComboBox comboBox = new();
            foreach (var item in columnsListBox.Items)
                comboBox.Items.Add(item.ToString());
            whereTable.Controls.Add(comboBox, 0, whereTable.RowCount);

            whereTable.Controls.Add(new Label() { Text = clauseChoosing.ChosenOperator }, 1, whereTable.RowCount);

            ComboBox textBox = new();
            foreach (var request in RequestDB.Instance.requests)
                textBox.Items.Add(request.RequestName);
            whereTable.Controls.Add(textBox, 2, whereTable.RowCount);
        }

        private void UseWhereCheckBox_CheckedChanged(object sender, EventArgs e) => useWhereGroupBox.Enabled = useWhereCheckBox.Checked;

        private void UseGroupByCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (builder == null)
                return;

            grouppingColumnsComboBox.Enabled = useGroupByCheckBox.Checked;
            grouppingColumnsComboBox.Items.Clear();
            grouppingColumnsComboBox.Items.AddRange(builder.Columns.ToArray());
        }

        private void DeleteClauseButton_Click(object sender, EventArgs e)
        {
            if (whereTable.RowCount == 1)
                return;

            var control = whereTable.GetControlFromPosition(0, whereTable.RowCount);
            whereTable.Controls.Remove(control);
            control = whereTable.GetControlFromPosition(1, whereTable.RowCount);
            whereTable.Controls.Remove(control);
            control = whereTable.GetControlFromPosition(2, whereTable.RowCount);
            whereTable.Controls.Remove(control);
            whereTable.RowCount--;

            var andOrCombobox = (whereTable.GetControlFromPosition(1, whereTable.RowCount) as ComboBox);
            if (andOrCombobox != null)
            {
                whereTable.Controls.Remove(andOrCombobox);
                whereTable.RowCount--;
            }
        }

        private void AddnewJoinButton_Click(object sender, EventArgs e)
        {
            joinTableLayout.RowCount++;

            ComboBox tables2Combobox = new();
            tables2Combobox.Items.AddRange(DB.DB.GetTablesNames());
            joinTableLayout.Controls.Add(tables2Combobox, 0, joinTableLayout.RowCount);
            tables2Combobox.SelectedValueChanged += Tables2Combobox_SelectedValueChanged;

            ComboBox table1Columns = new();
            foreach (var item in columnsListBox.Items)
                table1Columns.Items.Add(item.ToString());
            joinTableLayout.Controls.Add(table1Columns, 1, joinTableLayout.RowCount);

            joinTableLayout.Controls.Add(new ComboBox(), 2, joinTableLayout.RowCount);

            var joinMethodsCheckBox = new CheckedListBox();
            for (JoinType type = JoinType.INNER; type < JoinType.COUNT; type++)
                joinMethodsCheckBox.Items.Add(type.ToString());
            joinTableLayout.Controls.Add(joinMethodsCheckBox, 3, joinTableLayout.RowCount);
        }

        private void Tables2Combobox_SelectedValueChanged(object? sender, EventArgs e)
        {
            if (sender is not ComboBox table2Combobox)
                return;

            var table = DB.DB.GetTableByTableName(table2Combobox.Text);
            if (table == null)
                return;

            var position = joinTableLayout.GetPositionFromControl(table2Combobox);
            if (joinTableLayout.GetControlFromPosition(position.Column + 2, position.Row) is ComboBox table2Columns)
            {
                table2Columns.Items.Clear();
                table2Columns.Items.AddRange(table.GetColumnsNames());
            }
        }

        private void UseJoinCheckBox_CheckedChanged(object sender, EventArgs e) => joinGroupBox.Enabled = useJoinCheckBox.Checked;

        private void AddNewRequestForm_Load(object sender, EventArgs e)
        {
            tablesNamesListBox.Items.Clear();
            tablesNamesListBox.Items.AddRange(DB.DB.GetTablesNames());

            builder = new RequestBuilder(originRequest);
            if (originRequest != null)
            {
                requestNameTextBox.Text = originRequest.RequestName;
                typesOfRequestsListBox.SetItemChecked((int)originRequest.RequestType, true);
                for (int i = 0; i < tablesNamesListBox.Items.Count; i++)
                {
                    if (tablesNamesListBox.Items[i].Equals(originRequest.TableName))
                    {
                        tablesNamesListBox.SetItemChecked(i, true);
                        break;
                    }
                }

                var table = DB.DB.GetTableByTableName(originRequest.TableName);
                if (table == null)
                    return;

                foreach (var col in table.GetColumnsNames())
                    columnsListBox.Items.Add(col);

                var columns = originRequest.Columns;
                if (table.GetColumnsNames().Length == columns.Count)
                    allAreUsedCheckBox.Checked = true;

                foreach (string column in columns)
                {
                    for (int i = 0; i < columnsListBox.Items.Count; i++)
                    {
                        if (columnsListBox.Items[i].Equals(column))
                        {
                            columnsListBox.SetItemChecked(i, true);
                            break;
                        }
                    }
                }

                if (originRequest.QueryParameters.Count > 0)
                {
                    CreateValuesTabPage();
                    if (valuesTable != null)
                    {
                        for (int i = 0; i < columns.Count; i++)
                        {
                            int idx = ++valuesTable.RowCount;

                            valuesTable.Controls.Add(new Label() { Text = columns[i] }, 0, idx);
                            valuesTable.Controls.Add(new TextBox() { Text = originRequest.QueryParameters[i] }, 1, idx);
                        }
                    }
                }

                if (originRequest.JoinParameter != null)
                {
                    useJoinCheckBox.Checked = true;

                    for (int i = 0; i < originRequest.JoinParameter.Table2Column.Count; i++)
                    {
                        joinTableLayout.RowCount++;
                        ComboBox tables2Combobox = new() { Text = originRequest.JoinParameter.Table1Name };
                        tables2Combobox.Items.AddRange(DB.DB.GetTablesNames());
                        joinTableLayout.Controls.Add(tables2Combobox, 0, joinTableLayout.RowCount);
                        tables2Combobox.SelectedValueChanged += Tables2Combobox_SelectedValueChanged;

                        ComboBox table1Columns = new() { Text = originRequest.JoinParameter.Table1Column[i] };
                        foreach (var item in columnsListBox.Items)
                            table1Columns.Items.Add(item.ToString());
                        joinTableLayout.Controls.Add(table1Columns, 1, joinTableLayout.RowCount);

                        ComboBox table2Columns = new() { Text = originRequest.JoinParameter.Table2Column[i] };
                        table2Columns.Items.AddRange(table.GetColumnsNames());
                        joinTableLayout.Controls.Add(table2Columns, 2, joinTableLayout.RowCount);

                        CheckedListBox joinMethodsCheckBox = new();
                        for (JoinType type = JoinType.INNER; type < JoinType.COUNT; type++)
                            joinMethodsCheckBox.Items.Add(type.ToString());
                        joinMethodsCheckBox.SetItemChecked((int)originRequest.JoinParameter.JoinType[i], true);
                        joinTableLayout.Controls.Add(joinMethodsCheckBox, 3, joinTableLayout.RowCount);
                    }
                }

                if (originRequest.WhereParameter != null)
                {
                    useWhereCheckBox.Checked = true;
                    for (int i = 0; i < originRequest.WhereParameter.Tokens.Count; i++)
                    {
                        whereTable.RowCount++;
                        if (originRequest.WhereParameter.Tokens[i] is BooleanExpression)
                        {
                            if (originRequest.WhereParameter.Tokens[i] is not BooleanExpression expr)
                                continue;

                            ComboBox comboBox = new() { Text = expr.LeftOperand };
                            foreach (var column in columns)
                                comboBox.Items.Add(column);
                            whereTable.Controls.Add(comboBox, 0, whereTable.RowCount);
                            whereTable.Controls.Add(new Label() { Text = expr.Operator }, 1, whereTable.RowCount);

                            if (expr.RightOperand.Length > 0)
                            {
                                ComboBox textBox = new() { Text = expr.RightOperand };
                                foreach (var r in RequestDB.Instance.requests)
                                    textBox.Items.Add(r.RequestName);
                                whereTable.Controls.Add(textBox, 2, whereTable.RowCount);
                            }

                            continue;
                        }

                        if (originRequest.WhereParameter.Tokens[i] is Bundle)
                        {
                            if (originRequest.WhereParameter.Tokens[i] is not Bundle bundle)
                                continue;

                            ComboBox comboBox1 = new();
                            for (BundleType j = BundleType.AND; j < BundleType.Count; j++)
                            {
                                comboBox1.Items.Add(j.ToString());
                                if (j == bundle.Type)
                                    comboBox1.SelectedIndex = (int)j;

                            }
                            whereTable.Controls.Add(comboBox1, 1, whereTable.RowCount);
                        }

                        if (originRequest.WhereParameter.Tokens[i] is Request)
                        {
                            if (originRequest.WhereParameter.Tokens[i] is not Request requestAsToken)
                                continue;

                            ComboBox textBox = new() { Text = requestAsToken.RequestName };
                            foreach (var r in RequestDB.Instance.requests)
                                textBox.Items.Add(r.RequestName);
                            whereTable.Controls.Add(textBox, 2, --whereTable.RowCount);
                        }
                    }
                }

                if (originRequest.GroupByParameter != null)
                {
                    useGroupByCheckBox.Checked = true;
                    grouppingColumnsComboBox.Items.Clear();
                    grouppingColumnsComboBox.Items.AddRange(columns.ToArray());
                    grouppingColumnsComboBox.Text = originRequest.GroupByParameter.ColumnName;
                }
            }
        }
    }
}