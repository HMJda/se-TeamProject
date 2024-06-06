namespace TP
{
    partial class receipt
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
            this.label4 = new System.Windows.Forms.Label();
            this.receiptDetailGridView = new System.Windows.Forms.DataGridView();
            this.receiptDataGridView = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateTime = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.searchTextbox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.refundButton = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.cash = new System.Windows.Forms.CheckBox();
            this.card = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.receiptDetailGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.receiptDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(13, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 24);
            this.label4.TabIndex = 0;
            this.label4.Text = "영수증 조회";
            // 
            // receiptDetailGridView
            // 
            this.receiptDetailGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.receiptDetailGridView.Location = new System.Drawing.Point(12, 71);
            this.receiptDetailGridView.Name = "receiptDetailGridView";
            this.receiptDetailGridView.RowTemplate.Height = 23;
            this.receiptDetailGridView.Size = new System.Drawing.Size(377, 399);
            this.receiptDetailGridView.TabIndex = 1;
            // 
            // receiptDataGridView
            // 
            this.receiptDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.receiptDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.receiptDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.receiptDataGridView.Location = new System.Drawing.Point(426, 51);
            this.receiptDataGridView.Name = "receiptDataGridView";
            this.receiptDataGridView.RowHeadersVisible = false;
            this.receiptDataGridView.RowTemplate.Height = 23;
            this.receiptDataGridView.Size = new System.Drawing.Size(420, 477);
            this.receiptDataGridView.TabIndex = 2;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "No";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "거래시간";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "거래 형태";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "금 액";
            this.Column4.Name = "Column4";
            // 
            // dateTime
            // 
            this.dateTime.Location = new System.Drawing.Point(426, 15);
            this.dateTime.Name = "dateTime";
            this.dateTime.Size = new System.Drawing.Size(169, 21);
            this.dateTime.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(601, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "영수증 번호";
            // 
            // searchTextbox
            // 
            this.searchTextbox.Location = new System.Drawing.Point(676, 15);
            this.searchTextbox.Name = "searchTextbox";
            this.searchTextbox.Size = new System.Drawing.Size(89, 21);
            this.searchTextbox.TabIndex = 5;
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(771, 13);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 23);
            this.searchButton.TabIndex = 6;
            this.searchButton.Text = "검색";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // refundButton
            // 
            this.refundButton.Location = new System.Drawing.Point(17, 487);
            this.refundButton.Name = "refundButton";
            this.refundButton.Size = new System.Drawing.Size(84, 41);
            this.refundButton.TabIndex = 7;
            this.refundButton.Text = "환불";
            this.refundButton.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(285, 487);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(104, 41);
            this.button6.TabIndex = 8;
            this.button6.Text = "영수증 출력";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // cash
            // 
            this.cash.AutoSize = true;
            this.cash.Location = new System.Drawing.Point(199, 13);
            this.cash.Name = "cash";
            this.cash.Size = new System.Drawing.Size(48, 16);
            this.cash.TabIndex = 9;
            this.cash.Text = "현금";
            this.cash.UseVisualStyleBackColor = true;
            // 
            // card
            // 
            this.card.AutoSize = true;
            this.card.Location = new System.Drawing.Point(199, 36);
            this.card.Name = "card";
            this.card.Size = new System.Drawing.Size(48, 16);
            this.card.TabIndex = 10;
            this.card.Text = "카드";
            this.card.UseVisualStyleBackColor = true;
            // 
            // receipt
            // 
            this.ClientSize = new System.Drawing.Size(860, 540);
            this.Controls.Add(this.card);
            this.Controls.Add(this.cash);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.refundButton);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.searchTextbox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dateTime);
            this.Controls.Add(this.receiptDataGridView);
            this.Controls.Add(this.receiptDetailGridView);
            this.Controls.Add(this.label4);
            this.Name = "receipt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "영수증";
            ((System.ComponentModel.ISupportInitialize)(this.receiptDetailGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.receiptDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView receiptDetailGridView;
        private System.Windows.Forms.DataGridView receiptDataGridView;
        private System.Windows.Forms.DateTimePicker dateTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox searchTextbox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Button refundButton;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.CheckBox cash;
        private System.Windows.Forms.CheckBox card;
    }
}