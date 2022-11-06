namespace Project
{
    partial class AddNewRequestForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.requestNameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.tablesNamesListBox = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.typesOfRequestsListBox = new System.Windows.Forms.CheckedListBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.allAreUsedCheckBox = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.columnsListBox = new System.Windows.Forms.CheckedListBox();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.joinGroupBox = new System.Windows.Forms.GroupBox();
            this.addNewJoinButton = new System.Windows.Forms.Button();
            this.joinTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.deleteJoinButton = new System.Windows.Forms.Button();
            this.useJoinCheckBox = new System.Windows.Forms.CheckBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.useWhereGroupBox = new System.Windows.Forms.GroupBox();
            this.deleteClauseButton = new System.Windows.Forms.Button();
            this.addClauseButton = new System.Windows.Forms.Button();
            this.whereTable = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.useWhereCheckBox = new System.Windows.Forms.CheckBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.useGroupByCheckBox = new System.Windows.Forms.CheckBox();
            this.grouppingColumnsComboBox = new System.Windows.Forms.ComboBox();
            this.forwardButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.joinGroupBox.SuspendLayout();
            this.joinTableLayout.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.useWhereGroupBox.SuspendLayout();
            this.whereTable.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Controls.Add(this.tabPage6);
            this.tabControl.Controls.Add(this.tabPage4);
            this.tabControl.Controls.Add(this.tabPage5);
            this.tabControl.Location = new System.Drawing.Point(93, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(613, 413);
            this.tabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.requestNameTextBox);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(605, 385);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Название";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // requestNameTextBox
            // 
            this.requestNameTextBox.Location = new System.Drawing.Point(33, 69);
            this.requestNameTextBox.Name = "requestNameTextBox";
            this.requestNameTextBox.Size = new System.Drawing.Size(417, 23);
            this.requestNameTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Введите название запроса";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.tablesNamesListBox);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.typesOfRequestsListBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(605, 385);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Тип запроса и таблица";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(338, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Выберите таблицу";
            // 
            // tablesNamesListBox
            // 
            this.tablesNamesListBox.CheckOnClick = true;
            this.tablesNamesListBox.FormattingEnabled = true;
            this.tablesNamesListBox.Items.AddRange(new object[] {
            "employees"});
            this.tablesNamesListBox.Location = new System.Drawing.Point(338, 40);
            this.tablesNamesListBox.Name = "tablesNamesListBox";
            this.tablesNamesListBox.Size = new System.Drawing.Size(188, 292);
            this.tablesNamesListBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(70, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Выберите тип запроса";
            // 
            // typesOfRequestsListBox
            // 
            this.typesOfRequestsListBox.CheckOnClick = true;
            this.typesOfRequestsListBox.FormattingEnabled = true;
            this.typesOfRequestsListBox.Items.AddRange(new object[] {
            "Выбрать",
            "Вставить",
            "Обновить",
            "Удалить"});
            this.typesOfRequestsListBox.Location = new System.Drawing.Point(70, 40);
            this.typesOfRequestsListBox.Name = "typesOfRequestsListBox";
            this.typesOfRequestsListBox.Size = new System.Drawing.Size(188, 292);
            this.typesOfRequestsListBox.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.allAreUsedCheckBox);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.columnsListBox);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(605, 385);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Столбцы";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // allAreUsedCheckBox
            // 
            this.allAreUsedCheckBox.AutoSize = true;
            this.allAreUsedCheckBox.Location = new System.Drawing.Point(102, 40);
            this.allAreUsedCheckBox.Name = "allAreUsedCheckBox";
            this.allAreUsedCheckBox.Size = new System.Drawing.Size(45, 19);
            this.allAreUsedCheckBox.TabIndex = 6;
            this.allAreUsedCheckBox.Text = "Все";
            this.allAreUsedCheckBox.UseVisualStyleBackColor = true;
            this.allAreUsedCheckBox.CheckedChanged += new System.EventHandler(this.AllAreUsedCheckBox_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(102, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Выберите столбцы";
            // 
            // columnsListBox
            // 
            this.columnsListBox.CheckOnClick = true;
            this.columnsListBox.FormattingEnabled = true;
            this.columnsListBox.Location = new System.Drawing.Point(102, 65);
            this.columnsListBox.Name = "columnsListBox";
            this.columnsListBox.Size = new System.Drawing.Size(188, 292);
            this.columnsListBox.TabIndex = 4;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.joinGroupBox);
            this.tabPage6.Controls.Add(this.useJoinCheckBox);
            this.tabPage6.Location = new System.Drawing.Point(4, 24);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(605, 385);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Объединение";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // joinGroupBox
            // 
            this.joinGroupBox.Controls.Add(this.addNewJoinButton);
            this.joinGroupBox.Controls.Add(this.joinTableLayout);
            this.joinGroupBox.Controls.Add(this.deleteJoinButton);
            this.joinGroupBox.Enabled = false;
            this.joinGroupBox.Location = new System.Drawing.Point(0, 53);
            this.joinGroupBox.Name = "joinGroupBox";
            this.joinGroupBox.Size = new System.Drawing.Size(605, 332);
            this.joinGroupBox.TabIndex = 4;
            this.joinGroupBox.TabStop = false;
            this.joinGroupBox.Text = "Параметры";
            // 
            // addNewJoinButton
            // 
            this.addNewJoinButton.Location = new System.Drawing.Point(6, 18);
            this.addNewJoinButton.Name = "addNewJoinButton";
            this.addNewJoinButton.Size = new System.Drawing.Size(117, 23);
            this.addNewJoinButton.TabIndex = 2;
            this.addNewJoinButton.Text = "Добавить строку";
            this.addNewJoinButton.UseVisualStyleBackColor = true;
            this.addNewJoinButton.Click += new System.EventHandler(this.AddnewJoinButton_Click);
            // 
            // joinTableLayout
            // 
            this.joinTableLayout.AutoScroll = true;
            this.joinTableLayout.ColumnCount = 4;
            this.joinTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28F));
            this.joinTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28F));
            this.joinTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28F));
            this.joinTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.joinTableLayout.Controls.Add(this.label9, 0, 0);
            this.joinTableLayout.Controls.Add(this.label10, 1, 0);
            this.joinTableLayout.Controls.Add(this.label11, 2, 0);
            this.joinTableLayout.Controls.Add(this.label12, 3, 0);
            this.joinTableLayout.Location = new System.Drawing.Point(0, 61);
            this.joinTableLayout.Name = "joinTableLayout";
            this.joinTableLayout.RowCount = 1;
            this.joinTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.joinTableLayout.Size = new System.Drawing.Size(605, 271);
            this.joinTableLayout.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 15);
            this.label9.TabIndex = 0;
            this.label9.Text = "Таблица 2";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(172, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(122, 15);
            this.label10.TabIndex = 1;
            this.label10.Text = "Параметр таблицы 1";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(341, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(122, 15);
            this.label11.TabIndex = 2;
            this.label11.Text = "Параметр таблицы 2";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(510, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 15);
            this.label12.TabIndex = 3;
            this.label12.Text = "Тип JOIN";
            // 
            // deleteJoinButton
            // 
            this.deleteJoinButton.Location = new System.Drawing.Point(129, 18);
            this.deleteJoinButton.Name = "deleteJoinButton";
            this.deleteJoinButton.Size = new System.Drawing.Size(181, 23);
            this.deleteJoinButton.TabIndex = 3;
            this.deleteJoinButton.Text = "Удалить последнюю строку";
            this.deleteJoinButton.UseVisualStyleBackColor = true;
            // 
            // useJoinCheckBox
            // 
            this.useJoinCheckBox.AutoSize = true;
            this.useJoinCheckBox.Location = new System.Drawing.Point(15, 18);
            this.useJoinCheckBox.Name = "useJoinCheckBox";
            this.useJoinCheckBox.Size = new System.Drawing.Size(127, 19);
            this.useJoinCheckBox.TabIndex = 0;
            this.useJoinCheckBox.Text = "Использовать Join";
            this.useJoinCheckBox.UseVisualStyleBackColor = true;
            this.useJoinCheckBox.CheckedChanged += new System.EventHandler(this.UseJoinCheckBox_CheckedChanged);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.useWhereGroupBox);
            this.tabPage4.Controls.Add(this.useWhereCheckBox);
            this.tabPage4.Location = new System.Drawing.Point(4, 24);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(605, 385);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Условие отбора";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // useWhereGroupBox
            // 
            this.useWhereGroupBox.Controls.Add(this.deleteClauseButton);
            this.useWhereGroupBox.Controls.Add(this.addClauseButton);
            this.useWhereGroupBox.Controls.Add(this.whereTable);
            this.useWhereGroupBox.Enabled = false;
            this.useWhereGroupBox.Location = new System.Drawing.Point(6, 40);
            this.useWhereGroupBox.Name = "useWhereGroupBox";
            this.useWhereGroupBox.Size = new System.Drawing.Size(593, 342);
            this.useWhereGroupBox.TabIndex = 1;
            this.useWhereGroupBox.TabStop = false;
            this.useWhereGroupBox.Text = "Параметры";
            // 
            // deleteClauseButton
            // 
            this.deleteClauseButton.Location = new System.Drawing.Point(136, 18);
            this.deleteClauseButton.Name = "deleteClauseButton";
            this.deleteClauseButton.Size = new System.Drawing.Size(183, 23);
            this.deleteClauseButton.TabIndex = 2;
            this.deleteClauseButton.Text = "Удалить последнее условие";
            this.deleteClauseButton.UseVisualStyleBackColor = true;
            this.deleteClauseButton.Click += new System.EventHandler(this.DeleteClauseButton_Click);
            // 
            // addClauseButton
            // 
            this.addClauseButton.Location = new System.Drawing.Point(6, 18);
            this.addClauseButton.Name = "addClauseButton";
            this.addClauseButton.Size = new System.Drawing.Size(124, 23);
            this.addClauseButton.TabIndex = 1;
            this.addClauseButton.Text = "Добавить условие";
            this.addClauseButton.UseVisualStyleBackColor = true;
            this.addClauseButton.Click += new System.EventHandler(this.AddClauseButton_Click);
            // 
            // whereTable
            // 
            this.whereTable.AutoSize = true;
            this.whereTable.ColumnCount = 3;
            this.whereTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.whereTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.whereTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.whereTable.Controls.Add(this.label6, 1, 0);
            this.whereTable.Controls.Add(this.label5, 0, 0);
            this.whereTable.Controls.Add(this.label7, 2, 0);
            this.whereTable.Location = new System.Drawing.Point(0, 47);
            this.whereTable.Name = "whereTable";
            this.whereTable.RowCount = 1;
            this.whereTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.whereTable.Size = new System.Drawing.Size(593, 26);
            this.whereTable.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(200, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 15);
            this.label6.TabIndex = 1;
            this.label6.Text = "Условие";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Левый операнд";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(397, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 15);
            this.label7.TabIndex = 2;
            this.label7.Text = "Правый операнд";
            // 
            // useWhereCheckBox
            // 
            this.useWhereCheckBox.AutoSize = true;
            this.useWhereCheckBox.Location = new System.Drawing.Point(20, 13);
            this.useWhereCheckBox.Name = "useWhereCheckBox";
            this.useWhereCheckBox.Size = new System.Drawing.Size(145, 19);
            this.useWhereCheckBox.TabIndex = 0;
            this.useWhereCheckBox.Text = "Использовать WHERE";
            this.useWhereCheckBox.UseVisualStyleBackColor = true;
            this.useWhereCheckBox.CheckedChanged += new System.EventHandler(this.UseWhereCheckBox_CheckedChanged);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.label8);
            this.tabPage5.Controls.Add(this.useGroupByCheckBox);
            this.tabPage5.Controls.Add(this.grouppingColumnsComboBox);
            this.tabPage5.Location = new System.Drawing.Point(4, 24);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(605, 385);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Группировка";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(45, 64);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 15);
            this.label8.TabIndex = 0;
            this.label8.Text = "Столбец";
            // 
            // useGroupByCheckBox
            // 
            this.useGroupByCheckBox.AutoSize = true;
            this.useGroupByCheckBox.Location = new System.Drawing.Point(45, 32);
            this.useGroupByCheckBox.Name = "useGroupByCheckBox";
            this.useGroupByCheckBox.Size = new System.Drawing.Size(162, 19);
            this.useGroupByCheckBox.TabIndex = 0;
            this.useGroupByCheckBox.Text = "Использовать GROUP BY";
            this.useGroupByCheckBox.UseVisualStyleBackColor = true;
            this.useGroupByCheckBox.CheckedChanged += new System.EventHandler(this.UseGroupByCheckBox_CheckedChanged);
            // 
            // grouppingColumnsComboBox
            // 
            this.grouppingColumnsComboBox.Enabled = false;
            this.grouppingColumnsComboBox.FormattingEnabled = true;
            this.grouppingColumnsComboBox.Location = new System.Drawing.Point(45, 82);
            this.grouppingColumnsComboBox.Name = "grouppingColumnsComboBox";
            this.grouppingColumnsComboBox.Size = new System.Drawing.Size(121, 23);
            this.grouppingColumnsComboBox.TabIndex = 2;
            // 
            // forwardButton
            // 
            this.forwardButton.Location = new System.Drawing.Point(712, 212);
            this.forwardButton.Name = "forwardButton";
            this.forwardButton.Size = new System.Drawing.Size(75, 23);
            this.forwardButton.TabIndex = 0;
            this.forwardButton.Text = ">";
            this.forwardButton.UseVisualStyleBackColor = true;
            this.forwardButton.Click += new System.EventHandler(this.ForwardButton_Click);
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(16, 212);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 23);
            this.backButton.TabIndex = 1;
            this.backButton.Text = "<";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Visible = false;
            this.backButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // AddNewRequestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 430);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.forwardButton);
            this.Controls.Add(this.tabControl);
            this.Name = "AddNewRequestForm";
            this.Text = "Создание/редактирование запроса";
            this.Load += new System.EventHandler(this.AddNewRequestForm_Load);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.joinGroupBox.ResumeLayout(false);
            this.joinTableLayout.ResumeLayout(false);
            this.joinTableLayout.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.useWhereGroupBox.ResumeLayout(false);
            this.useWhereGroupBox.PerformLayout();
            this.whereTable.ResumeLayout(false);
            this.whereTable.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tabControl;
        private TabPage tabPage1;
        private Button forwardButton;
        private TabPage tabPage2;
        private Button backButton;
        private TextBox requestNameTextBox;
        private Label label1;
        private CheckedListBox typesOfRequestsListBox;
        private Label label2;
        private Label label3;
        private CheckedListBox tablesNamesListBox;
        private TabPage tabPage3;
        private CheckBox allAreUsedCheckBox;
        private Label label4;
        private CheckedListBox columnsListBox;
        private TabPage tabPage4;
        private CheckBox useWhereCheckBox;
        private GroupBox useWhereGroupBox;
        private TableLayoutPanel whereTable;
        private Button deleteClauseButton;
        private Button addClauseButton;
        private Label label7;
        private Label label6;
        private Label label5;
        private TabPage tabPage5;
        private CheckBox useGroupByCheckBox;
        private Label label8;
        private ComboBox grouppingColumnsComboBox;
        private TabPage tabPage6;
        private CheckBox useJoinCheckBox;
        private TableLayoutPanel joinTableLayout;
        private Label label9;
        private Label label10;
        private Label label11;
        private Button deleteJoinButton;
        private Button addNewJoinButton;
        private Label label12;
        private GroupBox joinGroupBox;
    }
}