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
            this.ReceiptDataGridView = new System.Windows.Forms.DataGridView();
            this.dateTime = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.receiptNumberTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.RefundButton = new System.Windows.Forms.Button();
            this.showReceipt = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.receiptDetailGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReceiptDataGridView)).BeginInit();
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
            this.receiptDetailGridView.Location = new System.Drawing.Point(12, 51);
            this.receiptDetailGridView.Name = "receiptDetailGridView";
            this.receiptDetailGridView.ReadOnly = true;
            this.receiptDetailGridView.RowHeadersVisible = false;
            this.receiptDetailGridView.RowHeadersWidth = 51;
            this.receiptDetailGridView.RowTemplate.Height = 23;
            this.receiptDetailGridView.Size = new System.Drawing.Size(377, 419);
            this.receiptDetailGridView.TabIndex = 1;
            // 
            // ReceiptDataGridView
            // 
            this.ReceiptDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ReceiptDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ReceiptDataGridView.Location = new System.Drawing.Point(426, 51);
            this.ReceiptDataGridView.Name = "ReceiptDataGridView";
            this.ReceiptDataGridView.ReadOnly = true;
            this.ReceiptDataGridView.RowHeadersVisible = false;
            this.ReceiptDataGridView.RowHeadersWidth = 51;
            this.ReceiptDataGridView.RowTemplate.Height = 23;
            this.ReceiptDataGridView.Size = new System.Drawing.Size(420, 477);
            this.ReceiptDataGridView.TabIndex = 2;
            this.ReceiptDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ReceiptDataGridView_CellContentClick);
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
            // receiptNumberTextBox
            // 
            this.receiptNumberTextBox.Location = new System.Drawing.Point(676, 15);
            this.receiptNumberTextBox.Name = "receiptNumberTextBox";
            this.receiptNumberTextBox.Size = new System.Drawing.Size(89, 21);
            this.receiptNumberTextBox.TabIndex = 5;
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
            // RefundButton
            // 
            this.RefundButton.Location = new System.Drawing.Point(17, 487);
            this.RefundButton.Name = "RefundButton";
            this.RefundButton.Size = new System.Drawing.Size(84, 41);
            this.RefundButton.TabIndex = 7;
            this.RefundButton.Text = "환불";
            this.RefundButton.UseVisualStyleBackColor = true;
            this.RefundButton.Click += new System.EventHandler(this.RefundButton_Click_1);
            // 
            // showReceipt
            // 
            this.showReceipt.Location = new System.Drawing.Point(253, 487);
            this.showReceipt.Name = "showReceipt";
            this.showReceipt.Size = new System.Drawing.Size(136, 41);
            this.showReceipt.TabIndex = 8;
            this.showReceipt.Text = "영수증출력";
            this.showReceipt.UseVisualStyleBackColor = true;
            this.showReceipt.Click += new System.EventHandler(this.showReceipt_Click);
            // 
            // receipt
            // 
            this.ClientSize = new System.Drawing.Size(860, 540);
            this.Controls.Add(this.showReceipt);
            this.Controls.Add(this.RefundButton);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.receiptNumberTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dateTime);
            this.Controls.Add(this.ReceiptDataGridView);
            this.Controls.Add(this.receiptDetailGridView);
            this.Controls.Add(this.label4);
            this.Name = "receipt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "영수증";
            ((System.ComponentModel.ISupportInitialize)(this.receiptDetailGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReceiptDataGridView)).EndInit();
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
        private System.Windows.Forms.DataGridView ReceiptDataGridView;
        private System.Windows.Forms.DateTimePicker dateTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox receiptNumberTextBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Button RefundButton;
        private System.Windows.Forms.Button showReceipt;
    }
}