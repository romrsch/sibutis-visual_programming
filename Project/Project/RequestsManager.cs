namespace Project
{
    public partial class RequestsManager : Form
    {
        public RequestsManager()
        {
            InitializeComponent();

            var requests = RequestDB.Instance.requests;
            foreach (var request in requests)
                requestsList.Items.Add(request.RequestName);
        }

        private void AddRequestButton_Click(object sender, EventArgs e)
        {
            AddNewRequestForm window = new();
            window.FormClosed += ShowRequests;
            window.Show();
        }

        /// <summary>
        /// Показать запросы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowRequests(object? sender, FormClosedEventArgs e)
        {
            requestsList.Items.Clear();
            var requestDB = RequestDB.Instance;
            foreach (var request in requestDB.requests)
                requestsList.Items.Add(request.RequestName, false);
        }

        private void DeleteRequestButton_Click(object sender, EventArgs e)
        {
            var checkedIndices = requestsList.CheckedIndices;
            foreach (var idx in checkedIndices)
                RequestDB.Instance.requests.RemoveAt((int)idx);

            ShowRequests(null, new FormClosedEventArgs(CloseReason.None));
        }

        private void EditRequestButton_Click(object sender, EventArgs e)
        {
            int selectedRequestNumber = requestsList.SelectedIndex;
            if (selectedRequestNumber == -1)
                return;

            AddNewRequestForm window = new(RequestDB.Instance.requests[selectedRequestNumber]);
            window.FormClosed += ShowRequests;
            window.Show();
        }

        private void SaveRequestsButton_Click(object sender, EventArgs e) => RequestDB.Instance.Serialize();
    }
}
