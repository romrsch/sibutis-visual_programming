using Project.Models;

namespace Project
{
    public partial class TablesForm : Form
    {
        public TablesForm() => InitializeComponent();

        private void TablesForm_Load(object sender, EventArgs e)
        {
            RequestDB.Instance.Deserialize();
            ShowSelectedTab();
            ShowRequests();
        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e) => ShowSelectedTab();

        /// <summary>
        /// Показать выбранную вкладку
        /// </summary>
        private void ShowSelectedTab()
        {
            var dbTable = DB.DB.GetTableByTableName(tabControl.SelectedTab.Text);
            if (dbTable == null)
                return;

            var grid = GetSelectedGrid();
            if (grid == null)
                return;

            grid.Rows.Clear();
            var records = dbTable.Select();
            foreach (Model record in records)
                grid.Rows.Add(record.ToArray());
        }

        /// <summary>
        /// Получить выбранную таблицу
        /// </summary>
        /// <returns>Таблица</returns>
        private DataGridView? GetSelectedGrid() => tabControl.SelectedTab.Text switch
        {
            "albums" => albumsGrid,
            "artists" => artistsGrid,
            "customers" => customersGrid,
            "employees" => employeesGrid,
            "genres" => genresGrid,
            "invoice_items" => invoiceItemsGrid,
            "invoices" => invoicesGrid,
            "media_types" => mediaTypesGrid,
            "playlists" => playlistGrid,
            "playlist_track" => playlistTrackGrid,
            "tracks" => tracksGrid,
            _ => null,
        };

        private void AddNewRecordStripMenuItem_Click(object sender, EventArgs e)
        {
            var grid = GetSelectedGrid();
            if (grid == null)
                return;

            int idx = grid.Rows.Add();
            var addedRow = grid.Rows[idx];
            addedRow.ReadOnly = false;

            ToolStripMenuItem finishMenuItem = new("Завершить и сохранить");
            ToolStripMenuItem cancelMenuItem = new("Отменить");
            ContextMenuStrip contextMenuStrip = new();
            contextMenuStrip.Items.AddRange(new[] { finishMenuItem, cancelMenuItem });

            finishMenuItem.Click += FinishMenuItem_Click;
            cancelMenuItem.Click += CancelMenuItem_Click;

            tabControl.ContextMenuStrip = contextMenuStrip;
        }

        private void FinishMenuItem_Click(object? sender, EventArgs e)
        {
            var grid = GetSelectedGrid();
            if (grid == null)
                return;

            var rowToAdd = grid.Rows[^2];
            Model? record = Model.GetModel(tabControl.SelectedTab.Text);
            if (record == null)
                return;

            record.InitFromGridRow(rowToAdd);
            var dbTable = DB.DB.GetTableByTableName(tabControl.SelectedTab.Text);
            if (dbTable != null)
                dbTable.Insert(record);

            tabControl.ContextMenuStrip = contextMenuStrip1;
        }

        private void CancelMenuItem_Click(object? sender, EventArgs e)
        {
            var grid = GetSelectedGrid();
            if (grid == null)
                return;

            grid.Rows.RemoveAt(grid.Rows.Count - 2);

            tabControl.ContextMenuStrip = contextMenuStrip1;
        }

        /// <summary>
        /// Показать запросы
        /// </summary>
        private void ShowRequests()
        {
            requestsListBox.Items.Clear();
            var requestDB = RequestDB.Instance;
            foreach (var request in requestDB.requests)
                requestsListBox.Items.Add(request.RequestName, false);
        }

        private void ExecuteRequestButton_Click(object sender, EventArgs e)
        {
            var selectedCommand = requestsListBox.CheckedItems;
            if (selectedCommand.Count == 0)
                return;
            string item = (string)selectedCommand[0];
            var request = RequestDB.Instance.requests.Find(request => request.RequestName == item);
            if (request == null)
                return;

            var records = DB.DB.Execute(request);
            ShowSelectedTab();
            if (records == null || records.Count == 0)
                return;

            TabPage tabPage = new() { Size = tabControl.Size };
            DataGridView dataGridView = new() { Size = tabPage.Size };
            if (records.Count > 0)
                dataGridView.ColumnCount = request.ColumnsCount + (request.JoinParameter == null ? 0 : request.JoinParameter.Table2Column.Count);
            tabPage.Text = request.RequestName;
            tabPage.Controls.Add(dataGridView);
            tabControl.TabPages.Add(tabPage);

            var columnsNames = request.Columns;
            if (columnsNames.Count == 0)
                return;

            foreach (List<string> record in records)
                dataGridView.Rows.Add(record.ToArray());

            for (int i = 0; i < columnsNames.Count; i++)
                dataGridView.Columns[i].HeaderText = $"{request.TableName}.{columnsNames[i]}";
            if (request.JoinParameter != null)
            {
                for (int i = columnsNames.Count; i < dataGridView.ColumnCount; i++)
                    dataGridView.Columns[i].HeaderText = $"{request.JoinParameter.Table2Name[i - columnsNames.Count]}.{request.JoinParameter.Table2Column[i - columnsNames.Count]}";
            }

            dataGridView.Dock = DockStyle.Fill;

            for (int i = 0; i < requestsListBox.Items.Count; i++)
                requestsListBox.SetItemChecked(i, false);
        }

        private void CloseOpenedTabMenuItem_Click(object sender, EventArgs e)
        {
            int selectedIndex = tabControl.SelectedIndex;
            if (selectedIndex > 10)
                tabControl.TabPages.RemoveAt(selectedIndex);
        }

        private void TablesForm_FormClosing(object sender, FormClosingEventArgs e) => RequestDB.Instance.Serialize();

        private void EditNewRecordStripMenuItem_Click(object sender, EventArgs e)
        {
            var grid = GetSelectedGrid();
            if (grid == null)
                return;

            var rowToAdd = grid.Rows[^2];
            Model? record = Model.GetModel(tabControl.SelectedTab.Text);
            if (record == null)
                return;

            record.InitFromGridRow(rowToAdd);
            var dbTable = DB.DB.GetTableByTableName(tabControl.SelectedTab.Text);
            if (dbTable != null)
                dbTable.Update(record);
            ShowSelectedTab();
        }

        private void RemoveSelectedRecordsStripMenuItem_Click(object sender, EventArgs e)
        {
            var grid = GetSelectedGrid();
            if (grid == null)
                return;

            var rowToAdd = grid.Rows[^2];
            Model? record = Model.GetModel(tabControl.SelectedTab.Text);
            if (record == null)
                return;

            record.InitFromGridRow(rowToAdd);
            var dbTable = DB.DB.GetTableByTableName(tabControl.SelectedTab.Text);
            if (dbTable != null)
            {
                dbTable.Delete(record);
                ShowSelectedTab();
            }
        }

        private void OpenRequestsManager_Click(object sender, EventArgs e)
        {
            RequestsManager manager = new();
            manager.FormClosed += RequestManagerFormClosed;
            Enabled = false;

            manager.Show();
        }

        /// <summary>
        /// Обработчик события закрытия формы менеджера запросов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RequestManagerFormClosed(object? sender, FormClosedEventArgs e)
        {
            Enabled = true;
            ShowRequests();
            ShowSelectedTab();
        }
    }
}