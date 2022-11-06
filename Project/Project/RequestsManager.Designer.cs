namespace Project
{
    partial class RequestsManager
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.requestsList = new System.Windows.Forms.CheckedListBox();
            this.editRequestButton = new System.Windows.Forms.Button();
            this.deleteRequestButton = new System.Windows.Forms.Button();
            this.addRequestButton = new System.Windows.Forms.Button();
            this.saveRequestsButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.requestsList);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.saveRequestsButton);
            this.splitContainer1.Panel2.Controls.Add(this.editRequestButton);
            this.splitContainer1.Panel2.Controls.Add(this.deleteRequestButton);
            this.splitContainer1.Panel2.Controls.Add(this.addRequestButton);
            this.splitContainer1.Size = new System.Drawing.Size(759, 450);
            this.splitContainer1.SplitterDistance = 506;
            this.splitContainer1.TabIndex = 0;
            // 
            // requestsList
            // 
            this.requestsList.CheckOnClick = true;
            this.requestsList.FormattingEnabled = true;
            this.requestsList.Location = new System.Drawing.Point(3, 6);
            this.requestsList.Name = "requestsList";
            this.requestsList.Size = new System.Drawing.Size(500, 436);
            this.requestsList.TabIndex = 0;
            // 
            // editRequestButton
            // 
            this.editRequestButton.Location = new System.Drawing.Point(11, 74);
            this.editRequestButton.Name = "editRequestButton";
            this.editRequestButton.Size = new System.Drawing.Size(200, 23);
            this.editRequestButton.TabIndex = 2;
            this.editRequestButton.Text = "Редактировать";
            this.editRequestButton.UseVisualStyleBackColor = true;
            this.editRequestButton.Click += new System.EventHandler(this.EditRequestButton_Click);
            // 
            // deleteRequestButton
            // 
            this.deleteRequestButton.Location = new System.Drawing.Point(11, 45);
            this.deleteRequestButton.Name = "deleteRequestButton";
            this.deleteRequestButton.Size = new System.Drawing.Size(200, 23);
            this.deleteRequestButton.TabIndex = 1;
            this.deleteRequestButton.Text = "Удалить выбранный запрос";
            this.deleteRequestButton.UseVisualStyleBackColor = true;
            this.deleteRequestButton.Click += new System.EventHandler(this.DeleteRequestButton_Click);
            // 
            // addRequestButton
            // 
            this.addRequestButton.Location = new System.Drawing.Point(11, 16);
            this.addRequestButton.Name = "addRequestButton";
            this.addRequestButton.Size = new System.Drawing.Size(200, 23);
            this.addRequestButton.TabIndex = 0;
            this.addRequestButton.Text = "Добавить новый запрос";
            this.addRequestButton.UseVisualStyleBackColor = true;
            this.addRequestButton.Click += new System.EventHandler(this.AddRequestButton_Click);
            // 
            // saveRequestsButton
            // 
            this.saveRequestsButton.Location = new System.Drawing.Point(11, 103);
            this.saveRequestsButton.Name = "saveRequestsButton";
            this.saveRequestsButton.Size = new System.Drawing.Size(200, 23);
            this.saveRequestsButton.TabIndex = 3;
            this.saveRequestsButton.Text = "Сохранить";
            this.saveRequestsButton.UseVisualStyleBackColor = true;
            this.saveRequestsButton.Click += new System.EventHandler(this.SaveRequestsButton_Click);
            // 
            // RequestsManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "RequestsManager";
            this.Text = "Менеджер запросов";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private SplitContainer splitContainer1;
        private CheckedListBox requestsList;
        private Button addRequestButton;
        private Button editRequestButton;
        private Button deleteRequestButton;
        private Button saveRequestsButton;
    }
}