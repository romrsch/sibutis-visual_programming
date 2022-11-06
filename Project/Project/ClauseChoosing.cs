namespace Project
{
    public partial class ClauseChoosing : Form
    {
        public ClauseChoosing()
        {
            InitializeComponent();

            var opers = WhereParameter.WhereOperators;
            foreach (var oper in opers)
                clausesComboBox.Items.Add(oper);
        }

        /// <summary>
        /// Выбранный оператор
        /// </summary>
        private string chosenOperator = "";
        public string ChosenOperator => chosenOperator;

        private void OkButton_Click(object sender, EventArgs e)
        {
            chosenOperator = clausesComboBox.Text;
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e) => Close();
    }
}
